var WsNotice = new function () {
    var ws = new jsonWebSocket('ws://' + location.host);

    // 连接成功
    ws.onopen = function (e) {

    };

    // 未安装本机服务时触发
    this.onNoService = function (callback) {
        ws.onclose = function (e) {
            if (callback) callback();
        }
    }

    // 日志接收
    this.onLog = function (callBack) {
        ws.bindApi("OnLog", callBack);
    }

    //刷新用户
    this.loadUsers = function (callBack) {
        ws.bindApi("LoadUsers", callBack)
    }

    // 添加用户
    this.addUser = function (userId, callBack) {
        ws.invokeApi("AddUser", [userId], callBack);
    }

    //运行任务
    this.runTask = function (userIds, callBack) {
        ws.invokeApi("Run", [userIds], callBack)
    }
};
