// JavaScript Document
function OpenMenu(theTd,theMenu)
{
	theTd.background=theMenu.style.display=='none'?'img/menu_bg.jpg':'img/menu_bg1.jpg';
	theMenu.style.display=theMenu.style.display=='none'?'':'none';
	document.all.m.height=document.all.tt.clientHeight-50;
	
	return false;
}
function TabActive(theTd,tabID,frameID,url)
{
	for(var i=0;i<tabID.rows.item(0).cells.length-2;i++)
	{
		tabID.rows.item(0).cells.item(i).background='../images/tab_off.gif';
	}
	theTd.background='../images/tab_on.gif';
	frameID.src=url;
	
	return false;
}

//function TabActive(theTd,tabID)
//{
//	for(var i=0;i<tabID.rows.item(0).cells.length-1;i++)
//	{
//		tabID.rows.item(0).cells.item(i).background='../Image/tabunsel.jpg';
//	}
//	theTd.background='../Image/tabsel.jpg';
//	
////	frameID.src=url;
//	
//	return false;
//}

function WriteCaption(caption)
{
	if (window.parent.name=="index")
	{
		window.parent.document.all.m.height=document.body.clientHeight+20;
		window.parent.document.all.wai.height=document.body.clientHeight+18;
		window.parent.document.all.CurOp.innerHTML=caption; //市场部：咨询管理 --> 咨询记录;
	}
}
function BtnMouseOut(btn)
{
	btn.style.background='url(img/buttonNormal.gif)';
}
function BtnMouseOver(btn)
{
	btn.style.background='url(img/buttonOver.gif)';
	btn.style.cursor="hand";
}
function BtnMouseDown(btn)
{
	btn.style.background='url(img/buttonDown.gif)';
	btn.blur();
}