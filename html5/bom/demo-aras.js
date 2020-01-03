/**
 * 弹出设计零件选择页面
 */
function popupDialog() {
    let param = { aras: top.aras, itemtypeName: "Part", multiselect: false };

    param.callback = function (dlgRes) {
        if (!dlgRes) return;
        getEBOM(dlgRes.itemID);
    };
    let wnd = top.aras.getMainWindow();
    wnd = wnd === top ? wnd.main : top;
    top.aras.modalDialogHelper.show('SearchDialog', wnd, param);
}

/**
 * 获取EBOM数据，由于某个related_id数据第二次出现时，会缩写为<related_id>XXXX</related_id>,
 * 因此先获取part列表，跟partbom列表，然后自己生成树状结构数据
 * @param {根节点ID} rootId 
 */
function getEBOM(rootId) {
    let AML = '';
    AML += '<AML>';
    AML += '  <Item type="Part" id="' + rootId + '" action="GetItemRepeatConfig" select="id, name, item_number, classification, state, generation, major_rev, created_by_id, created_on">';
    AML += '    <Relationships>';
    AML += '      <Item type="Part BOM" select="related_id, quantity" repeatProp="related_id" repeatTimes="0"/>';
    AML += '    </Relationships>';
    AML += '  </Item>';
    AML += '</AML>';

    let innovator = top.aras.newIOMInnovator();
    let item = innovator.applyAML(AML);

    let rootNode = parseXmlString(item.node.outerHTML);

    let partlist = getPartData(rootNode);
    let partbomlist = getPartBomData(rootNode);

    let treeData = generateTreeData(rootId, partlist, partbomlist);

    //渲染表格
    var mainTreeTable = layui.treeTable.render({
        elem: '#mtree',
        data: treeData,
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
                    return layui.util.toDateString(d.createTime);
                },
                width: 180
            }
        ],
        style: 'margin-top:0;',
        even: false
    });

    //渲染表格
    var ebomTreeTable = layui.treeTable.render({
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
                    return layui.util.toDateString(d.createTime);
                },
                width: 180
            }
        ],
        style: 'margin-top:0;',
        even: false
    });

    mainTreeTable.expandAll();
    ebomTreeTable.expandAll();
}

/**
 * 从顶层零件中获取Part数据
 * @param {顶层零件对象} rootItem 
 */
function getPartData(rootItem) {
    let dataArray = [];
    let items = rootItem.getElementsByTagName("Item");
    if (items && items.length) {
        for (let i = 0; i < items.length; i++) {
            let typeString = items[i].getAttribute("type");
            if (typeString == "Part") {
                let data = {
                    id: items[i].getElementsByTagName("id")[0].childNodes[0].data,
                    name: items[i].getElementsByTagName("name")[0].childNodes[0].data,
                    seq: items[i].getElementsByTagName("item_number")[0].childNodes[0].data,
                    classification: items[i].getElementsByTagName("classification")[0] ? items[i].getElementsByTagName("classification")[0].childNodes[0].data || "" : "",
                    version: items[i].getElementsByTagName("major_rev")[0].childNodes[0].data,
                    generation: items[i].getElementsByTagName("generation")[0].childNodes[0].data,
                    creator: items[i].getElementsByTagName("created_by_id")[0].getAttribute("keyed_name"),
                    state: items[i].getElementsByTagName("state")[0].childNodes[0].data,
                    material: "",
                    standard: "",
                    weight: "",
                    timequota: 0,
                    materialquota: 0,
                    num: 1,
                    root: false,
                    icon: "icon-ebom",
                    createTime: items[i].getElementsByTagName("created_on")[0].childNodes[0].data.replace("T", " "),
                    children: []
                }
                dataArray.push(data);
            }
        }
    }
    console.log("=====BOM=====", dataArray);
    return dataArray;
}

/**
 * 从顶层零件中获取PartBom数据
 * @param {顶层零件对象} rootItem 
 */
function getPartBomData(rootItem) {
    let dataArray = [];
    let items = rootItem.getElementsByTagName("Item");
    if (items && items.length) {
        for (let i = 0; i < items.length; i++) {
            let typeString = items[i].getAttribute("type");
            if (typeString == "Part BOM") {
                let partId = "";
                let childNodes = items[i].getElementsByTagName("related_id")[0];
                if (childNodes.getElementsByTagName("id")[0] == null) {
                    partId = childNodes.childNodes[0].data;
                }
                else {
                    partId = childNodes.getElementsByTagName("id")[0].childNodes[0].data;
                }

                let lastIndex = items[i].getElementsByTagName("source_id").length - 1;

                let data = {
                    quantity: items[i].getElementsByTagName("quantity")[0].childNodes[0].data,
                    pid: items[i].getElementsByTagName("source_id")[lastIndex].childNodes[0].data,
                    partId: partId
                }
                dataArray.push(data);
            }
        }
    }
    console.log("=====Part BOM=====", dataArray);
    return dataArray;
}

/**
 * 
 * @param {根节点ID} rootId 
 * @param {零件列表} partlist 
 * @param {关系类列表} partbomlist 
 */
function generateTreeData(rootId, partlist, partbomlist) {
    let treeData = [];
    let rootItem = partlist.getElementById(rootId);
    let root = {
        id: rootItem.id,
        name: rootItem.name,
        seq: rootItem.seq,
        classification: rootItem.classification,
        version: rootItem.version,
        generation: rootItem.generation,
        creator: rootItem.creator,
        state: rootItem.state,
        material: rootItem.material,
        standard: rootItem.standard,
        weight: rootItem.weight,
        timequota: rootItem.timequota,
        materialquota: rootItem.materialquota,
        num: 1,
        root: true,
        icon: "icon-mbom",
        createTime: rootItem.createTime,
        children: []
    };

    let parent = {};
    let childs = [root];
    while (partbomlist && partbomlist.length) {
        parent = childs.shift();
        let array = partbomlist;
        for (let i = 0; i < array.length;) {
            if (parent.id == array[i].pid) {
                let tempItem = partlist.getElementById(array[i].partId);
                let temp = {
                    id: tempItem.id,
                    name: tempItem.name,
                    seq: tempItem.seq,
                    classification: tempItem.classification,
                    version: tempItem.version,
                    generation: tempItem.generation,
                    creator: tempItem.creator,
                    state: tempItem.state,
                    material: tempItem.material,
                    standard: tempItem.standard,
                    weight: tempItem.weight,
                    timequota: tempItem.timequota,
                    materialquota: tempItem.materialquota,
                    num: array[i].quantity,
                    root: false,
                    icon: "icon-ebom",
                    createTime: tempItem.createTime,
                    children: []
                };
                childs.push(temp);
                parent.children.push(temp);
                array.splice(i, 1);
            }
            else {
                i++;
            }
        }

        partbomlist = array;
    }

    treeData.push(root);

    console.log("=====树形表格数据=====", treeData);

    return treeData;
}

/**
 * 将string转换为xml
 * @param {待转换的xml字符串} xmlDocStr 
 */
function parseXmlString(xmlDocStr) {
    var isIEParser = window.ActiveXObject || "ActiveXObject" in window;
    if (xmlDocStr === undefined) {
        return null;
    }
    var xmlDoc;
    if (window.DOMParser) {
        var parser = new window.DOMParser();
        var parsererrorNS = null;
        // IE9+ now is here
        if (!isIEParser) {
            try {
                parsererrorNS = parser.parseFromString("INVALID", "text/xml").getElementsByTagName("parsererror")[0].namespaceURI;
            }
            catch (err) {
                parsererrorNS = null;
            }
        }
        try {
            xmlDoc = parser.parseFromString(xmlDocStr, "text/xml");
            if (parsererrorNS != null && xmlDoc.getElementsByTagNameNS(parsererrorNS, "parsererror").length > 0) {
                //throw new Error('Error parsing XML: '+xmlDocStr);
                xmlDoc = null;
            }
        }
        catch (err) {
            xmlDoc = null;
        }
    }
    else {
        // IE :(
        if (xmlDocStr.indexOf("<?") == 0) {
            xmlDocStr = xmlDocStr.substr(xmlDocStr.indexOf("?>") + 2);
        }
        xmlDoc = new ActiveXObject("Microsoft.XMLDOM");
        xmlDoc.async = "false";
        xmlDoc.loadXML(xmlDocStr);
    }
    return xmlDoc;
}
