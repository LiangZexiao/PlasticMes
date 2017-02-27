// JScript 文件
// JScript File

// 下拉区背景色
var DIV_BG_COLOR = "#ffffff";

// 高亮显示条目颜色
var DIV_HIGHLIGHT_COLOR = "#ccffff";

// 字体
var DIV_FONT = "宋体";

// 下拉区内补丁大小
var DIV_PADDING = "2px";

// 下拉区边框样式
var DIV_BORDER = "1px solid #000000"; 

// 文本输入框
var queryField2;

// 下拉区ID
var divName2;

// IFrame名称
var ifName2;

// 记录上次选择的值
var lastVal2 = "";

// 当前选择的值
var val2 = "";

// 显示结果的下拉区
var globalDiv2;

// 下拉区是否设置格式的标记
var divFormatted2 = false;



//给哪个控件赋值
var newSetById2="";

var otherById2 ="";
var SetByIds2;


/**
InitQueryCode函数必须在<body onload>事件的响应函数中调用，其中：
queryFieldName为文本框控件的ID，
hiddenDivName为显示下拉区div的ID
*/
function InitQueryCode2(queryFieldName2, hiddenDivName2)
{
    try{

   // 指定文本输入框的onblur和onkeydown响应函数
    queryField2 = document.getElementById(queryFieldName2);
    queryField2.onblur = hideDiv;
    queryField2.onkeydown = keypressHandler2;

    // 设置queryField的autocomplete属性为"off"
    queryField2.autocomplete = "off";

    // 如果没有指定hiddenDivName，取默认值"querydiv"
    if (hiddenDivName2)
    {
        divName2 = hiddenDivName2;
    }
    else
    {
        divName2 = "querydivs";
    }

   // IFrame的name
    ifName2 = "queryiframe";

   // 100ms后调用mainLoop函数
    setTimeout("mainLoop2()", 1000);
    }catch(e)
    {
    alert("错误!"+e.doscripton);
    }
}

/**
获取下拉区的div,如果没有则创建之
*/
function getDiv2 (divID2)
{
    if (!globalDiv2)
    {
        // 如果div在页面中不存在，创建一个新的div
        if (!document.getElementById(divID2))
        {
            var newNode2 = document.createElement("div");
            newNode2.setAttribute("id", divID2);
            document.body.appendChild(newNode2);
        }

        // globalDiv2设置为div的引用       
        globalDiv2 = document.getElementById(divID2);
        // 计算div左上角的位置       
        var x = queryField2.offsetLeft;
        var y = queryField2.offsetTop + queryField2.offsetHeight;
        var parent = queryField2;
        while (parent.offsetParent)
        {
            parent = parent.offsetParent;
            x += parent.offsetLeft;
            y += parent.offsetTop;
        }

        // 如果没有对div设置格式，则为其设置相应的显示样式
        if (!divFormatted2)
        {
            globalDiv2.style.backgroundColor = DIV_BG_COLOR;
            globalDiv2.style.fontFamily = DIV_FONT;
            globalDiv2.style.padding = DIV_PADDING;
            globalDiv2.style.border = DIV_BORDER;
            globalDiv2.style.width ="160px";//document.getElementById(queryFieldName).style.width;// "100px";
            globalDiv2.style.fontSize = "13px";
            globalDiv2.style.height="120px";
            globalDiv2.style.overflow="auto";

            globalDiv2.style.position = "absolute";
            globalDiv2.style.left = x + "px";
            globalDiv2.style.top = y + "px";
            globalDiv2.style.visibility = "hidden";
            globalDiv2.style.zIndex = 10000;

            divFormatted2 = true;
        }
    }

    return globalDiv2;
}

/**
根据返回的结果集显示下拉区
*/
function showQueryDiv2(resultArray2)
{
   // 获取div的引用
    var div = getDiv2(divName2);
    // 如果div中有内容，则删除之
    while (div.childNodes.length > 0)
        div.removeChild(div.childNodes[0]);
        
        // 依次添加结果
        if(resultArray2!=null)
        {
            for (var i = 0; i < resultArray2.length; i++)
            {
               // 每一个结果也是一个div
                var result = document.createElement("div");
                // 设置结果div的显示样式
                result.style.cursor = "pointer";
                result.style.padding = "2px 0px 2px 0px";
                // 设置为未选中
                _unhighlightResult2(result);
                
                // 设置鼠标移进、移出等事件响应函数
                result.onmousedown = selectResult2;
                result.onmouseover = highlightResult2;
                result.onmouseout = unhighlightResult2;


                // 结果的文本是一个span
                var result1 = document.createElement("span");
                // 设置文本span的显示样式
                result1.className = "result1";
                result1.style.textAlign = "left";
                result1.style.fontWeight = "bold";
                result1.innerHTML = resultArray2[i];
               
                // 将span添加为结果div的子节点
                result.appendChild(result1);
               
                // 将结果div添加为下拉区的子节点
                div.appendChild(result);
            }
            //结果大于7条时，用滚动条
            if(resultArray2.length>7)
            {
                //var e=document.getElementById("search_suggest") 
                document.getElementById(divName2).scrollTop=document.getElementById(divName2).scrollHeight;
            }
            

        // 如果结果集不为空，则显示，否则不显示
        showDiv2(resultArray2.length > 0);
        }
        

}

/**
用户单击某个结果时，将文本框的内容替换为结果的文本，
并隐藏下拉区
*/
function selectResult2()
{
    _selectResult2(this);
}


/**
根据选择结果给其他文本框赋值
*/
function _innerTexts2(arrLsit2,SetByIds2)
{
    var innText="";
    document.getElementById(SetByIds2).innerText="";
    
    if(arrLsit2==null || arrLsit2=="")
    {
        document.getElementById(SetByIds2).innerText="";
    }
    else
    {
        for (var i = 0; i < arrLsit2.length; i++)
        {
         innText +=arrLsit2[i];
        }
        //alert(arrLsit[0]);
        document.getElementById(SetByIds2).innerText=innText;
    }
}
/**
当鼠标移到某个条目之上时，高亮显示该条目
*/
function highlightResult2()
{
    _highlightResult2(this);
}

function _highlightResult2(item2)
{
    item2.style.backgroundColor = DIV_HIGHLIGHT_COLOR;
}

/**
当鼠标移出某个条目时，正常显示该条目
*/
function unhighlightResult2()
{
    _unhighlightResult2(this);
}

function _unhighlightResult2(item2)
{
    item2.style.backgroundColor = DIV_BG_COLOR;
}

/**
显示/不显示下拉区
*/
function showDiv2 (show2)
{
    var div = getDiv2(divName2);
    if (show2)
    {
//        if( document.getElementById("search").disabled)
//        {
//            div.style.visibility = "hidden";
//        }
//        else
//        {
            div.style.visibility = "visible";
        //}
    }
    else
    {
        div.style.visibility = "hidden";
    }
    
    adjustiFrame2();
}

/**
隐藏下拉区
*/
function hideDiv ()
{
    showDiv2(false);
}

/**
调整IFrame的位置，这是为了解决div可能会显示在输入框后面的问题
*/
function adjustiFrame2()
{
    // 如果没有IFrame，则创建
    if (!document.getElementById(ifName2))
    {
        var newNode2 = document.createElement("iFrame");
        newNode2.setAttribute("id", ifName2);
        newNode2.setAttribute("src", "javascript:false;");
        newNode2.setAttribute("scrolling", "no");
        newNode2.setAttribute("frameborder", "0");
        document.body.appendChild(newNode2);
    }

    iFrameDiv2 = document.getElementById(ifName2);
    var div = getDiv2(divName2);

    // 调整IFrame的位置与div重合，并在div的下一层 
    try
    {
        iFrameDiv2.style.position = "absolute";
        iFrameDiv2.style.width = div.offsetWidth;
        iFrameDiv2.style.height = div.offsetHeight;
        iFrameDiv2.style.top = div.style.top;
        iFrameDiv2.style.left = div.style.left;
        iFrameDiv2.style.zIndex = div.style.zIndex - 1;
        iFrameDiv2.style.visibility = div.style.visibility;
    }
    catch (e)
    {
    }
}

/**
文本输入框的onkeydown响应函数
*/
function keypressHandler2 (evt2)
{
    // 获取对下拉区的引用        
    var div = getDiv2(divName2);

   // 如果下拉区不显示，则什么也不做       
    if (div.style.visibility == "hidden")
    {
        return true;
    }
  

    // 确保evt是一个有效的事件   
    if (!evt2 && window.event)
    {
        evt2 = window.event;
    }
    var key = evt2.keyCode;

    var KEYUP = 38;
    var KEYDOWN = 40;
    var KEYENTER = 13;
    var KEYTAB = 9;
    var KEYESC =27;
   
    // 只处理上下键、回车键和Tab键的响应       
    if ((key != KEYUP) && (key != KEYDOWN) && (key != KEYENTER) && (key != KEYTAB) && (key != KEYESC))
    {
        return true;
    }
    
    var selNum = getSelectedSpanNum2(div);
    var selSpan = setSelectedSpan2(div, selNum);
   
    if((key == KEYESC))
    {
//         if (selSpan)
//            {
//                _selectResult(selSpan);
//           }
            evt2.cancelBubble = true;
            
            // 隐藏下拉区
            showDiv2(false);
            return false;
    }
    else
    {
        // 如果键入回车和Tab，则选择当前选择条目   
        if ((key == KEYENTER) || (key == KEYTAB))
        {
            if (selSpan)
            {
                _selectResult2(selSpan);
           }
            evt2.cancelBubble = true;
            
            // 显示下拉区
            showDiv2(false);
            return false;
        }
        else //如果键入上下键，则上下移动选中条目
        {
            if (key == KEYUP)
            {
                selSpan = setSelectedSpan2(div, selNum - 1);
            }
            if (key == KEYDOWN)
            {
                selSpan = setSelectedSpan2(div, selNum + 1);
            }
            if (selSpan)
            {
                _highlightResult2(selSpan);
            }
            
        }
    }

    // 显示下拉区
    showDiv2(true);
    return true;
}

/**
获取当前选中的条目的序号
*/
function getSelectedSpanNum2(div)
{
    var count = -1;
    var spans = div.getElementsByTagName("div");
    if (spans)
    {
        for (var i = 0; i < spans.length; i++)
        {
            count++;
            if (spans[i].style.backgroundColor != div.style.backgroundColor)
            {
                return count;
            }
        }
    }

   return -1;
}

/**
选择指定序号的结果条目
*/
function setSelectedSpan2(div2, spanNum2)
{
    var count = -1;
    var thisSpan;
    var spans = div2.getElementsByTagName("div");
    if (spans)
    {
        for (var i = 0; i < spans.length; i++)
        {
            if (++count == spanNum2)
            {
                _highlightResult2(spans[i]);
                thisSpan = spans[i];
            }
            else
            {
               _unhighlightResult2(spans[i]);
           }
       }
    }
   return thisSpan;
}




