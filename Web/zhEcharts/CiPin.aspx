<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CiPin.aspx.cs" Inherits="zhEcharts_CiPin" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <script src="js/jquery-1.8.2.min.js"></script>
    <script src="js/echarts.js"></script>
    <script src="theme/dark.js"></script>
</head>
<body>
    <script type="text/javascript">
        $.ajax({
            type: 'POST',
            url: "CiPin.aspx?value1=1",
            success: function (backData, textStatus, XMLResponse) {
                var data = JSON.parse(backData);
                var total = 0;
                for (var i = 0; i < data.Value.length; i++) {
                    total += parseInt(data.Value[i]);
                }
                var myChart1 = echarts.init(document.getElementById('main1'), 'dark');
                myChart1.setOption({
                    title: {
                        text: '次品分析',
                        subtext: '总数量'+total+'个',
                        x: 'center'
                    },
                    tooltip: {
                        trigger: 'item',
                        formatter: "{a} <br/>{b} : {c} 个 ({d}%)"
                    },
                    legend: {
                        orient: 'vertical',//垂直放置   也可以水平
                        //                              left: 'left',//放置到左侧
                        x: 'left',
                        y: 'top',
                        itemGap: 10,//图例间距
                        itemWidth: 30,  //图例中图形的宽
                        itemHeight: 20,  //图例中图形的高
                        textStyle: {
                            color: 'yellow'  //设置图例文字的颜色
                        },

                        selectedMode: 'multiple',//图例开关初始多选mutiple 单选single
                /*        selected: {//初始默认选择
                            '色差': false  //初始色差不显示
                        },*/
                        data: data.Name//data中有icon属性 可以指定一张图片 用于柱形图 
                        //图例还有自动换行 手动换行 自己去了解
                    },
                    series: [
                        {
                            name: '次品类型',
                            type: 'pie',
                            radius: ['20%', '55%'],//'55%'饼图的半径   [5,'55%']内半径为5px
                            center: ['50%', '60%'],//饼图中心x,y位置
                            startAngle: 0,//默认90
                            clockWise: false,//逆时针  默认true顺时针
                            //roseType:'area',//南丁格尔图 radius比例越大半径越长 area面积模式
                            itemStyle: {
                                normal: {
                                    borderColor: 'white',
                                    borderWidth: 2,
                                    label: {
                                        show: true,
                                        position: 'outer',
                                        formatter: "{b} : {c}个 ({d}%)"
                                    },
                                    labelLine: {
                                        show: true
                                    }
                                }
                            },
                            selectedMode: 'single',//鼠标选择single单选
                            selectedOffset: 50,//鼠标选中后弹出5像素距离
                            data: [
                                { value: parseInt(data.Value[0]), name: data.Name[0] },
                                { value: parseInt(data.Value[1]), name: data.Name[1] },
                                { value: parseInt(data.Value[2]), name: data.Name[2] },
                                { value: parseInt(data.Value[3]), name: data.Name[3] },
                                { value: parseInt(data.Value[4]), name: data.Name[4] },
                                { value: parseInt(data.Value[5]), name: data.Name[5] },
                                { value: parseInt(data.Value[6]), name: data.Name[6] },
                                { value: parseInt(data.Value[7]), name: data.Name[7] },
                                { value: parseInt(data.Value[8]), name: data.Name[8] },
                                { value: parseInt(data.Value[9]), name: data.Name[9] },
                                { value: parseInt(data.Value[10]), name: data.Name[10] },
                                { value: parseInt(data.Value[11]), name: data.Name[11] },
                                { value: parseInt(data.Value[12]), name: data.Name[12] },
                                { value: parseInt(data.Value[13]), name: data.Name[13] },
                            ]

                        },

                    ]
                });
            }

        });

    </script>
    <form id="form1" runat="server">
    <div>
        <div id="main1" style="width: 800px;height:600px;">
        </div>
    </div>
    </form>
</body>
</html>
