<%@ Page Language="C#" AutoEventWireup="true" CodeFile="iPad.aspx.cs" Inherits="zhEcharts_iPad" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <link href="themes/default/easyui.css" rel="stylesheet" />
    <link href="themes/icon.css" rel="stylesheet" />
    <script src="js/jquery-1.8.2.min.js"></script>
    <script src="js/jquery.easyui.min.js"></script>

    <script type="text/javascript">
        function doDispacherNo() {
            var dispacherNo = $("#dispacherNo").text;
            $.ajax({
                type: 'POST',
                url: "iPad.aspx?dispacherNo=" + dispacherNo,
                success: function (backData, textStatus, XMLResponse) {
                    if (backData != null) {
                        
                    } else {
                        alert("您输入的派工编号错误！");
                    }
                }
            });
        };
        
        $('#p').panel({
            width: 500,
            height: 150,
            title: 'My Panel',
            tools: [{
                iconCls: 'icon-add',
                handler: function () { alert('new') }
            }, {
                iconCls: 'icon-save',
                handler: function () { alert('save') }
            }]
        });
    </script>
</head>
<body>
    <div id="p" style="padding:10px;">    
    <p>panel content.</p>    
    <p>panel content.</p> 
        <a id="btn-find" class="easyui-linkbutton" data-options="iconCls:'icon-search'">
			查询</a>   
    </div>    
   

    <!--<form id="form1" runat="server"></form>-->
</body>
</html>
