using NetworkSocket;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZHService
{
    public static class Listener
    {
        /// <summary>
        /// 监听服务
        /// </summary>
        public static readonly TcpListener WsListener = new TcpListener();
    }
}
