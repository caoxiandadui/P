
layui.define(['form', 'jquery'], function (exports) { //提示：模块也可以依赖其它模块，如：layui.define('layer', callback);
    var jQuery = layui.jquery,
        $ = jQuery,
        form = layui.form,
        _MOD = 'treeSelect',
        trss = {},
        TreeSelect = function () {
            this.v = '1.0.5';
        };
    TreeSelect.prototype.render = function (options) {
        var elem = options.elem,
          // 请求地址
          data = options.data,
          // 请求头
          headers = options.headers,
          // 请求方式
          type = options.type === undefined ? 'GET' : options.type,
          // 节点点击回调
          click = options.click,
          // 渲染成功后的回调函数
          success = options.success,
          // 占位符（提示信息）
          placeholder = options.placeholder === undefined ? '请选择' : options.placeholder,
          // 是否开启搜索
          search = options.search === undefined ? false : options.search,
          // 样式配置项
          style = options.style,
          // 唯一id
          tmp = new Date().getTime(),
          DATA = {},
          selected = 'layui-form-selected',
          TREE_OBJ = undefined,
          TREE_INPUT_ID = 'treeSelect-input-' + tmp,
          TREE_INPUT_CLASS = 'layui-treeselect',
          TREE_SELECT_ID = 'layui-treeSelect-' + tmp,
          TREE_SELECT_CLASS = 'layui-treeSelect',
          TREE_SELECT_TITLE_ID = 'layui-select-title-' + tmp,
          TREE_SELECT_TITLE_CLASS = 'layui-select-title',
          TREE_SELECT_BODY_ID = 'layui-treeSelect-body-' + tmp,
          TREE_SELECT_BODY_CLASS = 'layui-treeSelect-body',
          TREE_SELECT_SEARCHED_CLASS = 'layui-treeSelect-search-ed';


        var a = {
            init: function () {
                $.ajax({
                    url: data,
                    type: type,
                    headers: headers,
                    dataType: 'json',
                    success: function (d) {
                        DATA = d;
                        a.hideElem().input().toggleSelect().loadCss().preventEvent();
                        $.fn.zTree.init($('#' + TREE_SELECT_BODY_ID), a.setting(), d);
                        TREE_OBJ = $.fn.zTree.getZTreeObj(TREE_SELECT_BODY_ID);
                        if (search) {
                            a.searchParam();
                        }
                        a.configStyle();
                        if (success) {
                            var obj = {
                                treeId: TREE_SELECT_ID,
                                data: d
                            };
                            success(obj);
                        }
                    }
                });
                return a;
            },
            // 检查input是否有默认值
            checkDefaultValue: function () {

            },
            setting: function () {
                var setting = {
                    callback: {
                        onClick: a.onClick,
                        onExpand: a.onExpand,
                        onCollapse: a.onCollapse,
                        beforeExpand: a.ztreeCallBack.beforeExpand
                    }
                };
                return setting;
            },
            ztreeCallBack: {
                beforeExpand: function () {
                    a.configStyle();
                },
            },
            onCollapse: function () {
                a.focusInput();
            },
            onExpand: function () {
                a.configStyle();
                a.focusInput();
            },
            focusInput: function () {
                $('#' + TREE_INPUT_ID).focus();
            },
            onClick: function (event, treeId, treeNode) {
                var name = treeNode.name,
                  id = treeNode.id,
                  $input = $('#' + TREE_SELECT_TITLE_ID + ' input');
                $input.val(name);
                $(elem).attr('value', id).val(id);
                $('#' + TREE_SELECT_ID).removeClass(selected);

                if (click) {
                    var obj = {
                        data: DATA,
                        current: treeNode,
                        treeId: TREE_SELECT_ID
                    };
                    click(obj);
                }
                return a;
            },
            hideElem: function () {
                $(elem).hide();
                return a;
            },
            input: function () {
                var readonly = '';
                if (!search) {
                    readonly = 'readonly';
                }
                var selectHtml = '<div class="' + TREE_SELECT_CLASS + ' layui-unselect layui-form-select" id="' + TREE_SELECT_ID + '">' +
                  '<div class="' + TREE_SELECT_TITLE_CLASS + '" id="' + TREE_SELECT_TITLE_ID + '">' +
                  ' <input type="text" id="' + TREE_INPUT_ID + '" placeholder="' + placeholder + '" value="" ' + readonly + ' class="layui-input layui-unselect">' +
                  '<i class="layui-edge"></i>' +
                  '</div>' +
                  '<div class="layui-anim layui-anim-upbit" style="">' +
                  '<div class="' + TREE_SELECT_BODY_CLASS + ' ztree" id="' + TREE_SELECT_BODY_ID + '"></div>' +
                  '</div>' +
                  '</div>';
                $(elem).parent().append(selectHtml);
                return a;
            },
            /**
             * 展开/折叠下拉框
             */
            toggleSelect: function () {
                var item = '#' + TREE_SELECT_TITLE_ID;
                a.event('click', item, function (e) {
                    var $select = $('#' + TREE_SELECT_ID);
                    if ($select.hasClass(selected)) {
                        $select.removeClass(selected);
                        $('#' + TREE_INPUT_ID).blur();
                    } else {
                        // 隐藏其他picker
                        $('.layui-form-select').removeClass(selected);
                        // 显示当前picker
                        $select.addClass(selected);
                    }
                    e.stopPropagation();
                });
                $(document).click(function () {
                    var $select = $('#' + TREE_SELECT_ID);
                    if ($select.hasClass(selected)) {
                        $select.removeClass(selected);
                        $('#' + TREE_INPUT_ID).blur();
                    }
                });
                return a;
            },
            // 模糊查询
            searchParam: function () {
                if (!search) {
                    return;
                }

                var item = '#' + TREE_INPUT_ID;
                a.fuzzySearch(item, null, true);
            },
            fuzzySearch: function (searchField, isHighLight, isExpand) {
                var zTreeObj = TREE_OBJ;//get the ztree object by ztree id
                if (!zTreeObj) {
                    alert("fail to get ztree object");
                }
                var nameKey = zTreeObj.setting.data.key.name; //get the key of the node name
                isHighLight = isHighLight === false ? false : true;//default true, only use false to disable highlight
                isExpand = isExpand ? true : false; // not to expand in default
                zTreeObj.setting.view.nameIsHTML = isHighLight; //allow use html in node name for highlight use

                var metaChar = '[\\[\\]\\\\\^\\$\\.\\|\\?\\*\\+\\(\\)]'; //js meta characters
                var rexMeta = new RegExp(metaChar, 'gi');//regular expression to match meta characters

                // keywords filter function 
                function ztreeFilter(zTreeObj, _keywords, callBackFunc) {
                    if (!_keywords) {
                        _keywords = ''; //default blank for _keywords 
                    }

                    // function to find the matching node
                    function filterFunc(node) {
                        if (node && node.oldname && node.oldname.length > 0) {
                            node[nameKey] = node.oldname; //recover oldname of the node if exist
                        }
                        zTreeObj.updateNode(node); //update node to for modifications take effect
                        if (_keywords.length == 0) {
                            //return true to show all nodes if the keyword is blank
                            zTreeObj.showNode(node);
                            zTreeObj.expandNode(node, isExpand);
                            return true;
                        }
                        //transform node name and keywords to lowercase
                        if (node[nameKey] && node[nameKey].toLowerCase().indexOf(_keywords.toLowerCase()) != -1) {
                            zTreeObj.showNode(node);//show node with matching keywords
                            return true; //return true and show this node
                        }

                        zTreeObj.hideNode(node); // hide node that not matched
                        return false; //return false for node not matched
                    }

                    var nodesShow = zTreeObj.getNodesByFilter(filterFunc); //get all nodes that would be shown
                    processShowNodes(nodesShow, _keywords);//nodes should be reprocessed to show correctly
                }

                /**
                 * reprocess of nodes before showing 4722eb04f6edd97b066826cce9f490c0
                 */
                function processShowNodes(nodesShow, _keywords) {
                    if (nodesShow && nodesShow.length > 0) {
                        //process the ancient nodes if _keywords is not blank
                        if (_keywords.length > 0) {
                            $.each(nodesShow, function (n, obj) {
                                var pathOfOne = obj.getPath();//get all the ancient nodes including current node
                                if (pathOfOne && pathOfOne.length > 0) {
                                    //i < pathOfOne.length-1 process every node in path except self
                                    for (var i = 0; i < pathOfOne.length - 1; i++) {
                                        zTreeObj.showNode(pathOfOne[i]); //show node 
                                        zTreeObj.expandNode(pathOfOne[i], true); //expand node
                                    }
                                }
                            });
                        } else { //show all nodes when _keywords is blank and expand the root nodes
                            var rootNodes = zTreeObj.getNodesByParam('level', '0');//get all root nodes
                            $.each(rootNodes, function (n, obj) {
                                zTreeObj.expandNode(obj, true); //expand all root nodes
                            });
                        }
                    }
                }

                //listen to change in input element
                $(searchField).bind('input propertychange', function () {
                    var _keywords = $(this).val();
                    searchNodeLazy(_keywords); //call lazy load
                });

                var timeoutId = null;
                // excute lazy load once after input change, the last pending task will be cancled  
                function searchNodeLazy(_keywords) {
                    if (timeoutId) {
                        //clear pending task
                        clearTimeout(timeoutId);
                    }
                    timeoutId = setTimeout(function () {
                        ztreeFilter(zTreeObj, _keywords); //lazy load ztreeFilter function 
                        $(searchField).focus();//focus input field again after filtering
                    }, 500);
                }
            },
            checkNodes: function (nodes) {
                for (var i = 0; i < nodes.length; i++) {
                    var o = nodes[i],
                      pid = o.parentTId,
                      tid = o.tId;
                    if (pid !== null) {
                        // 获取父节点
                        $('#' + pid).addClass(TREE_SELECT_SEARCHED_CLASS);
                        var pNode = TREE_OBJ.getNodesByParam("tId", pid, null);
                        TREE_OBJ.expandNode(pNode[0], true, false, true);
                    }
                    $('#' + tid).addClass(TREE_SELECT_SEARCHED_CLASS);
                }
            },
            // 阻止Layui的一些默认事件
            preventEvent: function () {
                var item = '#' + TREE_SELECT_ID + ' .layui-anim';
                a.event('click', item, function (e) {
                    e.stopPropagation();
                });
                return a;
            },
            loadCss: function () {
                var ztree = '.ztree *{padding:0;margin:0;font-size:12px;font-family:Verdana,Arial,Helvetica,AppleGothic,sans-serif}.ztree{margin:0;padding:5px;color:#333}.ztree li{padding:0;margin:0;list-style:none;line-height:14px;text-align:left;white-space:nowrap;outline:0}.ztree li ul{margin:0;padding:0 0 0 18px}.ztree li ul.line{background:url(./img/line_conn.gif) 0 0 repeat-y;}.ztree li a{padding:1px 3px 0 0;margin:0;cursor:pointer;height:17px;color:#333;background-color:transparent;text-decoration:none;vertical-align:top;display:inline-block}.ztree li a:hover{text-decoration:underline}.ztree li a.curSelectedNode{padding-top:0px;background-color:#FFE6B0;color:black;height:16px;border:1px #FFB951 solid;opacity:0.8;}.ztree li a.curSelectedNode_Edit{padding-top:0px;background-color:#FFE6B0;color:black;height:16px;border:1px #FFB951 solid;opacity:0.8;}.ztree li a.tmpTargetNode_inner{padding-top:0px;background-color:#316AC5;color:white;height:16px;border:1px #316AC5 solid;opacity:0.8;filter:alpha(opacity=80)}.ztree li a.tmpTargetNode_prev{}.ztree li a.tmpTargetNode_next{}.ztree li a input.rename{height:14px;width:80px;padding:0;margin:0;font-size:12px;border:1px #7EC4CC solid;*border:0px}.ztree li span{line-height:16px;margin-right:2px}.ztree li span.button{line-height:0;margin:0;width:16px;height:16px;display:inline-block;vertical-align:middle;border:0 none;cursor:pointer;outline:none;background-color:transparent;background-repeat:no-repeat;background-attachment:scroll;background-image:url("./img/zTreeStandard.png");*background-image:url("./img/zTreeStandard.gif")}.ztree li span.button.chk{width:13px;height:13px;margin:0 3px 0 0;cursor:auto}.ztree li span.button.chk.checkbox_false_full{background-position:0 0}.ztree li span.button.chk.checkbox_false_full_focus{background-position:0 -14px}.ztree li span.button.chk.checkbox_false_part{background-position:0 -28px}.ztree li span.button.chk.checkbox_false_part_focus{background-position:0 -42px}.ztree li span.button.chk.checkbox_false_disable{background-position:0 -56px}.ztree li span.button.chk.checkbox_true_full{background-position:-14px 0}.ztree li span.button.chk.checkbox_true_full_focus{background-position:-14px -14px}.ztree li span.button.chk.checkbox_true_part{background-position:-14px -28px}.ztree li span.button.chk.checkbox_true_part_focus{background-position:-14px -42px}.ztree li span.button.chk.checkbox_true_disable{background-position:-14px -56px}.ztree li span.button.chk.radio_false_full{background-position:-28px 0}.ztree li span.button.chk.radio_false_full_focus{background-position:-28px -14px}.ztree li span.button.chk.radio_false_part{background-position:-28px -28px}.ztree li span.button.chk.radio_false_part_focus{background-position:-28px -42px}.ztree li span.button.chk.radio_false_disable{background-position:-28px -56px}.ztree li span.button.chk.radio_true_full{background-position:-42px 0}.ztree li span.button.chk.radio_true_full_focus{background-position:-42px -14px}.ztree li span.button.chk.radio_true_part{background-position:-42px -28px}.ztree li span.button.chk.radio_true_part_focus{background-position:-42px -42px}.ztree li span.button.chk.radio_true_disable{background-position:-42px -56px}.ztree li span.button.switch{width:18px;height:18px}.ztree li span.button.root_open{background-position:-92px -54px}.ztree li span.button.root_close{background-position:-74px -54px}.ztree li span.button.roots_open{background-position:-92px 0}.ztree li span.button.roots_close{background-position:-74px 0}.ztree li span.button.center_open{background-position:-92px -18px}.ztree li span.button.center_close{background-position:-74px -18px}.ztree li span.button.bottom_open{background-position:-92px -36px}.ztree li span.button.bottom_close{background-position:-74px -36px}.ztree li span.button.noline_open{background-position:-92px -72px}.ztree li span.button.noline_close{background-position:-74px -72px}.ztree li span.button.root_docu{background:none;}.ztree li span.button.roots_docu{background-position:-56px 0}.ztree li span.button.center_docu{background-position:-56px -18px}.ztree li span.button.bottom_docu{background-position:-56px -36px}.ztree li span.button.noline_docu{background:none;}.ztree li span.button.ico_open{margin-right:2px;background-position:-110px -16px;vertical-align:top;*vertical-align:middle}.ztree li span.button.ico_close{margin-right:2px;background-position:-110px 0;vertical-align:top;*vertical-align:middle}.ztree li span.button.ico_docu{margin-right:2px;background-position:-110px -32px;vertical-align:top;*vertical-align:middle}.ztree li span.button.edit{margin-right:2px;background-position:-110px -48px;vertical-align:top;*vertical-align:middle}.ztree li span.button.remove{margin-right:2px;background-position:-110px -64px;vertical-align:top;*vertical-align:middle}.ztree li span.button.ico_loading{margin-right:2px;background:url(./img/loading.gif) no-repeat scroll 0 0 transparent;vertical-align:top;*vertical-align:middle}ul.tmpTargetzTree{background-color:#FFE6B0;opacity:0.8;filter:alpha(opacity=80)}span.tmpzTreeMove_arrow{width:16px;height:16px;display:inline-block;padding:0;margin:2px 0 0 1px;border:0 none;position:absolute;background-color:transparent;background-repeat:no-repeat;background-attachment:scroll;background-position:-110px -80px;background-image:url("./img/zTreeStandard.png");*background-image:url("./img/zTreeStandard.gif")}ul.ztree.zTreeDragUL{margin:0;padding:0;position:absolute;width:auto;height:auto;overflow:hidden;background-color:#cfcfcf;border:1px #00B83F dotted;opacity:0.8;filter:alpha(opacity=80)}.zTreeMask{z-index:10000;background-color:#cfcfcf;opacity:0.0;filter:alpha(opacity=0);position:absolute}',
                  ztree_ex = '.layui-treeSelect .ztree li span.button{font-family:layui-icon!important;font-size:16px;font-style:normal;-webkit-font-smoothing:antialiased;-moz-osx-font-smoothing:grayscale;background:none;line-height:inherit;}.layui-treeSelect .ztree li span.button.ico_open{display:none;}.layui-treeSelect .ztree li span.button.ico_close{display:none;}.layui-treeSelect .ztree li span.button.ico_docu:before{content:"\\e621";}.layui-treeSelect .ztree li span.button.bottom_close:before,.layui-treeSelect .ztree li span.button.center_close:before,.layui-treeSelect .ztree li span.button.roots_close:before,.layui-treeSelect .ztree li span.button.root_close:before{content:"\\e623";}.layui-treeSelect .ztree li span.button.bottom_open:before,.layui-treeSelect .ztree li span.button.roots_open:before,.layui-treeSelect .ztree li span.button.center_open:before,.layui-treeSelect .ztree li span.button.root_open:before{content:"\\e625";}.layui-treeSelect .ztree li a:hover{text-decoration:none;}.layui-treeSelect .ztree *{font-size:14px;}.layui-treeSelect .ztree li{line-height:inherit;padding:2px 0;}.layui-treeSelect .ztree li span.button.switch{position:relative;top:-1px;}.layui-treeSelect .ztree li a,.layui-treeSelect .ztree li span{line-height:18px;height:inherit;}.layui-treeSelect .ztree li a.curSelectedNode{color:#5FB878;background:none;border:none;height:inherit;padding-top:1px;}.layui-treeSelect .layui-anim::-webkit-scrollbar{width:6px;height:6px;background-color:#F5F5F5;}.layui-treeSelect .layui-anim::-webkit-scrollbar-track{box-shadow:inset 0 0 6px rgba(107,98,98,0.3);border-radius:10px;background-color:#F5F5F5;}.layui-treeSelect .layui-anim::-webkit-scrollbar-thumb{border-radius:10px;box-shadow:inset 0 0 6px rgba(107,98,98,0.3);background-color:#555;}.layui-treeSelect.layui-form-select .layui-anim{display:none;position:absolute;left:0;top:42px;padding:5px 0;z-index:9999;min-width:100%;border:1px solid #d2d2d2;max-height:300px;overflow-y:auto;background-color:#fff;border-radius:2px;box-shadow:0 2px 4px rgba(0,0,0,.12);box-sizing:border-box;}.layui-treeSelect.layui-form-selected .layui-anim{display:block;}.layui-treeSelect .ztree li ul.line{background:none;position:relative;}.layui-treeSelect .ztree li ul.line:before{content:"";height:100%;border-left:1px dotted #ece;position:absolute;left:8px;}.layui-treeSelect .ztree li .center_docu:before,.layui-treeSelect .ztree li .bottom_docu::before{content:"";height:100%;border-left:1px dotted #ece;position:absolute;left:8px;}.layui-treeSelect .ztree li .center_docu::after,.layui-treeSelect .ztree li .bottom_docu::after{content:"";position:absolute;left:8px;top:8px;width:8px;border-top:1px dotted #ece;}.layui-treeSelect .ztree li span.button.ico_open{display:inline-block;position:relative;top:1px;}.layui-treeSelect .ztree li span.button.ico_close{display:inline-block;position:relative;top:1px;}.layui-treeSelect .ztree li span.button.ico_open:before{content:"\\e643";}.layui-treeSelect .ztree li span.button.ico_close:before{content:"\\e63f";}';
                $head = $('head'),
                  ztreeStyle = $head.find('style[ztree]');

                if (ztreeStyle.length === 0) {
                    $head.append($('<style ztree>').append(ztree).append(ztree_ex))
                }
                return a;
            },
            configStyle: function () {
                if (style == undefined || style.line == undefined || !style.line.enable) {
                    $('#' + TREE_SELECT_ID).find('li .center_docu,li .bottom_docu').hide();
                    //.layui-treeSelect .ztree li .center_docu:before, .ztree li .bottom_docu::before
                }

                if (style == undefined || style.folder == undefined || !style.folder.enable) {
                    $('#' + TREE_SELECT_ID).find('li span.button.ico_open').hide();
                    $('#' + TREE_SELECT_ID).find('li span.button.ico_close').hide();
                }
            },
            event: function (evt, el, fn) {
                $('body').on(evt, el, fn);
            }
        };
        a.init();
        return new TreeSelect();
    };

    /**
     * 重新加载trerSelect
     * @param filter
     */
    TreeSelect.prototype.refresh = function (filter) {
        var treeObj = obj.treeObj(filter);
        treeObj.reAsyncChildNodes(null, "refresh");
    };

    /**
     * 选中节点，因为tree是异步加载，所以必须在success回调中调用checkNode函数，否则无法获取生成的DOM元素
     * @param filter lay-filter属性
     * @param id 选中的id
     */
    TreeSelect.prototype.checkNode = function (filter, id) {
        var o = obj.filter(filter),
            treeInput = o.find('.layui-select-title input'),
            treeObj = obj.treeObj(filter),
            node = treeObj.getNodeByParam("id", id, null),
            name = node.name;
        treeInput.val(name);
        o.find('a[treenode_a]').removeClass('curSelectedNode');
        obj.get(filter).val(id).attr('value', id);
        treeObj.selectNode(node);
    };

    /**
     * 撤销选中的节点
     * @param filter lay-filter属性
     * @param fn 回调函数
     */
    TreeSelect.prototype.revokeNode = function (filter, fn) {
        var o = obj.filter(filter);
        o.find('a[treenode_a]').removeClass('curSelectedNode');
        o.find('.layui-select-title input.layui-input').val('');
        obj.get(filter).attr('value', '').val('');
        obj.treeObj(filter).expandAll(false);
        if (fn) {
            fn({
                treeId: o.attr('id')
            });
        }
    }

    /**
     * 销毁组件
     */
    TreeSelect.prototype.destroy = function (filter) {
        var o = obj.filter(filter);
        o.remove();
        obj.get(filter).show();
    }

    /**
     * 获取zTree对象，可调用所有zTree函数
     * @param filter
     */
    TreeSelect.prototype.zTree = function (filter) {
        return obj.treeObj(filter);
    };

    var obj = {
        get: function (filter) {
            if (!filter) {
                layui.hint().error('filter 不能为空');
            }
            return $('*[lay-filter=' + filter + ']');
        },
        filter: function (filter) {
            var tf = obj.get(filter),
                o = tf.next();
            return o;
        },
        treeObj: function (filter) {
            var o = obj.filter(filter),
                treeId = o.find('.layui-treeSelect-body').attr('id'),
                tree = $.fn.zTree.getZTreeObj(treeId);
            return tree;
        }
    };

    //输出接口
    var mod = new TreeSelect();
    exports(_MOD, mod);
});