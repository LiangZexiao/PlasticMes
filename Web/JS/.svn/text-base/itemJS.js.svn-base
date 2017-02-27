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
var queryField;

// 下拉区ID
var divName;

// IFrame名称
var ifName;

// 记录上次选择的值
var lastVal = "";

// 当前选择的值
var val = "";

// 显示结果的下拉区
var globalDiv;

// 下拉区是否设置格式的标记
var divFormatted = false;

//哪个类的实例
var newById;

//给哪个控件赋值
var newSetById;

var otherById ;

var otherById2;

var otherById3;

var otherById4;

var otherById5;


/**
InitQueryCode函数必须在<body onload>事件的响应函数中调用，其中：
queryFieldName为文本框控件的ID，
hiddenDivName为显示下拉区div的ID
*/
function InitQueryCode(queryFieldName, hiddenDivName)
{

   // 指定文本输入框的onblur和onkeydown响应函数
    queryField = document.getElementById(queryFieldName);
    queryField.onblur = hideDiv;
    //queryField.onkeydown = keypressHandler;

    // 设置queryField的autocomplete属性为"off"
    queryField.autocomplete = "off";

    // 如果没有指定hiddenDivName，取默认值"querydiv"
    if (hiddenDivName)
    {
        divName = hiddenDivName;
    }
    else
    {
        divName = "querydiv";
    }

   // IFrame的name
    ifName = "queryiframe";

   // 100ms后调用mainLoop函数
    setTimeout("mainLoop()", 1000);
}

/**
获取下拉区的div,如果没有则创建之
*/
function getDiv (divID)
{
    if (!globalDiv)
    {
        // 如果div在页面中不存在，创建一个新的div
        if (!document.getElementById(divID))
        {
            var newNode = document.createElement("div");
            newNode.setAttribute("id", divID);
            document.body.appendChild(newNode);
        }

        // globalDiv设置为div的引用       
        globalDiv = document.getElementById(divID);
        // 计算div左上角的位置       
        var x = queryField.offsetLeft;
        var y = queryField.offsetTop + queryField.offsetHeight;
        var parent = queryField;
        while (parent.offsetParent)
        {
            parent = parent.offsetParent;
            x += parent.offsetLeft;
            y += parent.offsetTop;
        }

        // 如果没有对div设置格式，则为其设置相应的显示样式
        if (!divFormatted)
        {
            globalDiv.style.backgroundColor = DIV_BG_COLOR;
            globalDiv.style.fontFamily = DIV_FONT;
            globalDiv.style.padding = DIV_PADDING;
            globalDiv.style.border = DIV_BORDER;
            globalDiv.style.width =document.getElementById("search").style.width;// "100px";
            globalDiv.style.fontSize = "13px";
            globalDiv.style.height="120px";
            globalDiv.style.overflow="auto";
//            globalDiv.style.overflow-x="hidden";
//            globalDiv.style.overflow-y="auto";

            globalDiv.style.position = "absolute";
            globalDiv.style.left = x + "px";
            globalDiv.style.top = y + "px";
            globalDiv.style.visibility = "hidden";
            globalDiv.style.zIndex = 10000;

            divFormatted = true;
        }
    }

    return globalDiv;
}

/**
根据返回的结果集显示下拉区
*/
function showQueryDiv(resultArray)
{
   // 获取div的引用
    var div = getDiv(divName);
    // 如果div中有内容，则删除之
    while (div.childNodes.length > 0)
        div.removeChild(div.childNodes[0]);
        
        // 依次添加结果
        if(resultArray!=null)
        {
            for (var i = 0; i < resultArray.length; i++)
            {
               // 每一个结果也是一个div
                var result = document.createElement("div");
                // 设置结果div的显示样式
                result.style.cursor = "pointer";
                result.style.padding = "2px 0px 2px 0px";
                // 设置为未选中
                _unhighlightResult(result);
                
                // 设置鼠标移进、移出等事件响应函数
                result.onmousedown = selectResult;
                result.onmouseover = highlightResult;
                result.onmouseout = unhighlightResult;


                // 结果的文本是一个span
                var result1 = document.createElement("span");
                // 设置文本span的显示样式
                result1.className = "result1";
                result1.style.textAlign = "left";
                result1.style.fontWeight = "bold";
                result1.innerHTML = resultArray[i];
               
                // 将span添加为结果div的子节点
                result.appendChild(result1);
               
                // 将结果div添加为下拉区的子节点
                div.appendChild(result);
            }
            //结果大于7条时，用滚动条
            if(resultArray.length>7)
            {
                //var e=document.getElementById("search_suggest") 
                document.getElementById(divName).scrollTop=document.getElementById(divName).scrollHeight;
            }
            

        // 如果结果集不为空，则显示，否则不显示
        showDiv(resultArray.length > 0);
        }
        

}

/**
用户单击某个结果时，将文本框的内容替换为结果的文本，
并隐藏下拉区
*/
function selectResult()
{
    _selectResult(this);
}


/**
根据选择结果给其他文本框赋值
*/
function _innerTexts(arrLsit,newSetByIdwws)
{
    var innText="";
    document.getElementById(newSetByIdwws).innerText="";
    for (var i = 0; i < arrLsit.length; i++)
    {
     innText +=arrLsit[i];
    }
    document.getElementById(newSetByIdwws).innerText=innText;
}
/**
当鼠标移到某个条目之上时，高亮显示该条目
*/
function highlightResult()
{
    _highlightResult(this);
}

function _highlightResult(item)
{
    item.style.backgroundColor = DIV_HIGHLIGHT_COLOR;
}

/**
当鼠标移出某个条目时，正常显示该条目
*/
function unhighlightResult()
{
    _unhighlightResult(this);
}

function _unhighlightResult(item)
{
    item.style.backgroundColor = DIV_BG_COLOR;
}

/**
显示/不显示下拉区
*/
function showDiv (show)
{
    var div = getDiv(divName);
    if (show)
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
    
    adjustiFrame();
}

/**
隐藏下拉区
*/
function hideDiv ()
{
    showDiv(false);
}

/**
调整IFrame的位置，这是为了解决div可能会显示在输入框后面的问题
*/
function adjustiFrame()
{
    // 如果没有IFrame，则创建
    if (!document.getElementById(ifName))
    {
        var newNode = document.createElement("iFrame");
        newNode.setAttribute("id", ifName);
        newNode.setAttribute("src", "javascript:false;");
        newNode.setAttribute("scrolling", "no");
        newNode.setAttribute("frameborder", "0");
        document.body.appendChild(newNode);
    }

    iFrameDiv = document.getElementById(ifName);
    var div = getDiv(divName);

    // 调整IFrame的位置与div重合，并在div的下一层 
    try
    {
        iFrameDiv.style.position = "absolute";
        iFrameDiv.style.width = div.offsetWidth;
        iFrameDiv.style.height = div.offsetHeight;
        iFrameDiv.style.top = div.style.top;
        iFrameDiv.style.left = div.style.left;
        iFrameDiv.style.zIndex = div.style.zIndex - 1;
        iFrameDiv.style.visibility = div.style.visibility;
    }
    catch (e)
    {
    }
}


/**
获取当前选中的条目的序号
*/
function getSelectedSpanNum(div)
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
function setSelectedSpan(div, spanNum)
{
    var count = -1;
    var thisSpan;
    var spans = div.getElementsByTagName("div");
    if (spans)
    {
        for (var i = 0; i < spans.length; i++)
        {
            if (++count == spanNum)
            {
                _highlightResult(spans[i]);
                thisSpan = spans[i];
            }
            else
            {
               _unhighlightResult(spans[i]);
           }
       }
    }
   return thisSpan;
}
//创建XMLHttpRequest对象实例的函数   
function createXmlHttpRequestObject()   
{   
    //用于存储XMLHTTPREQUEST对象的引用   
    var xmlHttp;   
    //try程序段将适应除了IE6及其更早版版本歪的所有浏览器   
    try   
     {   
        //尝试创建XMLHTTPREQUEST对象   
         xmlHttp = new XMLHttpRequest();   
     }   
     catch(e)   
     {   
        //假设是IE6或其更早版本   
        var XmlHttpVersions = new Array("MSXML2.XMLHTTP.6.0","MSXML2.XMLHTTP.5.0","MSXML2.XMLHTTP.4.0","MSXML2.XMLHTTP.3.0","MSXML2.XMLHTTP","Microsoft.XMLHTTP");   
        //顺序尝试创建每一个对象，直到成功为止   
        for(var i=0; i<XmlHttpVersions.length && !xmlHttp; i++)   
         {   
            try   
             {   
                //尝试创建XMLHTTPREQUEST对象   
                 xmlHttp = new ActiveXObject(XmlHttpVersions[i]);   
             }   
            catch(e){}//忽略产生的错误   
         }   
     }   
    //返回已经创建的对象，或显示错误信息   
    if(!xmlHttp)   
    {
        alert("Error creating the XMLHttpRequest object.");   
    }
    else   
    {
         return xmlHttp;   
    }
}
var xml;
function SendRequest(obj)
{
    xml=createXmlHttpRequestObject();
    url="GetName.ashx?UserId="+obj.value;
    xml.open("GET",url,true);
    xml.onreadystatechange=GetResponse;
    xml.send(null);
}
function GetResponse()
{
    if (xml.readyState == 4) 
    {
        if (xml.status == 200) 
        {
            var response = xml.responseText;
            var GetName=document.getElementById("GetName");
            GetName.innerText=response;
        }
    }
}