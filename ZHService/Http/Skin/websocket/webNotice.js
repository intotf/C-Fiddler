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

    // 身份证读取时触发
    this.onLog = function (callBack) {
        ws.bindApi("OnLog", callBack);
    }

    // 打开摄像头
    this.addUser = function (userId, callBack) {
        ws.invokeApi("AddUser", [userId], callBack);
    }
};
