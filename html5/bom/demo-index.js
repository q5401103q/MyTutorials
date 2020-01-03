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

    Array.prototype.getElementById = function (val) {
        for (let i = 0; i < this.length; i++) {
            if (val == this[i].id) {
                return this[i];
            }
        }
        return null;
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

/**
 * 隐藏页面相关元素
 */
function disablePopupDom() {
    let dom1 = document.getElementById("bomlist");
    let dom2 = document.getElementById("splitlist");
    let dom3 = document.getElementById("movelist");

    dom1.style.display = "none";
    dom2.style.display = "none";
    dom3.style.display = "none";
}

/**
 * 生成随机guid
 */
function getNextId() {
    return 'xxxxxxxx-xxxx-4xxx-yxxx-xxxxxxxxxxxx'.replace(/[xy]/g, function (c) {
        var r = Math.random() * 16 | 0, v = c == 'x' ? r : (r & 0x3 | 0x8);
        return v.toString(16);
    });
}

/**
 * 切换页面显示
 * @param {*} view 被点击的元素id
 */
function showView(view) {
    var elements = document.getElementsByClassName("content");
    for (let i = 0; i < elements.length; i++) {
        if (elements[i].id == view + "_div") {
            elements[i].style = "";
        }
        else {
            elements[i].style = "display:none;";
        }
    }
}

/**
 * 根据id递归查找某个元素
 * @param {*} data 待查找的树形结构
 * @param {*} id 待查找的id
 */
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

/**
 * 遍历结果
 */
var result = [];

/**
 * 访问单个节点
 * @param {*} node 被访问的树节点
 */
function traverseNode2(node) {
    result.push({ name: node.seq, num: node.num });
}

/**
 * 非递归访问树节点
 * @param {*} node 根节点，注意取到数组的根对象，不能取数组
 */
function traverseTree2(node) {
    if (!node) {
        return;
    }

    var stack = [];
    stack.push(node);
    var tmpNode;
    while (stack.length > 0) {
        tmpNode = stack.pop();
        traverseNode2(tmpNode);
        if (tmpNode.children && tmpNode.children.length > 0) {
            var i = tmpNode.children.length - 1;
            for (i = tmpNode.children.length - 1; i >= 0; i--) {
                stack.push(tmpNode.children[i]);
            }
        }
    }
}

/**
 * 清空遍历后的结果集
 */
function clearTraverseResult() {
    result = [];
}

/**
 * 合并bom中相同的元素，根据name判断是否相同
 * @param {*} bom 
 */
function mergebom(bom) {
    var arr = [];

    //合并名称零件
    let currentName = "";
    let currentNum = 0;

    for (let i = 0; i < bom.length; i++) {
        if (currentName != bom[i].name) {
            if (i > 0) {
                arr.push({ name: currentName, num: currentNum });
            }
            currentName = bom[i].name;
            currentNum = bom[i].num;
        } else {
            currentNum += bom[i].num;
        }
    }
    if (currentNum > 0) {
        arr.push({ name: currentName, num: currentNum });
    }
    return arr;
}

/**
 * 比对两个bom的名字和数量，注意比对参数的顺序
 * @param {*} bom1 EBOM
 * @param {*} bom2 MBOM
 */
function comparebom(bom1, bom2) {
    let bom = [];
    let m = 0;
    let n = 0;
    while (m < bom1.length && n < bom2.length) {
        let result = bom1[m].name.localeCompare(bom2[n].name);

        if (result == 0) {
            //相等
            if (bom1[m].num == bom2[n].num) {
                //数量相同-eq
                bom.push({ name1: bom1[m].name, name2: bom2[n].name, num1: bom1[m].num, num2: bom2[n].num, type: "eq" });
            } else {
                //数量不同-neq
                bom.push({ name1: bom1[m].name, name2: bom2[n].name, num1: bom1[m].num, num2: bom2[n].num, type: "neq" });
            }
            m++;
            n++;
        } else if (result > 0) {
            //final1较大
            bom.push({ name1: "", name2: bom2[n].name, num1: 0, num2: bom2[n].num, type: "ru" });
            n++;
        } else if (result < 0) {
            //final1较小
            bom.push({ name1: bom1[m].name, name2: "", num1: bom1[m].num, num2: 0, type: "lu" });
            m++;
        }
    }

    while (m < bom1.length) {
        bom.push({ name1: bom1[m].name, name2: "", num1: bom1[m].num, num2: 0, type: "lu" });
        m++;
    }

    while (n < bom2.length) {
        bom.push({ name1: "", name2: bom2[n].name, num1: 0, num2: bom2[n].num, type: "ru" });
        n++;
    }

    return bom;
}

/**
 * 生成最终的页面dom元素
 * @param {*} bom 含有比对结果的BOM数组
 */
function createCompareResult(bom) {
    //定义左侧列表
    let htmlContent1 = "<ul id='con1'>";
    htmlContent1 += "<div class='compare-title'>EBOM</div>";
    htmlContent1 += "<li class='compare-header'>";
    htmlContent1 += "<div class='partname'>零件名称</div>";
    htmlContent1 += "<div class='partnum'>数量</div>";
    htmlContent1 += "<div class='cl'></div>";
    htmlContent1 += "</li>";
    //定义右侧列表
    let htmlContent2 = "<ul id='con2'>";
    htmlContent2 += "<div class='compare-title'>MBOM</div>";
    htmlContent2 += "<li class='compare-header'>";
    htmlContent2 += "<div class='partname'>零件名称</div>";
    htmlContent2 += "<div class='partnum'>数量</div>";
    htmlContent2 += "<div class='cl'></div>";
    htmlContent2 += "</li>";

    for (let i = 0; i < bom.length; i++) {
        if (bom[i].type == "eq") {
            //构造左侧数据
            htmlContent1 += "<li class='same'>";
            htmlContent1 += "<div>" + bom[i].name1 + "</div>";
            htmlContent1 += "<div>" + bom[i].num1 + "</div>";
            htmlContent1 += "<div class='cl'></div>";
            htmlContent1 += "</li>";
            //构造右侧数据
            htmlContent2 += "<li class='same'>";
            htmlContent2 += "<div>" + bom[i].name2 + "</div>";
            htmlContent2 += "<div>" + bom[i].num2 + "</div>";
            htmlContent2 += "<div class='cl'></div>";
            htmlContent2 += "</li>";
        }
        if (bom[i].type == "neq") {
            //构造左侧数据
            htmlContent1 += "<li class='de'>";
            htmlContent1 += "<div>" + bom[i].name1 + "</div>";
            htmlContent1 += "<div>" + bom[i].num1 + "</div>";
            htmlContent1 += "<div class='cl'></div>";
            htmlContent1 += "</li>";
            //构造右侧数据
            htmlContent2 += "<li class='de'>";
            htmlContent2 += "<div>" + bom[i].name2 + "</div>";
            htmlContent2 += "<div>" + bom[i].num2 + "</div>";
            htmlContent2 += "<div class='cl'></div>";
            htmlContent2 += "</li>";
        }
        if (bom[i].type == "lu") {
            //构造左侧数据
            htmlContent1 += "<li class='kong1'>";
            htmlContent1 += "<div>" + bom[i].name1 + "</div>";
            htmlContent1 += "<div>" + bom[i].num1 + "</div>";
            htmlContent1 += "<div class='cl'></div>";
            htmlContent1 += "</li>";
            //构造右侧数据
            htmlContent2 += "<li class='kong'>";
            htmlContent2 += "<div> </div>";
            htmlContent2 += "<div> </div>";
            htmlContent2 += "<div class='cl'></div>";
            htmlContent2 += "</li>";
        }
        if (bom[i].type == "ru") {
            //构造左侧数据
            htmlContent1 += "<li class='kong'>";
            htmlContent1 += "<div> </div>";
            htmlContent1 += "<div> </div>";
            htmlContent1 += "<div class='cl'></div>";
            htmlContent1 += "</li>";
            //构造右侧数据
            htmlContent2 += "<li class='kong1'>";
            htmlContent2 += "<div>" + bom[i].name2 + "</div>";
            htmlContent2 += "<div>" + bom[i].num2 + "</div>";
            htmlContent2 += "<div class='cl'></div>";
            htmlContent2 += "</li>";
        }
    }
    htmlContent1 += "</ul>";
    htmlContent2 += "</ul>";

    let htmlContent = htmlContent1 + htmlContent2;
    htmlContent += "<div class='cl'></div>";
    return htmlContent;
}

//页面加载事件
addLoadEvent(disableContextMenu);
addLoadEvent(initArray);
addLoadEvent(disablePopupDom);

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

    //测试数据MBOM
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
        }]
    }];

    //测试数据EBOM
    var edata = [{
        id: "900001",
        name: "制造零件A",
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
        icon: "icon-ebom",
        createTime: "2019/11/18 10:44:00",
        children: [{
            id: "900002",
            name: "制造零件A1",
            seq: "MPRT-000002",
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
            root: false,
            icon: "icon-ebom",
            createTime: "2019/11/18 10:44:00",
            children: [{
                id: "900003",
                name: "制造零件A11",
                seq: "MPRT-900003",
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
                root: false,
                icon: "icon-ebom",
                createTime: "2019/11/18 10:44:00",
                children: []
            },
            {
                id: "900004",
                name: "制造零件A12",
                seq: "MPRT-900004",
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
                root: false,
                icon: "icon-ebom",
                createTime: "2019/11/18 10:44:00",
                children: []
            }]
        },
        {
            id: "900005",
            name: "制造零件A5",
            seq: "MPRT-900005",
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
            root: false,
            icon: "icon-ebom",
            createTime: "2019/11/18 10:44:00",
            children: []
        }]
    }];

    //渲染表格
    var mainTreeTable = treeTable.render({
        elem: '#mtree',
        data: [],
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
    //渲染表格
    var ebomTreeTable = treeTable.render({
        elem: '#etree',
        data: [],
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
    mainTreeTable.expandAll();
    ebomTreeTable.expandAll();

    //重写行单击事件，更改选中行样式
    treeTable.on('row(mtree)', function (obj) {
        obj.tr.addClass('selected-row').siblings().removeClass('selected-row');
    });
    treeTable.on('row(move_mtree)', function (obj) {
        obj.tr.addClass('selected-row').siblings().removeClass('selected-row');
    });

    //重写右键事件，弹出自定义命令
    treeTable.on('mouseRightMenu(mtree)', function (obj) {
        //自定义命令
        var menu_data = [
            { 'data': obj, 'type': 'insertExistingMpart', 'title': '插入已有制造零件', icon: 'layui-icon-add-circle' },
            { 'data': obj, 'type': 'insertNewMpart', 'title': '插入新的制造零件', icon: 'layui-icon-add-circle' },
            { 'data': obj, 'type': 'insertNewMaterial', 'title': '插入新的原材料', icon: 'layui-icon-add-circle' },
            { 'data': obj, 'type': 'deleteMpart', 'title': '删除制造零件', icon: 'layui-icon-delete' },
            { 'data': obj, 'type': 'moveMpart', 'title': '移动制造零件', icon: 'layui-icon-util' },
            { 'data': obj, 'type': 'splitMpart', 'title': '拆分制造零件', icon: 'layui-icon-link' },
            { 'data': obj, 'type': 'checkBom', 'title': '检查责信度', icon: 'layui-icon-list' }
        ];

        /**
         * 右键命令事件监听
         */
        mouseRightMenu.open(menu_data, false, function (obj1) {
            if (obj1.type == 'insertExistingMpart') {
                if (obj1.data.data) {
                    //构造测试数据
                    let tmpdata = {
                        id: getNextId(),
                        name: "制造零件-TEST",
                        seq: "MPRT-TEST",
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
                        num: 4,
                        root: false,
                        icon: "icon-mbom",
                        createTime: "2019/11/18 10:44:00",
                        children: []
                    }

                    //获取全部数据
                    let mainTreeTableData = mainTreeTable.getData();
                    //找到当前节点
                    let currentNode = getDataById(mainTreeTableData, obj1.data.data.id);
                    //这里要找到树的数据，插入
                    currentNode.children.push(tmpdata);
                    mainTreeTable.reload();
                    mainTreeTable.expandAll();
                }
            }
            if (obj1.type == 'insertNewMpart') {
                if (obj1.data.data) {
                    //构造测试数据
                    let tmpdata = {
                        id: getNextId(),
                        name: "制造零件-TEST",
                        seq: "MPRT-TEST",
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
                        num: 4,
                        root: false,
                        icon: "icon-mbom",
                        createTime: "2019/11/18 10:44:00",
                        children: []
                    }

                    //获取全部数据
                    let mainTreeTableData = mainTreeTable.getData();
                    //找到当前节点
                    let currentNode = getDataById(mainTreeTableData, obj1.data.data.id);
                    //这里要找到树的数据，插入
                    currentNode.children.push(tmpdata);
                    mainTreeTable.reload();
                    mainTreeTable.expandAll();
                }
            }
            if (obj1.type == 'insertNewMaterial') {
                if (obj1.data.data) {
                    //构造测试数据
                    let tmpdata = {
                        id: getNextId(),
                        name: "制造零件-TEST",
                        seq: "MPRT-TEST",
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
                        num: 4,
                        root: false,
                        icon: "icon-ebom",
                        createTime: "2019/11/18 10:44:00",
                        children: []
                    }

                    //获取全部数据
                    let mainTreeTableData = mainTreeTable.getData();
                    //找到当前节点
                    let currentNode = getDataById(mainTreeTableData, obj1.data.data.id);
                    //这里要找到树的数据，插入
                    currentNode.children.push(tmpdata);
                    mainTreeTable.reload();
                    mainTreeTable.expandAll();
                }
            }
            if (obj1.type == 'deleteMpart') {
                if (obj1.data.data) {
                    if (obj1.data.data.root) {
                        layer.msg('不能删除顶层制造零件');
                        return;
                    }
                    layer.confirm("确认删除该零件？", { title: "提示" }, function (index) {
                        //获取全部数据
                        let mainTreeTableData = mainTreeTable.getData();
                        //找到父亲节点
                        let parentNode = getDataById(mainTreeTableData, obj1.data.data.pid);
                        //找到当前节点
                        let parentIndex = parentNode.children.indexOfById(obj1.data.data);
                        if (parentIndex > -1) {
                            //从父节点中删除当前节点
                            parentNode.children.splice(parentIndex, 1);
                        }

                        //将当前节点的儿子添加到父亲节点中，类似链表的操作
                        let childs = obj1.data.data.children;
                        if (childs && childs.length > 0) {
                            for (let i = 0; i < childs.length; i++) {
                                parentNode.children.push(childs[i]);
                            }
                        }

                        mainTreeTable.reload();
                        mainTreeTable.expandAll();

                        layer.close(index);
                    });
                }
            }
            if (obj1.type == 'moveMpart') {
                //获取全部数据
                let mainTreeTableData = mainTreeTable.getData();

                //渲染表格
                var moveTreeTable = treeTable.render({
                    elem: '#move_mtree',
                    data: mainTreeTableData,
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

                //移除选中
                moveTreeTable.removeAllChecked();
                //全部展开
                moveTreeTable.expandAll();

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
                        let moveCheckedData = moveTreeTable.checkStatus();
                        if (moveCheckedData && moveCheckedData.length == 1) {
                            //obj1.data.data原节点
                            //moveCheckedData[0]目标节点

                            //找到父亲节点
                            let parent = getDataById(mainTreeTableData, obj1.data.data.pid);
                            let parentIndex = parent.children.indexOfById(obj1.data.data);
                            if (parentIndex > -1) {
                                //父亲节点删除子节点
                                parent.children.splice(parentIndex, 1);
                            }

                            //找到目标节点，插入
                            let targetNode = getDataById(mainTreeTableData, moveCheckedData[0].id);
                            targetNode.children.push(obj1.data.data);
                            //重新加载树
                            moveTreeTable.reload();
                            moveTreeTable.expandAll();
                            //重新加载树
                            mainTreeTable.reload();
                            mainTreeTable.expandAll();

                            //关闭层
                            layer.close(index);
                        }
                        else {
                            layer.msg("请选中一个需要移动至的目标零件");
                        }
                    }
                });
            }
            if (obj1.type == 'splitMpart') {
                //校验一
                if (obj1.data.data.num == 1) {
                    layer.msg("数量等于1的零件无法拆分！");
                    return;
                }
                //校验二
                if (obj1.data.data.icon == "icon-mbom") {
                    layer.msg("制造零件无法拆分，请选择工程零件！");
                    return;
                }
                //校验三
                if (obj1.data.data.children && obj1.data.data.children.length > 0) {
                    layer.msg("该零件含有子阶零件无法拆分！");
                    return;
                }

                //表单赋值
                $("#txtMpartId").val(obj1.data.data.id);
                $("#txtMpartName").val(obj1.data.data.name);
                $("#txtMpartNumber").val(obj1.data.data.seq);
                $("#txtMpartNum").val(obj1.data.data.num);

                //重新加载空的表格
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
                        let tableSplitedData = table.cache["split_mtree"];
                        if (tableSplitedData && tableSplitedData.length > 0) {
                            //定义总数量
                            let totalCount = 0;
                            for (let i = 0; i < tableSplitedData.length; i++) {
                                totalCount += parseInt(tableSplitedData[i].num);
                            }
                            //校验四
                            if (totalCount != obj1.data.data.num) {
                                layer.msg("拆分后的数量与总的数量不匹配");
                                return;
                            }
                            else {
                                //获取全部数据
                                let mainTreeTableData = mainTreeTable.getData();
                                //找到父亲节点
                                let parent = getDataById(mainTreeTableData, obj1.data.data.pid);
                                //找到当前节点
                                let parentIndex = parent.children.indexOfById(obj1.data.data);
                                if (parentIndex > -1) {
                                    //从父节点中删除当前节点
                                    parent.children.splice(parentIndex, 1);
                                }

                                //将拆分后的结果刷新到主页面树形表格中
                                for (let j = 0; j < tableSplitedData.length; j++) {
                                    tableSplitedData[j].pid = obj1.data.data.pid;
                                    tableSplitedData[j].classification = obj1.data.data.classification;
                                    tableSplitedData[j].version = obj1.data.data.version;
                                    tableSplitedData[j].generation = obj1.data.data.generation;
                                    tableSplitedData[j].creator = obj1.data.data.creator;
                                    tableSplitedData[j].state = obj1.data.data.state;
                                    tableSplitedData[j].material = obj1.data.data.material;
                                    tableSplitedData[j].standard = obj1.data.data.standard;
                                    tableSplitedData[j].weight = obj1.data.data.weight;
                                    tableSplitedData[j].timequota = obj1.data.data.timequota;
                                    tableSplitedData[j].materialquota = obj1.data.data.materialquota;
                                    tableSplitedData[j].root = obj1.data.data.root;
                                    tableSplitedData[j].icon = obj1.data.data.icon;
                                    tableSplitedData[j].createTime = obj1.data.data.createTime;
                                    tableSplitedData[j].children = [];
                                    parent.children.push(tableSplitedData[j]);
                                }

                                //重新加载树
                                mainTreeTable.reload();
                                mainTreeTable.expandAll();

                                layer.close(index);
                            }
                        }
                        else {
                            layer.msg("未拆分零件");
                            return;
                        }
                    }
                });
            }
            if (obj1.type == 'checkBom') {
                //获取MBOM全部数据
                let mainTreeTableData = mainTreeTable.getData();
                clearTraverseResult();
                traverseTree2(mainTreeTableData[0]);
                let mbomarray = result;

                //获取EBOM全部数据
                let ebomTreeTableData = ebomTreeTable.getData();
                clearTraverseResult();
                traverseTree2(ebomTreeTableData[0]);
                let ebomarray = result;

                mbomarray.sort(function (valueA, valueB) {
                    let targetA = valueA != null && valueA.name != null && valueA.name.toString().toLowerCase();
                    let targetB = valueB != null && valueB.name != null && valueB.name.toString().toLowerCase();
                    return targetA != null && targetA.localeCompare ? targetA.localeCompare(targetB) : targetA - targetB;
                });

                ebomarray.sort(function (valueA, valueB) {
                    let targetA = valueA != null && valueA.name != null && valueA.name.toString().toLowerCase();
                    let targetB = valueB != null && valueB.name != null && valueB.name.toString().toLowerCase();
                    return targetA != null && targetA.localeCompare ? targetA.localeCompare(targetB) : targetA - targetB;
                });

                mbomarray = mergebom(mbomarray);
                ebomarray = mergebom(ebomarray);

                debugger;

                let bomarray = comparebom(ebomarray, mbomarray);
                let compareDOM = createCompareResult(bomarray);
                $("#bomlist")[0].innerHTML = compareDOM;

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
            }
        });
    });

    treeTable.on('mouseRightMenu(etree)', function (obj) {
        //自定义命令
        var menu_data = [
            { 'data': obj, 'type': 'checkBom', 'title': '检查责信度', icon: 'layui-icon-list' }
        ];

        /**
         * 右键命令事件监听
         */
        mouseRightMenu.open(menu_data, false, function (obj1) {
            if (obj1.type == 'checkBom') {
                //获取MBOM全部数据
                let mainTreeTableData = mainTreeTable.getData();
                clearTraverseResult();
                traverseTree2(mainTreeTableData[0]);
                let mbomarray = result;

                //获取EBOM全部数据
                let ebomTreeTableData = ebomTreeTable.getData();
                clearTraverseResult();
                traverseTree2(ebomTreeTableData[0]);
                let ebomarray = result;

                mbomarray.sort(function (valueA, valueB) {
                    let targetA = valueA != null && valueA.name != null && valueA.name.toString().toLowerCase();
                    let targetB = valueB != null && valueB.name != null && valueB.name.toString().toLowerCase();
                    return targetA != null && targetA.localeCompare ? targetA.localeCompare(targetB) : targetA - targetB;
                });

                ebomarray.sort(function (valueA, valueB) {
                    let targetA = valueA != null && valueA.name != null && valueA.name.toString().toLowerCase();
                    let targetB = valueB != null && valueB.name != null && valueB.name.toString().toLowerCase();
                    return targetA != null && targetA.localeCompare ? targetA.localeCompare(targetB) : targetA - targetB;
                });

                mbomarray = mergebom(mbomarray);
                ebomarray = mergebom(ebomarray);

                debugger;

                let bomarray = comparebom(ebomarray, mbomarray);
                let compareDOM = createCompareResult(bomarray);
                $("#bomlist")[0].innerHTML = compareDOM;

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
            }
        });
    });

    //表格渲染
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
        let value = obj.value;

        //输入非法字符时，强制将数量更正为1，并提示错误
        if (!/^[0-9]*$/.test(value)) {
            let tableSplitedData = table.cache["split_mtree"];
            let index = tableSplitedData.indexOfById(obj.data);
            tableSplitedData[index].num = 1;

            layer.msg("请输入正确的数量！");
            table.reload('split_mtree', {
                data: tableSplitedData
            });
            return;
        }

        //输入非法数量时，强制将数量更正为1，并提示错误
        let number = parseInt(value);
        if (number < 1 || number > 2000) {
            let tableSplitedData = table.cache["split_mtree"];
            let index = tableSplitedData.indexOfById(obj.data);
            tableSplitedData[index].num = 1;

            layer.msg("请输入正确的数量！");
            table.reload('split_mtree', {
                data: tableSplitedData
            });
            return;
        }
    });

    //拷贝自EBOM
    $("#btnCopyMpartFromPart").click(function () {
        popupDialog();
        // //获取MBOM全部数据
        // let mainTreeTableData = mainTreeTable.getData();
        // let rootNode = mainTreeTableData[0];

        // //渲染表格
        // mainTreeTable = treeTable.render({
        //     elem: '#mtree',
        //     data: edata,
        //     tree: {
        //         iconIndex: 2
        //     },
        //     cellMinWidth: 50,
        //     cols: [
        //         { type: 'numbers' },
        //         { type: 'checkbox' },
        //         { field: 'seq', title: '物料编码', width: 600 },
        //         //{ field: 'id', title: 'ID' },
        //         { field: 'name', title: '名称' },
        //         { field: 'classification', title: '物料类型' },
        //         // { field: 'version', title: '版本' },
        //         // { field: 'generation', title: '版次' },
        //         // { field: 'creator', title: '创建人' },
        //         // { field: 'state', title: '状态' },
        //         // { field: 'material', title: '材料' },
        //         // { field: 'standard', title: '材料规格' },
        //         // { field: 'weight', title: '重量' },
        //         { field: 'timequota', title: '工时定额' },
        //         { field: 'materialquota', title: '材料定额' },
        //         { field: 'num', title: '数量' },
        //         {
        //             field: 'createTime',
        //             title: '创建时间',
        //             templet: function (d) {
        //                 return util.toDateString(d.createTime);
        //             },
        //             width: 180
        //         }
        //     ],
        //     style: 'margin-top:0;',
        //     even: false
        // });

        // mainTreeTable.reload();
        // mainTreeTable.expandAll();
    });

    //插入已有制造零件
    $("#btnInsertExistingMpart").click(function () {
        let mainCheckedData = mainTreeTable.checkStatus();
        if (mainCheckedData && mainCheckedData.length == 1) {
            //构造测试数据
            let tmpdata = {
                id: getNextId(),
                name: "制造零件-TEST",
                seq: "MPRT-TEST",
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
                num: 4,
                root: false,
                icon: "icon-mbom",
                createTime: "2019/11/18 10:44:00",
                children: []
            }

            mainCheckedData[0].children.push(tmpdata);
            mainTreeTable.reload();
            mainTreeTable.expandAll();
        }
    });

    //插入新的制造零件
    $("#btnInsertNewMpart").click(function () {
        let mainCheckedData = mainTreeTable.checkStatus();
        if (mainCheckedData && mainCheckedData.length == 1) {

            //构造测试数据
            let tmpdata = {
                id: getNextId(),
                name: "制造零件-TEST",
                seq: "MPRT-TEST",
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
                num: 4,
                root: false,
                icon: "icon-mbom",
                createTime: "2019/11/18 10:44:00",
                children: []
            }

            mainCheckedData[0].children.push(tmpdata);
            mainTreeTable.reload();
            mainTreeTable.expandAll();
        }
    });

    //插入新的原材料
    $("#btnInsertNewMaterial").click(function () {
        let mainCheckedData = mainTreeTable.checkStatus();
        if (mainCheckedData && mainCheckedData.length == 1) {

            //构造测试数据
            let tmpdata = {
                id: getNextId(),
                name: "制造零件-TEST",
                seq: "MPRT-TEST",
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
                num: 4,
                root: false,
                icon: "icon-ebom",
                createTime: "2019/11/18 10:44:00",
                children: []
            }

            mainCheckedData[0].children.push(tmpdata);
            mainTreeTable.reload();
            mainTreeTable.expandAll();
        }
    });

    //删除制造零件
    $("#btnDeleteMpart").click(function () {
        let mainCheckedData = mainTreeTable.checkStatus();
        if (mainCheckedData[0].root) {
            layer.msg('不能删除顶层制造零件');
            return;
        }
        if (mainCheckedData && mainCheckedData.length == 1) {
            layer.confirm("确认删除该零件？", { title: "提示" }, function (index) {
                //获取全部数据
                let mainTreeTableData = mainTreeTable.getData();
                //找到父亲节点
                let parent = getDataById(mainTreeTableData, mainCheckedData[0].pid);
                //找到当前节点
                let parentIndex = parent.children.indexOf(mainCheckedData[0]);
                if (parentIndex > -1) {
                    //从父节点中删除当前节点
                    parent.children.splice(parentIndex, 1);
                }

                //将当前节点的儿子添加到父亲节点中，类似链表的操作
                let childs = mainCheckedData[0].children;
                if (childs && childs.length > 0) {
                    for (let i = 0; i < childs.length; i++) {
                        parent.children.push(childs[i]);
                    }
                }

                //重载树结构
                mainTreeTable.reload();
                mainTreeTable.expandAll();

                layer.close(index);
            });
        }
    });

    //检查BOM责信度
    $("#btnCheckMBom").click(function () {
        //获取MBOM全部数据
        let mainTreeTableData = mainTreeTable.getData();
        clearTraverseResult();
        traverseTree2(mainTreeTableData[0]);
        let mbomarray = result;

        //获取EBOM全部数据
        let ebomTreeTableData = ebomTreeTable.getData();
        clearTraverseResult();
        traverseTree2(ebomTreeTableData[0]);
        let ebomarray = result;

        mbomarray.sort(function (valueA, valueB) {
            let targetA = valueA != null && valueA.name != null && valueA.name.toString().toLowerCase();
            let targetB = valueB != null && valueB.name != null && valueB.name.toString().toLowerCase();
            return targetA != null && targetA.localeCompare ? targetA.localeCompare(targetB) : targetA - targetB;
        });

        ebomarray.sort(function (valueA, valueB) {
            let targetA = valueA != null && valueA.name != null && valueA.name.toString().toLowerCase();
            let targetB = valueB != null && valueB.name != null && valueB.name.toString().toLowerCase();
            return targetA != null && targetA.localeCompare ? targetA.localeCompare(targetB) : targetA - targetB;
        });

        mbomarray = mergebom(mbomarray);
        ebomarray = mergebom(ebomarray);

        debugger;

        let bomarray = comparebom(ebomarray, mbomarray);
        let compareDOM = createCompareResult(bomarray);
        $("#bomlist")[0].innerHTML = compareDOM;

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

    //检查BOM责信度
    $("#btnCheckEBom").click(function () {
        //获取MBOM全部数据
        let mainTreeTableData = mainTreeTable.getData();
        clearTraverseResult();
        traverseTree2(mainTreeTableData[0]);
        let mbomarray = result;

        //获取EBOM全部数据
        let ebomTreeTableData = ebomTreeTable.getData();
        clearTraverseResult();
        traverseTree2(ebomTreeTableData[0]);
        let ebomarray = result;

        mbomarray.sort(function (valueA, valueB) {
            let targetA = valueA != null && valueA.name != null && valueA.name.toString().toLowerCase();
            let targetB = valueB != null && valueB.name != null && valueB.name.toString().toLowerCase();
            return targetA != null && targetA.localeCompare ? targetA.localeCompare(targetB) : targetA - targetB;
        });

        ebomarray.sort(function (valueA, valueB) {
            let targetA = valueA != null && valueA.name != null && valueA.name.toString().toLowerCase();
            let targetB = valueB != null && valueB.name != null && valueB.name.toString().toLowerCase();
            return targetA != null && targetA.localeCompare ? targetA.localeCompare(targetB) : targetA - targetB;
        });

        mbomarray = mergebom(mbomarray);
        ebomarray = mergebom(ebomarray);

        debugger;

        let bomarray = comparebom(ebomarray, mbomarray);
        let compareDOM = createCompareResult(bomarray);
        $("#bomlist")[0].innerHTML = compareDOM;

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
        let mainCheckedData = mainTreeTable.checkStatus();
        if (mainCheckedData && mainCheckedData.length == 1) {
            //校验一
            if (mainCheckedData[0].num == 1) {
                layer.msg("数量等于1的零件无法拆分！");
                return;
            }
            //校验二
            if (mainCheckedData[0].icon == "icon-mbom") {
                layer.msg("制造零件无法拆分，请选择工程零件！");
                return;
            }
            //校验三
            if (mainCheckedData[0].children && mainCheckedData[0].children.length > 0) {
                layer.msg("该零件含有子阶零件无法拆分！");
                return;
            }

            //表单赋值
            $("#txtMpartId").val(mainCheckedData[0].id);
            $("#txtMpartName").val(mainCheckedData[0].name);
            $("#txtMpartNumber").val(mainCheckedData[0].seq);
            $("#txtMpartNum").val(mainCheckedData[0].num);

            //重新加载空的表格
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
                    let tableSplitedData = table.cache["split_mtree"];
                    if (tableSplitedData && tableSplitedData.length > 0) {
                        //定义总数量
                        let totalCount = 0;
                        for (let i = 0; i < tableSplitedData.length; i++) {
                            totalCount += parseInt(tableSplitedData[i].num);
                        }
                        //校验四
                        if (totalCount != mainCheckedData[0].num) {
                            layer.msg("拆分后的数量与总的数量不匹配");
                            return;
                        }
                        else {
                            //获取全部数据
                            let mainTreeTableData = mainTreeTable.getData();
                            //找到父亲节点
                            let parent = getDataById(mainTreeTableData, mainCheckedData[0].pid);
                            //找到当前节点
                            let parentIndex = parent.children.indexOf(mainCheckedData[0]);
                            if (parentIndex > -1) {
                                //从父节点中删除当前节点
                                parent.children.splice(parentIndex, 1);
                            }

                            //将拆分后的结果刷新到主页面树形表格中
                            for (let j = 0; j < tableSplitedData.length; j++) {
                                tableSplitedData[j].pid = mainCheckedData[0].pid;
                                tableSplitedData[j].classification = mainCheckedData[0].classification;
                                tableSplitedData[j].version = mainCheckedData[0].version;
                                tableSplitedData[j].generation = mainCheckedData[0].generation;
                                tableSplitedData[j].creator = mainCheckedData[0].creator;
                                tableSplitedData[j].state = mainCheckedData[0].state;
                                tableSplitedData[j].material = mainCheckedData[0].material;
                                tableSplitedData[j].standard = mainCheckedData[0].standard;
                                tableSplitedData[j].weight = mainCheckedData[0].weight;
                                tableSplitedData[j].timequota = mainCheckedData[0].timequota;
                                tableSplitedData[j].materialquota = mainCheckedData[0].materialquota;
                                tableSplitedData[j].root = mainCheckedData[0].root;
                                tableSplitedData[j].icon = mainCheckedData[0].icon;
                                tableSplitedData[j].createTime = mainCheckedData[0].createTime;
                                tableSplitedData[j].children = [];
                                parent.children.push(tableSplitedData[j]);
                            }

                            //重新加载树
                            mainTreeTable.reload();
                            mainTreeTable.expandAll();

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
        //构造测试数据
        let tempdata = {
            id: getNextId(),
            seq: $("#txtMpartNumber").val(),
            name: $("#txtMpartName").val(),
            num: 1,
        };

        //获取表格数据
        let tableSplitedData = table.cache["split_mtree"];
        if (tableSplitedData) {
            tableSplitedData.push(tempdata);
        } else {
            tableSplitedData = tempdata;
        }

        //重新加载数据
        table.reload('split_mtree', {
            data: tableSplitedData
        });


    });

    //删除行
    $("#btnDeleteLine").click(function () {
        //获取已选中的行
        let tableCheckedData = table.checkStatus("split_mtree");
        if (tableCheckedData.data && tableCheckedData.data.length > 0) {
            //获取表格所有行
            let tableSplitedData = table.cache["split_mtree"];
            for (let i = 0; i < tableCheckedData.data.length; i++) {
                //从所有行中，移除已选中的行
                tableSplitedData.removeById(tableCheckedData.data[i]);
            }

            //重新加载表格
            table.reload('split_mtree', {
                data: tableSplitedData
            });
        }
    });

    //弹出移动零件页面
    $("#btnMoveMpart").click(function () {
        //获取需要移动的选中节点
        let mainCheckedData = mainTreeTable.checkStatus();
        if (mainCheckedData && mainCheckedData.length == 1) {

            //渲染表格
            var moveTreeTable = treeTable.render({
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

            //移除选中
            moveTreeTable.removeAllChecked();
            //全部展开
            moveTreeTable.expandAll();

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
                    let moveCheckedData = moveTreeTable.checkStatus();
                    if (moveCheckedData && moveCheckedData.length == 1) {
                        //mainCheckedData[0]原节点
                        //moveCheckedData[0]目标节点
                        //获取全部数据
                        let mainTreeTableData = mainTreeTable.getData();
                        //找到父亲节点
                        let parent = getDataById(mainTreeTableData, mainCheckedData[0].pid);
                        let parentIndex = parent.children.indexOf(mainCheckedData[0]);
                        if (parentIndex > -1) {
                            //父亲节点删除子节点
                            parent.children.splice(parentIndex, 1);
                        }

                        //找到目标节点，插入
                        let targetNode = getDataById(mainTreeTableData, moveCheckedData[0].id);
                        targetNode.children.push(mainCheckedData[0]);
                        //重新加载树
                        moveTreeTable.reload();
                        moveTreeTable.expandAll();
                        //重新加载树
                        mainTreeTable.reload();
                        mainTreeTable.expandAll();

                        //关闭层
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