// JScript 文件



var W = screen.width;//取得屏幕分辨率宽度
var H = screen.height;//取得屏幕分辨率高度
var xid="";

//用M()方法代替document.getElementById(id)
function M(id){
    return document.getElementById(id);
}
//用MC()方法代替document.createElement(t)
function MC(t){
   return document.createElement(t);
};
//判断浏览器是否为IE
function isIE(){
      return (document.all && window.ActiveXObject && !window.opera) ? true : false;
} 
//取得页面的高宽
function getBodySize(){
   var bodySize = [];
   with(document.documentElement) {//document.body.clientWidth
    bodySize[0] = (document.body.scrollWidth>document.body.clientWidth)?document.body.scrollWidth:document.body.clientWidth;//如果滚动条的宽度大于页面的宽度，取得滚动条的宽度，否则取页面宽度
    bodySize[1] = (document.body.scrollHeight>document.body.clientHeight)?document.body.scrollHeight:document.body.clientHeight;//如果滚动条的高度大于页面的高度，取得滚动条的高度，否则取高度
   }
   return bodySize;
}
//创建遮盖层
function popCoverDiv(){
   if (M("cover_div")) {
   //如果存在遮盖层，则让其显示 
    M("cover_div").style.display = 'block';
    with(M("cover_div").style) {
     position = 'absolute';
     background ='#D7D7D7';
     left = '0px';
     top = '0px';
     var bodySize = getBodySize();
     width = bodySize[0] + 'px'
     height = bodySize[1] + 'px';
     zIndex = 0;
     if (isIE()) {
      filter = "Alpha(Opacity=30)";//IE逆境
     } else {
      opacity = 0.3;
     }
    }
   } else {
   //否则创建遮盖层
    var coverDiv = MC('div');
    document.body.appendChild(coverDiv);
    coverDiv.id = 'cover_div';
    with(coverDiv.style) {
     position = 'absolute';
     background ='#D7D7D7';
     left = '0px';
     top = '0px';
     var bodySize = getBodySize();
     width = bodySize[0] + 'px'
     height = bodySize[1] + 'px';
     zIndex = 0;
     if (isIE()) {
      filter = "Alpha(Opacity=30)";//IE逆境
     } else {
      opacity = 0.3;
     }
    }
   }
}




//让登陆层显示为块 
    function showLogin()
    {
                var login=M("login");
            login.style.display = "block";
        }

//设置DIV层的样式
function change(){
      var login = M("login");
      login.style.position = "absolute";
      login.style.border = "1px solid #ededec";
      //login.style.background ="#ff6666";
      //login.style.background-color="red";
      var i=0;
      var bodySize = getBodySize();
      login.style.left = (bodySize[0]-i*i*4)/2+"px";
      login.style.top = (bodySize[1]/2-100-i*i)+"px";
      login.style.width =      i*i*4 + "px";
      login.style.height = i*i*1.5 + "px";
     
      popChange(i);
}
//让DIV层大小循环增大
function popChange(i){
      var login = M("login");
          var bodySize = getBodySize();
      login.style.left = (bodySize[0]-i*i*4)/2+"px";
      login.style.top = (bodySize[1]/2-50-i*i)+"px";
      login.style.width =      i*i*3 + "px";
      login.style.height = i*i*1.5+ "px";
      if(i<=10){
           i++;
           setTimeout("popChange("+i+")",10);//设置超时10毫秒
      }
     // alert("width:"+i*i*4+"height:"+i*i*1.5+"left:"+(bodySize[0]-i*i*4)/2+"top:"+(bodySize[1]/2-100-i*i));
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
var xmlHttp=false;
//打开DIV层
function opens(id)
{
    
    if (M("divdsa")) {
        //如果存在遮盖层，则让其显示 
        M("divdsa").style.display = 'block';     
        // 定义层的样式
        var bodySize = getBodySize();
        M("divdsa").style.position="absolute";
        M("divdsa").style.left="0px";
        M("divdsa").style.top="0px";
        M("divdsa").style.width=bodySize[0] + 'px';
        M("divdsa").style.height=bodySize[1] + 'px';
        M("divdsa").style.border="1px solid #D7D7D7";
        M("divdsa").style.backgroundColor="#D7D7D7";
        M("divdsa").style.zIndex = 0;
        if (isIE()) {
            M("divdsa").style.filter = "Alpha(Opacity=30)";//IE逆境
        } else {
            M("divdsa").style.opacity = 0.3;
        }
        // 定义iframe的样式，宽高与s相同<因为DROPLIST OR SELECT 等控见的TAB键顺序比DIV要高，所以创建一个IFRAME用来遮蔽>
        M('completionFrame').style.width=bodySize[0] + 'px';
        M('completionFrame').style.height=bodySize[1] + 'px';
       // alert( M('completionFrame').width+"和"+M('completionFrame').height);
       //alert( bodySize[0]+"和"+bodySize[1]);

   } else {
        // 创建层
    var iframe_div=document.createElement("DIV"); 
    iframe_div.id='divdsa';
    // 设置层的相关属性
    iframe_div.style.visibility="";
     
    // 定义层的样式
    var bodySize = getBodySize();

    iframe_div.style.position="absolute";
    iframe_div.style.left="0px";
    iframe_div.style.top="0px";
    iframe_div.style.width=bodySize[0] + 'px';
    iframe_div.style.height=bodySize[1] + 'px';
    iframe_div.style.border="1px solid #D7D7D7";
    iframe_div.style.backgroundColor="#D7D7D7";
    iframe_div.style.zIndex = 0;
    if (isIE()) {
        iframe_div.style.filter = "Alpha(Opacity=30)";//IE逆境
    } else {
        iframe_div.style.opacity = 0.3;
    }

    // 生成iframe
    var L=document.createElement("IFRAME");
    L.name="completionFrame";
    L.id="completionFrame";

    // 定义iframe的样式，宽高与s相同
    L.width=iframe_div.style.width;
    L.height=iframe_div.style.height;
    L.style.backgroundColor="#D7D7D7";
    L.style.zIndex = 0;
    if (isIE()) {
        L.style.filter = "Alpha(Opacity=30)";//IE逆境
    } else {
        L.style.opacity = 0.3;
    }
    // 附加L到s
    iframe_div.appendChild(L);

    // 显示s
    document.body.appendChild(iframe_div);
    }

    change();
    showLogin();
    popCoverDiv()
    void(0);//不进行任何操作,如：<a href="#">aaa</a>

    doref(id);  
}

//关闭DIV层
function closes(){
         M('login').style.display = 'none';
         M("cover_div").style.display = 'none';
         M('divdsa').style.display = 'none';
        //void(0);
        xid="";
}


