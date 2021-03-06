layui.define(['jquery', 'layer'], function(exports) {
    var $ = layui.jquery;
    var layer = layui.layer;
    var xx, yy;

    /**
     * [open 打开弹出层]
     * @param  {[type]}   data     弹出层的菜单
     * @param  {[type]}   obj      弹出层的设置
     * @param  {Function} callback 弹出层的回调
     * @return {[type]}            [description]
     */
    function open(data, obj, callback) {
        if (obj == false) {
            obj = {};
        }
        var generatedHeight = calcHeight(data);

        layer.open({
            title: false,
            area: [obj.width || '150px', obj.height || generatedHeight], 	//宽高
            resize: false,													//缩放大小
            offset: calc(xx, yy), 											//坐标，默认鼠标当前
            type: 1,														//1=页面层
            anim: -1,														//弹出动画，无动画
            skin: 'layer-skin-mouse-right-menu', 							//样式类名
            closeBtn: 0, 													//不显示关闭按钮
            shade: ["0.0", '#000'], 										//遮罩
            shadeClose: true, 												//开启遮罩关闭
            maxHeight: obj.maxHeight || generatedHeight, 					//自定义最大高度
            height: obj.height || generatedHeight,							//自定义高度
            content: build_menu_data(data), 								//自定义内容
            success: function(dom, index) {
                $(".mouse-right-menu .enian_menu .text").click(function() {
                    if (callback) {
                        var returnData = $(this).data();
                        if ($(this).children('a').data('type') == 1) {
                            returnData.data = JSON.parse($(this).children('a').html())
                        } else {
                            returnData.data = $(this).children('a').html();
                        }
                        if (callback(returnData) == false) {
                            return;
                        }
                    }
                    layer.close(index)
                })
            }
        });


        /**
         * [calcHeight 动态计算高度]
         * @param  {[type]} data [description]
         * @return {[type]}      [description]
         */
        function calcHeight(data) {
            if (data && data.length > 0) {
                return (data.length * 41) + 'px';
            }
            return '0px';
        }

        /**
         * [calc 计算偏移量]
         * @param  {[type]} x [description]
         * @param  {[type]} y [description]
         * @return {[type]}   [description]
         */
        function calc(x, y) {
            if (x > $(window).width() - 100) {
                x = x - 110;
            }
            if (y > $(window).height() - 150) {
                y = y - 150;
            }
            return [y + 'px', x + 'px'];
        }
    }

    $('body').mousemove(function(e) {
        xx = e.originalEvent.x || e.originalEvent.layerX || 0;
        yy = e.originalEvent.y || e.originalEvent.layerY || 0;
    })
    
    //生成菜单数据
    function build_menu_data(data) {
        var h_son = ''
        for (var i = 0; i < data.length; i++) {
            var dataType = 0; //字符串
            if (typeof(data[i].data) == "object") {
                dataType = 1; //对象
                data[i].data = JSON.stringify(data[i].data);
            }
            h_son += '<div class="enian_menu">';
            h_son += '<div class="text" data-type="';
            h_son += data[i].type;
            h_son += '" data-title="';
            h_son += data[i].title;
            h_son += '">';
            h_son += '<a style="display:none;" data-type="';
            h_son += dataType;
            h_son += '">';
            h_son += data[i].data;
            h_son += '</a>';
            h_son += '<i class="layui-icon '
            h_son += data[i].icon;
            h_son += '"></i>';
            h_son += '<span class="context-item-text">' + data[i].title + '</span>';
            h_son += '</div></div>';
        }
        return '<div class="mouse-right-menu">' + h_son + '</div>';
    }

    var mouseRightMenu = {
        open: open,
        v: function() {
            return '0.1.2019-1-2 19:19:29';
        }
    };
    exports('mouseRightMenu', mouseRightMenu);
});