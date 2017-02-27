<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ExtjsMian.aspx.cs" Inherits="ExtjsMian" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>注塑MES制造执行系统</title>
    <link href="Css/ext.css" rel="stylesheet" type="text/css" />

    <script src="JS/Extjs/jquery.js" type="text/javascript"></script>
    
    <script src="JS/Extjs/jquery-vsdoc.js" type="text/javascript"></script>

    <script type="text/javascript" src="Js/Extjs/adapter/ext/ext-base.js"></script>
     
    <script type="text/javascript" src="Js/Extjs/ext-all.js"></script>
    
    <script type="text/javascript" src="JS/Extjs/src/locale/ext-lang-zh_CN.js"></script>
    
    <script src="JS/Extjs/util.js" type="text/javascript"></script>
    
    <style type="text/css">
        .masterpage-title
        {
            background-position: #1E4176;
            border: 0 none;
            background: #1E4176;
            font: normal 26px tahoma, arial, sans-serif;
            color: white;
            font-weight: bold;
        }
        A.nochange:link
        {
            font-size: 12px;
            color: blue;
            text-decoration: underline;
        }
        A.nochange:visited
        {
            font-size: 12px;
            color: blue;
            text-decoration: underline;
        }
        A.nochange:active
        {
            font-size: 12px;
            color: #0099ff;
            text-decoration: underline;
        }
        A.nochange:hover
        {
            font-size: 12px;
            color: #ff6102;
            text-decoration: underline;
        }
        .jisuantextbox
        {
            background-image: url(Images/Icon/calculator.png); 
            background-repeat:no-repeat;
            background-position:right;
        }
        #login-logo .x-plain-body
        {
            background: #f0edce url( 'Images/Icon/logo.png' ) no-repeat;
        }
        .yonghuming
        {
            background-image: url(Images/Icon/user.png);
            background-repeat: no-repeat;
            padding-left: 20px;
            background-position: 1px 1px;
        }
        .mima
        {
            background-image: url(Images/Icon/lock.png);
            background-repeat: no-repeat;
            padding-left: 20px;
            background-position: 1px 1px;
        }
        .pswkey
        {
            background-image: url(Images/Icon/key.png);
            background-repeat: no-repeat;
            padding-left: 20px;
            background-position: 1px 1px;
        }
        .x-tree-node div.menu-node
        {
            background: #eee url(Images/Icon/cmp-bg.gif) repeat-x;
            margin-top: 1px;
            border-top: 1px solid #ddd;
            border-bottom: 1px solid #ccc;
            padding-top: 2px;
            padding-bottom: 1px; /*font-weight: bold;*/
        }
        .menu-node .x-tree-node-icon
        {
            display: none;
        }
        .menu-node2
        {
            border: 1px solid #fff;
            padding-right: 20px;
            background-position: 1px 1px;
        }
        .menu-node2 li
        {
            background-color: #ffffff;
        }
        .menu-node2 .x-tree-ec-icon
        {
            display: none;
        }
        .house
        {
            background-image: url(Images/Icon/house.png) !important;
        }
        .application_form
        {
            background-image: url(Images/Icon/application_form.png) !important;
        }
        .plugin
        {
            background-image: url(Images/Icon/plugin.png) !important;
        }
    </style>
    
    <script type="text/javascript">
        var tmpUserName = '<%=tmpUserName %>';
        Ext.BLANK_IMAGE_URL = 'JS/Extjs/resources/images/default/s.gif';
        Ext.QuickTips.init();
        Ext.form.Field.prototype.msgTarget = 'side';
        var ALL_PAGESIZE_SETTING = 15;
        function init() {

            // 居顶工具栏
            var topBar = new Ext.Toolbar({
                region: 'north',
                split: true,
                height: 26,
                minSize: 26,
                maxSize: 26,
                margins: '0 5 0 5',
                items: [
                {
                    xtype: 'tbbutton',
                    text: "欢迎您: "+tmpUserName,
                    cls: 'x-btn-text-icon',
                    icon: 'images/Icon/house.png',
                    disabledClass: ''
                }, "->", "-", {
                    xtype: "tbbutton",
                    minWidth: 80,
                    text: "刷新当前页",
                    cls: "x-btn-text-icon",
                    icon: "images/Icon/arrow_refresh.png",
                    handler: function(btn, e) {
                        var tab = tabMain.getActiveTab();
                        window.frames["frame_" + tab.id].location.reload();
                    }
                }, "-", {
                    xtype: "tbbutton",
                    minWidth: 80,
                    text: "全部关闭",
                    cls: "x-btn-text-icon",
                    icon: "images/Icon/stop.png",
                    handler: function(btn, e) {
                        tabMain.items.each(function(item) {
                            if (item.closable) {
                                tabMain.remove(item, true);
                            }
                        })

                    }
                }, "-", {
                    xtype: "tbbutton",
                    minWidth: 80,
                    text: "注销",
                    cls: "x-btn-text-icon",
                    icon: "images/Icon/lock_go.png",
                    handler: function(btn, e) {
                        if (window.confirm("是否注销系统？")) {
                             window.top.location = "login.aspx";
                        }
                    }
                }, "-", {
                    xtype: "tbbutton",
                    minWidth: 80,
                    text: "退出",
                    cls: "x-btn-text-icon",
                    icon: "images/Icon/door_out.png",
                    handler: function(btn, e) {
                        window.close();
                    }
                }
                ]
            });

            var treeloader = new Ext.tree.TreeLoader();
            var rootNode = new Ext.tree.AsyncTreeNode({
                id: '0',
                level: '0',
                expanded: true,
                text: '系统菜单',
                leaf: false,
                cls: 'menu-node'
            });
            // 左边的菜单

            var tree = new Ext.tree.TreePanel({
                title: '功能菜单',
                region: "west",
                autoScroll: true,
                enableTabScroll: true,
                collapsible: true,
                iconCls: 'plugin',
                split: true,
                rootVisible: false,
                lines: false,
                width: 200,
                margins: '0 0 5 5',
                root: rootNode,
                loader: treeloader
            });

            tree.on('beforeload', function(node) {
                 tree.loader.dataUrl = 'ExtjsMian.aspx?cmd=InitTreeLeft&isAjax=1&mlevel=' + node.id;
            });

            // 主显示区
            var tabMain = new Ext.TabPanel({
                id: "Main_TabMain",
                region: "center",
                autoScroll: true,
                enableTabScroll: true,
                activeTab: 0,
                margins: '0 5 5 0',
                frame: true,
                items: [new Ext.Panel({
                    id: 'tab-0001',
                    title: '首页',
                    autoScroll: true,
                    layout: 'fit',
                    border: false,
                    iconCls: 'house',
                    html: '<iframe id="frame_tab-0001" name="frame_tab-0001" scrolling="auto" frameborder="0" width="100%" height="100%" src="HomePage.aspx"></iframe>'
                })
                ]
            });

            tree.on("click", function(node) {
                if (node.leaf) {
                    var panel = new Ext.Panel({
                        id: node.id,
                        title: node.text,
                        autoScroll: true,
                        layout: 'fit',
                        border: false,
                        closable: true,
                        html: '<iframe name="frame_' + node.id + '" id="frame_' + node.id + '" scrolling="auto" frameborder="0" width="100%" height="100%" src="' + node.attributes.url + '"></iframe>'
                    });
                    tabMain.add(panel);
                    tabMain.setActiveTab(panel);
                }
            });

            // 创建框架
            new Ext.Viewport({
                id: "Main_ViewPort",
                layout: 'border',
                items: [tabMain, topBar, tree]
            });
        }

        Ext.onReady(function() {
            init();
        });
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        
    </div>
    </form>
</body>
</html>
