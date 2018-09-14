using Fiddler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZT.Proxy
{
    public interface IProcessor
    {
        /// <summary>
        /// 回话处理
        /// </summary>
        /// <param name="sessio"></param>
        void ProcessSession(Session sessio);
    }
}
