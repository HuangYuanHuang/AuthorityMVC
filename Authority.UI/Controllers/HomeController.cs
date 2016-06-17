using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json.Linq;
using System.Net.Http;
using Authority.UI.Models;
using System.Threading.Tasks;

namespace Authority.UI.Controllers
{

    public class HomeController : AuthorityOauthController
    {
        [AllowAnonymous]
        public ActionResult Index()
        {
            if (Session["userName"] == null)
                return RedirectToAction("Login");
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        [AllowAnonymous]
        public ActionResult Login()
        {
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        public ActionResult Vail()
        {
            var res = Request.Form["userName"] == Request.Form["password"];
            if (Request.Form["userName"]?.Length > 1 && res)
            {
                var obj = new UserOnlieModel()
                {
                    UserId = Guid.NewGuid().ToString(),
                    UserName = Request.Form["userName"],
                    AlarmToken = GetAccessToken()
                };
                Session["userName"] = obj;
                return RedirectToAction("Index");
            }
            return RedirectToAction("Login");
        }
        public JsonResult List()
        {

            return Json(new { message = "Hello Oauth" });
        }
        [ValidateInput(false)]

        public async Task<ActionResult> RedirectOauth()
        {
            if (Session["userName"] == null)
            {
                return RedirectToAction("Login");
            }
            string url = Request.QueryString["url"];
            UserOnlieModel model = Session["userName"] as UserOnlieModel;
            HttpClient httpclient = new HttpClient();

            httpclient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", model.AlarmToken);
            var respone = await httpclient.GetAsync(url);

            return Content(await respone.Content.ReadAsStringAsync());
        }
    }
}