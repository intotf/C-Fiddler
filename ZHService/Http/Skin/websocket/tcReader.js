var tcReader = new function () {
    var address = 'ws://127.0.0.1:4005';
    var ws = new jsonWebSocket(address);
    var versionCallBack;

    // 连接成功
    ws.onopen = function (e) {
        var idReader = 1;
        var fpReader = 2;
        var cameraReader = 4;

        ws.invokeApi("Subscribe", [idReader | fpReader | cameraReader]);
        ws.invokeApi('GetVersion', [], function (ver) {
            versionCallBack && versionCallBack(ver);
        });
    };

    // 未安装本机服务时触发
    this.onNoService = function (callback) {
        ws.onclose = function (e) {
            if (callback) callback();
        }
    }

    // 服务初始完成时触发
    this.onServiceOk = function (callBack) {
        versionCallBack = callBack;
    };

    // 摄像头读取到图像时
    this.onCameraImage = function (callBack) {
        ws.bindApi("OnReadCameraImage", callBack);
    }

    // 身份证读取时触发
    this.onIdCardRead = function (callBack) {
        ws.bindApi("OnReadIdCard", callBack);
    }

    // 指纹读取时触发
    this.onFingerPrint = function (callBack) {
        ws.bindApi("OnReadFingerPrint", callBack);
    }

    // IC卡读取时触发
    this.onIcCardRead = function (callback) {
        var time = new Date();
        var code = "";

        document.onkeypress = function (e) {
            e = e || event;
            var dateT = new Date();
            if (dateT - time > 50) {
                code = "";
            }
            time = dateT;

            if (e.which != 13) {
                code = code + String.fromCharCode(e.which);
            }
            else if (code && callback) {
                callback(fixCode(code));
                e.preventDefault();
                code = "";
            }
        };
    }

    function fixCode(code) {
        if (code && code.length == 8) {
            var v0 = parseInt(code[0] + code[1], 16);
            var v1 = parseInt(code[2] + code[3], 16);
            var v2 = parseInt(code[4] + code[5], 16);
            var v3 = parseInt(code[6] + code[7], 16);
            var pad = (v0 ^ v1 ^ v2 ^ v3).toString(16);
            if (pad.length == 1) {
                pad = '0' + pad;
            }

            return (code + pad + '000000').toUpperCase();
        }
        return code;
    }
};
