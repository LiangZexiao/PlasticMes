var PAGE_SIZE = 20;
Ext.QuickTips.init();
Ext.form.Field.prototype.msgTarget = 'side';

function getDictStore(dictType) {
    var proxy = new Ext.data.HttpProxy({ url: "../Main.aspx?cmd=GetDictList&isAjax=1&Type=" + dictType });
    var reader = new Ext.data.JsonReader(
        {},
        [
            { name: "Code", type: "string", mapping: "Code" },
            { name: "Name", type: "string", mapping: "Name" }
        ]);

    var store = new Ext.data.Store({
        reader: reader,
        proxy: proxy,
        autoLoad: true
    });
    return store;
}
function getZbBatchStoreEx(zbType) {
    var url = "../Zbp/BatchDefList.aspx?cmd=GetBatchList&isAjax=1";
    url += "&ZbType=" + zbType;
    var proxy = new Ext.data.HttpProxy({ url: url });
    var reader = new Ext.data.JsonReader(
        {},
        [
            { name: "Code", type: "string", mapping: "Code" },
            { name: "Name", type: "string", mapping: "Name" }
        ]);

    var store = new Ext.data.Store({
        reader: reader,
        proxy: proxy,
        autoLoad: true
    });
    return store;
}
function getCbZbProjectStore() {
    var proxy = new Ext.data.HttpProxy({ url: "../Main.aspx?cmd=GetCbZbProjectList&isAjax=1" });
    var reader = new Ext.data.JsonReader(
        {},
        [
            { name: "Code", type: "string", mapping: "Code" },
            { name: "Name", type: "string", mapping: "Name" }
        ]);

    var store = new Ext.data.Store({
        reader: reader,
        proxy: proxy,
        autoLoad: true
    });
    return store;
}

function getSpecTypeStore() {
    var proxy = new Ext.data.HttpProxy({ url: "../Rsp/SpecTypeMap.aspx?cmd=GetSpecTypeList&isAjax=1" });
    var reader = new Ext.data.JsonReader(
        {},
        [
            { name: "Code", type: "string", mapping: "Code" },
            { name: "Name", type: "string", mapping: "Name" }
        ]);

    var store = new Ext.data.Store({
        reader: reader,
        proxy: proxy,
        autoLoad: true
    });
    return store;
}

function getTaskDictStore(dictType) {
    var proxy = new Ext.data.HttpProxy({ url: "../Main.aspx?cmd=GetTaskDictList&isAjax=1&Type=" + dictType });
    var reader = new Ext.data.JsonReader(
        {},
        [
            { name: "Code", type: "string", mapping: "Code" },
            { name: "Name", type: "string", mapping: "Name" }
        ]);

    var store = new Ext.data.Store({
        reader: reader,
        proxy: proxy,
        autoLoad: true
    });
    return store;
}

function getDictStoreEx(dictType, compId) {
    var proxy = new Ext.data.HttpProxy({ url: "../Main.aspx?cmd=GetDictList&isAjax=1&Type=" + dictType });
    var reader = new Ext.data.JsonReader(
        {},
        [
            { name: "Code", type: "string", mapping: "Code" },
            { name: "Name", type: "string", mapping: "Name" }
        ]);

    var store = new Ext.data.Store({
        reader: reader,
        proxy: proxy,
        autoLoad: true,
        listeners: {
            load: function() {
                Ext.getCmp(compId).setValue(Ext.getCmp(compId).getValue());
            }
        }
    });
    return store;
}

function getTplStore(projectType, isCurrTpl, disStatus, projectYear, batchId, isReal) {
    var reqUrl = "../Tpl/ProjectTplList.aspx?cmd=GetTplList&isAjax=1";
    reqUrl += "&ProjectType=" + projectType;
    reqUrl += "&IsCurrTpl=" + isCurrTpl;
    reqUrl += "&DisStatus=" + disStatus;
    reqUrl += "&ProjectYear=" + projectYear;
    reqUrl += "&BatchId=" + batchId;
    reqUrl += "&IsReal=" + isReal;

    var proxy = new Ext.data.HttpProxy({ url: reqUrl });
    var reader = new Ext.data.JsonReader(
        {},
        [
            { name: "Code", type: "string", mapping: "Code" },
            { name: "Name", type: "string", mapping: "Name" }
        ]);

    var store = new Ext.data.Store({
        reader: reader,
        proxy: proxy,
        autoLoad: true
    });
    return store;
}

function refreshTplStore(store, projectType, isCurrTpl, disStatus, projectYear, batchId, isReal) {
    var reqUrl = "../Tpl/ProjectTplList.aspx?cmd=GetTplList&isAjax=1";
    reqUrl += "&ProjectType=" + projectType;
    reqUrl += "&IsCurrTpl=" + isCurrTpl;
    reqUrl += "&DisStatus=" + disStatus;
    reqUrl += "&ProjectYear=" + projectYear;
    reqUrl += "&BatchId=" + batchId;
    reqUrl += "&IsReal=" + isReal;

    var proxy = new Ext.data.HttpProxy({ url: reqUrl });
    store.proxy = proxy;
    store.load();
}
function refreshTplStore1(store, projectType, isCurrTpl, disStatus, projectYear,projectMonth, batchId, isReal) {
    var reqUrl = "../Tpl/ProjectTplList1.aspx?cmd=GetTplList&isAjax=1";
    reqUrl += "&ProjectType=" + projectType;
    reqUrl += "&IsCurrTpl=" + isCurrTpl;
    reqUrl += "&DisStatus=" + disStatus;
    reqUrl += "&ProjectYear=" + projectYear;
    reqUrl += "&ProjectMonth=" + projectMonth;
    reqUrl += "&BatchId=" + batchId;
    reqUrl += "&IsReal=" + isReal;

    var proxy = new Ext.data.HttpProxy({ url: reqUrl });
    store.proxy = proxy;
    store.load();
}
function getYearStore() {
    var proxy = new Ext.data.HttpProxy({ url: "../Main.aspx?cmd=GetYearList&isAjax=1" });
    var reader = new Ext.data.JsonReader(
        {},
        [
            { name: "Code", type: "string", mapping: "Code" },
            { name: "Name", type: "string", mapping: "Name" }
        ]);

    var store = new Ext.data.Store({
        reader: reader,
        proxy: proxy,
        autoLoad: true
    });
    return store;
}

function getMonthStore() {
    var proxy = new Ext.data.MemoryProxy([{ Code: '01', Name: '01' }, { Code: '02', Name: '02' }, { Code: '03', Name: '03' }, { Code: '04', Name: '04' }, { Code: '05', Name: '05' }, { Code: '06', Name: '06' }, { Code: '07', Name: '07' }, { Code: '08', Name: '08' }, { Code: '09', Name: '09' }, { Code: '10', Name: '10' }, { Code: '11', Name: '11' }, { Code: '12', Name: '12'}]);
    var reader = new Ext.data.JsonReader(
        {},
        [
            { name: "Code", type: "string", mapping: "Code" },
            { name: "Name", type: "string", mapping: "Name" }
        ]);

    var store = new Ext.data.Store({
        reader: reader,
        proxy: proxy,
        autoLoad: true
    });
    return store;
}

function getRoleStore() {
    var proxy = new Ext.data.HttpProxy({ url: "../Sys/UserSel.aspx?cmd=GetRoleList&isAjax=1" });
    var reader = new Ext.data.JsonReader(
        {},
        [
            { name: "Code", type: "string", mapping: "Code" },
            { name: "Name", type: "string", mapping: "Name" }
        ]);

    var store = new Ext.data.Store({
        reader: reader,
        proxy: proxy,
        autoLoad: true
    });
    return store;
}

function getCbBatchStore() {
    var proxy = new Ext.data.HttpProxy({ url: "../Cbp/BatchDefList.aspx?cmd=GetBatchList&isAjax=1" });
    var reader = new Ext.data.JsonReader(
        {},
        [
            { name: "Code", type: "string", mapping: "Code" },
            { name: "Name", type: "string", mapping: "Name" }
        ]);

    var store = new Ext.data.Store({
        reader: reader,
        proxy: proxy,
        autoLoad: true
    });
    return store;
}

function getZbBatchStore() {
    var proxy = new Ext.data.HttpProxy({ url: "../Zbp/BatchDefList.aspx?cmd=GetBatchList&isAjax=1" });
    var reader = new Ext.data.JsonReader(
        {},
        [
            { name: "Code", type: "string", mapping: "Code" },
            { name: "Name", type: "string", mapping: "Name" }
        ]);

    var store = new Ext.data.Store({
        reader: reader,
        proxy: proxy,
        autoLoad: true
    });
    return store;
}

function getCondition(panel) {
    var hiddenArray = panel.findByType("hidden");
    var textfieldArray = panel.findByType("textfield");
    var comboArray = panel.findByType("combo");

    var conditionStr = "";

    if (hiddenArray != null && hiddenArray.length > 0) {
        for (var i = 0; i < hiddenArray.length; i++) {
            conditionStr += "&" + hiddenArray[i].name + "=" + encodeURI(hiddenArray[i].getValue());
        }
    }

    if (textfieldArray != null && textfieldArray.length > 0) {
        for (var i = 0; i < textfieldArray.length; i++) {
            conditionStr += "&" + textfieldArray[i].name + "=" + encodeURI(textfieldArray[i].getValue());
        }
    }

    return conditionStr;
}


function failure(form, action) {
    switch (action.failureType) {
        case Ext.form.Action.CLIENT_INVALID:
            Ext.Msg.alert("错误提示", "数据验证出错，请检查录入是否正确。");
            break;
        case Ext.form.Action.CONNECT_FAILURE:
            Ext.Msg.alert("错误提示", "连接服务器出错，请检查网络。");
            break;
        case Ext.form.Action.SERVER_INVALID:
            Ext.Msg.alert("错误提示", action.result.msg);
    }
}

function createWind(title, url) {
    EmpWindow = function() {
        EmpWindow.superclass.constructor.call(this, {
            id: "empWindow",
            title: title,
            layout: 'fit',
            width: 970,
            height: 450,
            modal: true,
            closeAction: 'close',
            maximizable: true,
            plain: true,
            buttonAlign: 'center',
            iconCls: 'query-icon',
            html: "<iframe src='" + url + "' width='100%' height='100%' frameborder='0' scrolling='auto'></iframe>"
        });
    };
    Ext.extend(EmpWindow, Ext.Window);

    function closeEmpWindow() {
        Ext.getCmp("empWindow").close();
    }

    var empWindow = new EmpWindow();
    empWindow.show();
    // empWindow.maximize();
}


function createWindEx(title, url, width, height) {
    EmpWindow = function() {
        EmpWindow.superclass.constructor.call(this, {
            id: "empWindow",
            title: title,
            layout: 'fit',
            width: width,
            height: height,
            modal: true,
            closeAction: 'close',
            maximizable: true,
            plain: true,
            buttonAlign: 'center',
            iconCls: 'query-icon',
            html: "<iframe src='" + url + "' width='100%' height='100%' frameborder='0' scrolling='auto'></iframe>"
        });
    };
    Ext.extend(EmpWindow, Ext.Window);

    function closeEmpWindow() {
        Ext.getCmp("empWindow").close();
    }

    var empWindow = new EmpWindow();
    empWindow.show();
    // empWindow.maximize();
}

function getExpander(cols) {
    var html = '<div class="detail-div-x">';

    if (cols != null && cols.length > 0) {
        html += '<table class="detail-table-x">';
        for (var i = 0; i < cols.length; i++) {
            var col = cols[i];
            if (i % 3 == 0) {
                html += '<tr>';
            }

            html += '<th>' + col.label + ':</th>';
            html += '<td>{' + col.value + '}</td>';

            if (i % 3 == 2) {
                html += '</tr>';
            }
        }
        html += "</table>";
    }
    html += '</div>';
    var expander = new Ext.ux.grid.RowExpander({
        tpl: new Ext.Template(
            html
        )
    });
    return expander;
}

function showExecHist(processInstId) {
    createWind("流程执行历史", "../Bpm/BpmExecHistList.aspx?ProcessInstId=" + processInstId);
}



