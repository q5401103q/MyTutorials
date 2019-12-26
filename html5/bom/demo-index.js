/**
 * [addLoadEvent 添加页面加载事件]
 * @param {[type]} func [需要挂载到页面加载中的函数]
 */
function addLoadEvent(func) {
    var oldonload = window.onload;
    if (typeof window.onload != "function") {
        window.onload = func;
    } else {
        window.onload = function () {
            oldonload();
            func();
        }
    }
}

/**
 * [initArray 扩展Array对象的方法]
 * @return {[type]} [description]
 */
function initArray() {
    Array.prototype.remove = function (val) {
        var index = this.indexOf(val);
        if (index > -1) {
            this.splice(index, 1);
        }
    };

    Array.prototype.removeById = function (val) {
        if (!val instanceof Object) {
            return;
        }
        if (!val || !val.id) {
            return;
        }
        for (let i = 0; i < this.length; i++) {
            if (val.id == this[i].id) {
                this.splice(i, 1);
                break;
            }
        }
    }

    Array.prototype.indexOfById = function (val) {
        if (!val instanceof Object) {
            return;
        }
        if (!val || !val.id) {
            return;
        }
        for (let i = 0; i < this.length; i++) {
            if (val.id == this[i].id) {
                return i;
            }
        }
        return -1;
    }

    Array.prototype.contains = function (val) {
        var index = this.indexOf(val);
        if (index > -1) {
            return true;
        }
        return false;
    };

    Array.prototype.clear = function (val) {
        this.splice(0);
    }
}

/**
 * [disableContextMenu 禁用默认的右键事件]
 * @return {[type]} [description]
 */
function disableContextMenu() {
    document.oncontextmenu = function () {
        return false;
    }
}

/*测试用*/
function showView(view) {
    console.log("you clicked " + view);
}

/* 根据id获取数据，递归查找 */
function getDataById(data, id) {
    for (var i = 0; i < data.length; i++) {
        if (data[i].id == id) {
            return data[i];
        }
        if (data[i].children && data[i].children.length > 0) {
            var d = getDataById(data[i].children, id);
            if (d != undefined) {
                return d;
            }
        }
    }
}

addLoadEvent(disableContextMenu);
addLoadEvent(initArray);

//定义扩展路径
layui.config({
    base: './layui/lay/modules/'
}).extend({
    //扩展右键
    mouseRightMenu: 'mouseRightMenu/mouseRightMenu'
}).extend({
    //扩展树形表格
    treeTable: 'treeTable/treeTable'
}).use(['element', 'layer', 'util', 'table', 'treeTable', 'mouseRightMenu'], function () {
    //jquery对象
    var $ = layui.jquery;
    //弹出层对象
    var layer = layui.layer;
    //右键菜单对象
    var mouseRightMenu = layui.mouseRightMenu;
    //工具类对象
    var util = layui.util;
    //树形表格对象
    var treeTable = layui.treeTable;
    //表格对象
    var table = layui.table;

    //测试数据
    var data = [{
        id: "000001",
        name: "顶层制造零件a",
        seq: "MPRT-000001",
        classification: "Assembly",
        version: "A",
        generation: "1",
        creator: "Innovator Admin",
        state: "Pending",
        material: "钢质",
        standard: "100*2323",
        weight: "1.34kg",
        timequota: 1.3,
        materialquota: 23.4,
        num: 3,
        root: true,
        icon: "icon-mbom",
        createTime: "2019/11/18 10:44:00",
        children: [{
            id: "000002",
            name: "制造零件A1",
            seq: "MPRT-000002",
            classification: "Component",
            version: "A",
            generation: "2",
            creator: "Innovator Admin",
            state: "Released",
            material: "铁质",
            standard: "HUS-32423",
            weight: "1.34kg",
            timequota: 1.3,
            materialquota: 23.4,
            num: 1,
            root: false,
            icon: "icon-mbom",
            createTime: "2019/11/18 10:44:00",
            children: [{
                id: "000004",
                name: "制造零件A11",
                seq: "MPRT-000004",
                classification: "Component",
                version: "A",
                generation: "2",
                creator: "Innovator Admin",
                state: "Released",
                material: "铁质",
                standard: "HUS-32423",
                weight: "3kg",
                timequota: 2.3,
                materialquota: 26.3,
                num: 3,
                root: false,
                icon: "icon-mbom",
                createTime: "2019/11/18 10:44:00",
                children: [{
                    id: "000007",
                    name: "制造零件A111",
                    seq: "MPRT-000007",
                    classification: "Material",
                    version: "E",
                    generation: "8",
                    creator: "李文英",
                    state: "Released",
                    material: "PCI",
                    standard: "10000*34*32",
                    weight: "0.43kg",
                    timequota: 123,
                    materialquota: 234.23,
                    num: 11,
                    root: false,
                    icon: "icon-ebom",
                    createTime: "2019/11/18 10:44:00",
                    children: []
                }]
            }, {
                id: "000005",
                name: "制造零件A12",
                seq: "MPRT-000005",
                classification: "Material",
                version: "C",
                generation: "2",
                creator: "Innovator Admin",
                state: "Released",
                material: "不锈钢",
                standard: "HUS-32423",
                weight: "5g",
                timequota: 12.3,
                materialquota: 25.3,
                num: 3,
                root: false,
                icon: "icon-ebom",
                createTime: "2019/11/18 10:44:00",
                children: []
            }]
        },
        {
            id: "000003",
            name: "制造零件A2",
            seq: "MPRT-000003",
            classification: "Component",
            version: "D",
            generation: "22",
            creator: "Wang lei",
            state: "Released",
            material: "液体",
            standard: "AUS-SD93-23",
            weight: "2kg",
            timequota: 99,
            materialquota: 23.4,
            num: 1,
            root: false,
            icon: "icon-mbom",
            createTime: "2019/11/18 10:44:00",
            children: [{
                id: "000006",
                name: "制造零件A21",
                seq: "MPRT-000006",
                classification: "Material",
                version: "C",
                generation: "12",
                creator: "Michael",
                state: "Released",
                material: "塑料",
                standard: "无",
                weight: "5g",
                timequota: 12.3,
                materialquota: 25.3,
                num: 6,
                root: false,
                icon: "icon-ebom",
                createTime: "2019/11/18 10:44:00",
                children: []
            }]
        }
        ]
    }];

    var tempid = 1;

    //渲染表格
    var insTb = treeTable.render({
        elem: '#mtree',
        data: data,
        tree: {
            iconIndex: 2
        },
        cellMinWidth: 50,
        cols: [
            { type: 'numbers' },
            { type: 'checkbox' },
            { field: 'seq', title: '物料编码', width: 600 },
            //{ field: 'id', title: 'ID' },
            { field: 'name', title: '名称' },
            { field: 'classification', title: '物料类型' },
            // { field: 'version', title: '版本' },
            // { field: 'generation', title: '版次' },
            // { field: 'creator', title: '创建人' },
            // { field: 'state', title: '状态' },
            // { field: 'material', title: '材料' },
            // { field: 'standard', title: '材料规格' },
            // { field: 'weight', title: '重量' },
            { field: 'timequota', title: '工时定额' },
            { field: 'materialquota', title: '材料定额' },
            { field: 'num', title: '数量' },
            {
                field: 'createTime',
                title: '创建时间',
                templet: function (d) {
                    return util.toDateString(d.createTime);
                },
                width: 180
            }
        ],
        style: 'margin-top:0;',
        even: false
    });

    //默认展开全部树形结构-测试用
    insTb.expandAll();

    //重写行单击事件，更改选中行样式
    treeTable.on('row(mtree)', function (obj) {
        obj.tr.addClass('selected-row').siblings().removeClass('selected-row');
    });
    treeTable.on('row(move_mtree)', function (obj) {
        obj.tr.addClass('selected-row').siblings().removeClass('selected-row');
    });

    //重写右键事件，弹出自定义命令
    treeTable.on('mouseRightMenu(mtree)', function (obj) {
        var data = obj.data;

        var menu_data = [
            { 'data': obj, 'type': 'insertExistingMpart', 'title': '插入已有制造零件', icon: 'layui-icon-add-circle' },
            { 'data': obj, 'type': 'insertNewMpart', 'title': '插入新的制造零件', icon: 'layui-icon-add-circle' },
            { 'data': obj, 'type': 'insertNewMaterial', 'title': '插入新的原材料', icon: 'layui-icon-add-circle' },
            { 'data': obj, 'type': 'deleteMpart', 'title': '删除制造零件', icon: 'layui-icon-delete' },
            { 'data': obj, 'type': 'moveMpart', 'title': '移动制造零件', icon: 'layui-icon-util' },
            { 'data': obj, 'type': 'splitMpart', 'title': '拆分制造零件', icon: 'layui-icon-link' },
            { 'data': obj, 'type': 'checkBom', 'title': '检查责信度', icon: 'layui-icon-list' }
        ];

        mouseRightMenu.open(menu_data, false, function (obj1) {
            console.log(obj1);
        });
    });

    table.render({
        elem: '#split_mtree',
        data: [],
        cellMinWidth: 100, //全局定义常规单元格的最小宽度，layui 2.2.1 新增
        cols: [
            [
                { type: 'numbers', width: 50 },
                { type: 'checkbox', width: 50 },
                { field: 'id', title: 'ID', hide: true },
                { field: 'seq', title: '物料编码', width: 200 },
                { field: 'name', title: '名称', width: 230 },
                { field: 'num', title: '零件数量', width: 152, edit: 'text' }
            ]
        ]
    });

    //编辑单元格
    table.on('edit(split_mtree)', function (obj) {
        // 监听单元格编辑事件
        debugger
        var value = obj.value;

        //输入非法字符时，强制将数量更正为1，并提示错误
        if (!/^[0-9]*$/.test(value)) {
            let tmp = table.cache["split_mtree"];
            let index = tmp.indexOfById(obj.data);
            tmp[index].num = 1;
            layer.msg("请输入正确的数量！");
            table.reload('split_mtree', {
                data: tmp
            });
            return;
        }

        //输入非法数量时，强制将数量更正为1，并提示错误
        let number = parseInt(value);
        if (number < 1 || number > 2000) {
            let tmp = table.cache["split_mtree"];
            let index = tmp.indexOfById(obj.data);
            tmp[index].num = 1;
            layer.msg("请输入正确的数量！");
            table.reload('split_mtree', {
                data: tmp
            });
            return;
        }


    });

    //插入已有制造零件
    $("#btnInsertExistingMpart").click(function () {
        let tmp = insTb.checkStatus();
        if (tmp && tmp.length == 1) {
            let tmpdata = {
                id: tempid,
                name: "制造零件" + tempid,
                seq: "MPRT-" + tempid,
                classification: "Material",
                version: "C",
                generation: "11",
                creator: "Jackal",
                state: "Pending",
                material: "铝合金",
                standard: "2.234-342KSJ",
                weight: "23kg",
                timequota: 0.04,
                materialquota: 0.93,
                num: tempid % 5,
                root: false,
                icon: "icon-mbom",
                createTime: "2019/11/18 10:44:00",
                children: []
            }

            tempid++; //测试用

            tmp[0].children.push(tmpdata);
            insTb.reload();
            insTb.expandAll();
        }
    });

    //插入新的制造零件
    $("#btnInsertNewMpart").click(function () {
        let tmp = insTb.checkStatus();
        if (tmp && tmp.length == 1) {
            let tmpdata = {
                id: tempid,
                name: "制造零件" + tempid,
                seq: "MPRT-" + tempid,
                classification: "Material",
                version: "C",
                generation: "11",
                creator: "Jackal",
                state: "Pending",
                material: "铝合金",
                standard: "2.234-342KSJ",
                weight: "23kg",
                timequota: 0.04,
                materialquota: 0.93,
                num: tempid % 5,
                root: false,
                icon: "icon-mbom",
                createTime: "2019/11/18 10:44:00",
                children: []
            }

            tempid++; //测试用

            tmp[0].children.push(tmpdata);
            insTb.reload();
            insTb.expandAll();
        }
    });

    //插入新的原材料
    $("#btnInsertNewMaterial").click(function () {
        let tmp = insTb.checkStatus();
        if (tmp && tmp.length == 1) {
            let tmpdata = {
                id: tempid,
                name: "制造零件" + tempid,
                seq: "MPRT-" + tempid,
                classification: "Material",
                version: "C",
                generation: "11",
                creator: "Jackal",
                state: "Pending",
                material: "铝合金",
                standard: "2.234-342KSJ",
                weight: "23kg",
                timequota: 0.04,
                materialquota: 0.93,
                num: tempid % 5,
                root: false,
                icon: "icon-ebom",
                createTime: "2019/11/18 10:44:00",
                children: []
            }

            tempid++; //测试用

            tmp[0].children.push(tmpdata);
            insTb.reload();
            insTb.expandAll();
        }
    });

    //删除制造临建
    $("#btnDeleteMpart").click(function () {
        let tmp = insTb.checkStatus();
        if (tmp[0].root) {
            layer.alert('不能删除顶层制造零件', {
                title: '提示'
            });
        }
        if (tmp && tmp.length == 1) {
            let data = insTb.getData();
            let pid = tmp[0].pid;
            let parent = getDataById(data, pid);
            let index = parent.children.indexOf(tmp[0]);
            if (index > -1) {
                parent.children.splice(index, 1);
            }

            let childs = tmp[0].children;
            if (childs && childs.length > 0) {
                for (let i = 0; i < childs.length; i++) {
                    parent.children.push(childs[i]);
                }
            }
            // insTb.update(tmp[0].id, tmp[0].children);
            insTb.reload();
            insTb.expandAll();
        }
    });

    //检查BOM责信度
    $("#btnCheckBom").click(function () {
        layer.open({
            type: 1,
            title: 'BOM责信度检查',
            resize: false,
            skin: 'layer-skin-mouse-right-menu',
            area: ['720px', '530px'],
            shade: ["0.0", '#000'],
            id: 'layer_bom',
            maxHeight: 530, //自定义高度
            btn: [],
            moveType: 1,
            content: $("#bomlist")
        });
    });

    //弹出拆分零件页面
    $("#btnSplitMpart").click(function () {
        let tmp = insTb.checkStatus();
        if (tmp && tmp.length == 1) {
            if (tmp[0].num == 1) {
                layer.msg("数量等于1的零件无法拆分！");
                return;
            }
            if (tmp[0].icon == "icon-mbom") {
                layer.msg("制造零件无法拆分，请选择工程零件！");
                return;
            }
            if (tmp[0].children && tmp[0].children.length > 0) {
                layer.msg("该零件含有子阶零件无法拆分！");
                return;
            }
            $("#txtMpartId").val(tmp[0].id);
            $("#txtMpartName").val(tmp[0].name);
            $("#txtMpartNumber").val(tmp[0].seq);
            $("#txtMpartNum").val(tmp[0].num);

            table.reload('split_mtree', {
                data: []
            });

            layer.open({
                type: 1,
                title: '拆分制造零件',
                resize: false,
                skin: 'layer-skin-mouse-right-menu',
                area: ['720px', '530px'],
                shade: ["0.0", '#000'],
                id: 'layer_split',
                maxHeight: 530,
                btn: ['保存', '取消'],
                btnAlign: 'c',
                moveType: 1,
                content: $("#splitlist"),
                yes: function (index, layeritem) {
                    //拆分后的结果
                    let arr = table.cache["split_mtree"];
                    if (arr && arr.length > 0) {
                        let totalCount = 0;
                        for (let i = 0; i < arr.length; i++) {
                            totalCount += parseInt(arr[i].num);
                        }

                        let count = 0;
                        let countString = $("#txtMpartNum").val();
                        if (countString != null && countString != "") {
                            count = parseInt(countString);
                        }
                        else {
                            layer.msg("拆分后的数量与总的数量不匹配");
                            return;
                        }

                        if (totalCount != count) {
                            layer.msg("拆分后的数量与总的数量不匹配");
                            return;
                        }
                        else {
                            let data = insTb.getData();
                            let pid = tmp[0].pid;
                            let parent = getDataById(data, pid);
                            let pindex = parent.children.indexOf(tmp[0]);
                            if (pindex > -1) {
                                parent.children.splice(pindex, 1);
                            }

                            for (let j = 0; j < arr.length; j++) {
                                arr[j].pid = pid;
                                arr[j].classification = tmp[0].classification;
                                arr[j].version = tmp[0].version;
                                arr[j].generation = tmp[0].generation;
                                arr[j].creator = tmp[0].creator;
                                arr[j].state = tmp[0].state;
                                arr[j].material = tmp[0].material;
                                arr[j].standard = tmp[0].standard;
                                arr[j].weight = tmp[0].weight;
                                arr[j].timequota = tmp[0].timequota;
                                arr[j].materialquota = tmp[0].materialquota;
                                arr[j].root = tmp[0].root;
                                arr[j].icon = tmp[0].icon;
                                arr[j].createTime = tmp[0].createTime;
                                arr[j].children = [];
                                parent.children.push(arr[j]);
                            }

                            insTb.reload();
                            insTb.expandAll();

                            layer.close(index);
                        }
                    }
                    else {
                        layer.msg("未拆分零件");
                        return;
                    }
                }
            });
        } else {
            layer.msg('请先选中一个需要拆分的零件');
        }
    });

    //添加行
    $("#btnInsertLine").click(function () {
        data = {
            id: tempid,
            seq: $("#txtMpartNumber").val(),
            name: $("#txtMpartName").val(),
            num: 1,
        };

        tempid++;

        let arr = table.cache["split_mtree"];
        if (arr) {
            arr.push(data);
        } else {
            arr = data;
        }

        table.reload('split_mtree', {
            data: arr
        });
    });

    //删除行
    $("#btnDeleteLine").click(function () {
        let tmp = table.checkStatus("split_mtree");
        if (tmp.data && tmp.data.length > 0) {
            let arr = table.cache["split_mtree"];
            for (let i = 0; i < tmp.data.length; i++) {
                arr.removeById(tmp.data[i]);
            }

            table.reload('split_mtree', {
                data: arr
            });
        }
    });

    //弹出移动零件页面
    $("#btnMoveMpart").click(function () {
        let tmp = insTb.checkStatus();
        if (tmp && tmp.length == 1) {
            //渲染表格
            var moveTb = treeTable.render({
                elem: '#move_mtree',
                data: data,
                tree: {
                    iconIndex: 2
                },
                cellMinWidth: 50,
                cols: [
                    { type: 'numbers', width: 40 },
                    { type: 'checkbox', width: 48 },
                    { field: 'seq', title: '物料编码', width: 470 },
                    { field: 'name', title: '名称', width: 129 }
                ],
                style: 'margin-top:0;',
                even: false
            });

            moveTb.removeAllChecked();
            moveTb.expandAll();

            layer.open({
                type: 1,
                title: '移动至',
                resize: false,
                skin: 'layer-skin-mouse-right-menu',
                area: ['720px', '530px'],
                shade: ["0.0", '#000'],
                id: 'layer_move',
                maxHeight: 530,
                btn: ['保存', '取消'],
                btnAlign: 'c',
                moveType: 1,
                content: $("#movelist"),
                yes: function (index, layeritem) {
                    let target = moveTb.checkStatus();
                    if (target && target.length == 1) {
                        //tmp[0]原节点
                        //target[0]目标节点
                        let data = insTb.getData();

                        //原父阶移除子节点
                        let parent = getDataById(data, tmp[0].pid);
                        let pindex = parent.children.indexOf(tmp[0]);
                        if (pindex > -1) {
                            parent.children.splice(pindex, 1);
                        }

                        //找到目标节点，插入
                        let targetNode = getDataById(data, target[0].id);
                        targetNode.children.push(tmp[0]);

                        moveTb.reload();
                        moveTb.expandAll();
                        
                        insTb.reload();
                        insTb.expandAll();

                        layer.close(index);
                    }
                    else {
                        layer.msg("请选中一个需要移动至的目标零件");
                    }
                }
            });
        }
        else {
            layer.msg("请先选中一个需要移动的零件");
        }
    });

    // 加载动画效果
    setTimeout(function () {
        $('body').children('.page-loading').hide();
        $('body').removeClass('page-no-scroll');
    }, 150);

});