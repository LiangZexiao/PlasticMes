<%@ Page Language="C#" AutoEventWireup="true" CodeFile="iPadCipin.aspx.cs" Inherits="easyUI_iPad" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <link href="themes/default/easyui.css" rel="stylesheet" />
    <link href="themes/icon.css" rel="stylesheet" />
    <script src="js/jquery-1.8.2.min.js"></script>
    <script src="js/jquery.easyui.min.js"></script>
    <style type="text/css">
        body{
            text-align: center;
        }
        #test{ 
                
        }
        .label{
            font-size:40px;
        }
        td{
            width:auto;
            height:auto;
            border:outset;
        }
    </style>

    <script type="text/javascript">
        var searchName;
        var searchValue;
        var addOrUpdate;
        function search(value, name) {
            //alert("搜索的类型为：" + name + "***值为：" + value);
            if (value != null && value != "") {
                $.ajax({
                    type: 'POST',
                    url: "iPadCipin.aspx?name=" + name + "&value=" + value+"&time="+new Date(),
                    success: function (backData) {
                        // alert("您输入的信息有误！");
                        if (backData == "fail") {
                            $("#inputProductName").val("");
                            $("#inputPerson").val("");
                            $("#inputTotal").val("");
                            $("#inputGoodNumber").val("");
                            $("#inputBadNumber").val("");
                            var table = document.getElementById("mainTable");
                            table.innerHTML = "";
                            $.messager.alert('警告', '您输入的信息有误！');
                        }else{
                            var data = JSON.parse(backData);
                            searchName = name;
                            searchValue = value;
                            addOrUpdate = data.AddOrUpdate;
                            //alert(data);
                            //****************************
                            var table = document.getElementById("mainTable");
                            var n = 0;
                            var code = "";
                            while (n * n < data.ColumnsNameCH.length) {
                                n++;
                            }
                            //alert(n);
                            for (var i = 0; i < data.ColumnsNameCH.length; i++) {
                                //alert(data.ColumnsNameCH[i] + ":" + data.ColumnsName[i + 3]);
                                if (i % n == 0) {
                                    code += "<TR>";
                                }
                                code += "<td><label for='" + data.ColumnsName[i + 3] + "' class='label'>" + data.ColumnsNameCH[i] + "：</label><input id='CP" + data.ColumnsName[i + 3] + "' name='" + data.ColumnsName[i + 3] + "' class='easyui-numberspinner' style='font-size:40px;width:100px;height:100px'/> </td>";
                                //code += "<td>" + data.Name[i] + "</td>";
                                if ((i + 1) % n == 0) {
                                    code += "</TR>";
                                }
                            }
                            code += "<TR><td colspan='" + n + "' style='text-align:center'><a id='btn' href='#' class='easyui-linkbutton' onclick='onSubmit()' style='font-size:50px;overflow:hidden;line-height:50px;width:200px'><label style='font-size:50px;line-height:50px;'>提交</label></a></td></TR>"
                            table.innerHTML = code;
                            $('.easyui-numberspinner').numberspinner({
                                min: 0,
                                max: 100,
                                //  editable: false
                            });
                            $('.easyui-numberspinner').spinner({
                                increment: 10,
                                width: 100
                            });
                            $('#btn').linkbutton({

                            });
                            var total = 0;
                            for (var i = 0; i < data.ColumnsNameCH.length; i++) {
                                if (addOrUpdate == "add") {
                                    $("#CP" + data.ColumnsName[i + 3]).numberspinner('setValue', 0);
                                }
                                else if (addOrUpdate == "update") {
                                    $("#CP" + data.ColumnsName[i + 3]).numberspinner('setValue', parseInt(data.ColumnsValue[i + 3]));
                                    total += parseInt(data.ColumnsValue[i + 3]);
                                }

                            }
                        //****************************
                            $("#inputProductName").val(data.ProductDesc);
                            $("#inputPerson").val(data.ColumnsValue[19]);
                            $("#inputTotal").val(data.DispachNum);
                            $("#inputGoodNumber").val(data.Do_Num);
                            $("#inputBadNumber").val(total);
                            
                            if (addOrUpdate == "add") {
                                $.messager.alert('提示', '请录入次品记录！');
                            }
                        }
                    }
                });
            } else {
                $.messager.alert('警告', '请输入派工单号或者机器编号！');
            }
            
        }
        function onSubmit() {
            
            $('#ff').form('submit', {    
                url: "iPadCipin.aspx?searchName=" + searchName + "&searchValue=" + searchValue + "&addOrUpdate=" + addOrUpdate + "&time=" + FormatDate(),
                onSubmit: function(param){    
            
                },    
                success: function (data) {
                    if (data == "update success") {
                        $.messager.alert('成功', '修改成功！');
                    } else if (data == "add success") {
                        $.messager.alert('成功', '录入成功！');
                        addOrUpdate = "update";
                    } else if(data == "fail")
                    {
                        $.messager.alert('警告', '请确保输入信息正确！');
                    }
                    
                   
                }    
            });  
        }

        function FormatDate() {
            var date = new Date();
            return date.getFullYear() + "-" + (date.getMonth() + 1) + "-" + date.getDate() + " " + date.getHours()+":"+date.getMinutes()+":"+date.getSeconds();
        }
    </script>
</head>
<body>
        <div id="test" data-options="fit:true" id="cc" class="easyui-layout" style="width:1000px;height:700px;text-align:center;">   
        <!-- 区域面板 -->
	    <div data-options="region:'north',title:'输入条件',split:false,collapsible:false" style="height:50px;margin:0 auto">
            
                <input id="ss" class="easyui-searchbox" style="width:300px;" data-options="menu:'#mm',searcher:search,prompt:'请输入！'" />
                <div id="mm" style="width:120px;"> 
                <div data-options="name:'DispatchNo'">派工单号</div> 
                <div data-options="name:'MachineNo'">机器编号</div> 
                </div>
        </div>  
         
	        <div data-options="region:'center',title:'派工单信息',split:false,collapsible:false" style="height:50px;">
                    <div style="float:left">   
                        <label for="productName">产品名称:</label>   
                        <input id="inputProductName" class="easyui-validatebox" type="text" name="productName" disabled="disabled"/>   
                    </div>   
                    <div style="float:left">   
                        <label for="person">&nbsp;&nbsp; 操作工:</label>   
                        <input id="inputPerson" class="easyui-validatebox" type="text" name="person" />   
                    </div> 
                    <div style="float:left">   
                        <label for="total">&nbsp;&nbsp; 生产总量:</label>   
                        <input id="inputTotal" class="easyui-validatebox" type="text" name="total" disabled="disabled"/>   
                    </div> 
                    <div style="float:left">   
                        <label for="goodNumber">&nbsp;&nbsp; 良品数:</label>   
                        <input id="inputGoodNumber" class="easyui-validatebox" type="text" name="total"  disabled="disabled"/>   
                    </div> 
                    <div style="float:left">   
                        <label for="badNumber">&nbsp;&nbsp; 次品数:</label>   
                        <input id="inputBadNumber" class="easyui-validatebox" type="text" name="total" disabled="disabled"/>   
                    </div> 
	        </div>   

             <div id="blxx" data-options="region:'south',title:'不良信息',split:false,collapsible:false" style="height:630px;align-self:center">
                 <form id="ff" method="post">  
                     <table id ="mainTable" style="text-align:right;width:65%">
                     </table>
                 </form>  
                
             </div> 
    </div>
</body>
</html>
