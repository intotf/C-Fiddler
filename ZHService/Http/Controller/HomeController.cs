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
            return View("Index");
        }

        /// <summary>
        /// 加载用户列表
        /// </summary>
        /// <returns></returns>
        [Route("/LoadUsers")]
        public JsonResult LoadUsers()
        {
            var users = UserApi.Users.Select(item => new { name = item.NickName, value = item.Id }).ToArray();
            return Json(users);
        }


        /// <summary>
        /// 返回视图
        /// </summary>
        /// <param name="name"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        private ActionResult View(string name)
        {
            var controller = this.CurrentContext.Action.ControllerName;
            var cshtml = System.IO.File.ReadAllText($"Http\\View\\{controller}\\{name}.cshtml", System.Text.Encoding.UTF8);
            return Content(cshtml);
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
