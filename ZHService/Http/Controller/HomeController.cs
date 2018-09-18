using NetworkSocket.Http;
using RazorEngine;
using RazorEngine.Templating;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZHService.Http.Controller
{
    /// <summary>
    /// 平台首页
    /// </summary>
    public class HomeController : HttpController
    {

        /// <summary>
        /// 首页
        /// </summary>
        /// <returns></returns>
        [Route("/")]
        public ActionResult Index()
        {
            var userId = UserList.UserIds;
            return this.View("Index", userId);
        }

        /// <summary>
        /// 执行用户任务
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Route("/Run")]
        [HttpPost]
        public JsonResult Run(string id)
        {
            AutoTask.Run(id);
            return Json(new { state = true, value = "任务开始运行." });
        }

        /// <summary>
        /// 返回视图
        /// </summary>
        /// <param name="name"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        private ActionResult View<T>(string name, T model)
        {
            var controller = this.CurrentContext.Action.ControllerName;
            var cshtml = System.IO.File.ReadAllText($"Http\\View\\{controller}\\{name}.cshtml", System.Text.Encoding.UTF8);
            var html = Engine.Razor.RunCompile(cshtml, name, null, model);
            return Content(html);
        }
    }
}
