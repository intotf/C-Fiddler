﻿using NetworkSocket;
using NetworkSocket.WebSocket;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ZT.Proxy
{
    /// <summary>
    /// Websocket服务中间件
    /// </summary>
    class WebsocketMiddleware : WebSocketMiddlewareBase
    {
        /// <summary>
        /// 使用默认ip绑定ws会话
        /// </summary>
        /// <param name="session">会话</param>
        /// <param name="wrapper">包装</param>
        protected override void OnSetProtocolWrapper(ISession session, WebSocketSession wrapper)
        {
            var ipAddress = (session.RemoteEndPoint as IPEndPoint).Address.ToString();
            session.Tag.Set("ip", ipAddress);

            Console.WriteLine($"websocket客户端{ipAddress}连接过来..");
            base.OnSetProtocolWrapper(session, wrapper);
        }

        /// <summary>
        /// 把收到的内容当作ip，并绑定到ws会话
        /// </summary>
        /// <param name="context">上下文</param>
        /// <param name="frame">数据</param>
        protected override void OnText(IContenxt context, FrameRequest frame)
        {
            var ipAddress = Encoding.UTF8.GetString(frame.Content);
            Console.WriteLine($"websocket客户端将ip绑定到{ipAddress}");
            context.Session.Tag.Set("ip", ipAddress);
        }
    }
}
