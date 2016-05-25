using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Common.ExpandMVC
{
    public abstract class BaseController<T, D> : Controller where T : BaseViewModel
    {
        static bool CanLoadAuthority = true;
        public BaseController()
        {
            if (CanLoadAuthority)
            {
                BootstrapTableHelpers.LoadAuthorityEvent += LoadAutority;
                CanLoadAuthority = false;
            }
        }

        protected virtual string LoadAutority() => "";
        protected abstract Task<int> RemoveAsync(D id);

        protected abstract Task<int> UpdateAsync(T model);


        protected abstract Task<int> AddAsync(T model);

        protected abstract Task<T> DetailsAsync(D id);

        protected abstract IEnumerable<T> ListViewModel(D id);

        protected abstract IEnumerable<T> ListViewModel();


        private static Dictionary<Type, ControllerDescriptor> controllerDescriptors = new Dictionary<Type, ControllerDescriptor>();
        private static object syncHelper = new object();

        [HttpPost]
        public async Task<JsonResult> Details(D id)
        {

            var obj = await DetailsAsync(id);
            return Json(new { state = true, message = "", data = obj });


        }

        [HttpPost]
        public async Task<JsonResult> Delete(D id)
        {

            await RemoveAsync(id);
            return Json(new { state = true, message = "" });


        }
        [HttpPost]
        public async Task<JsonResult> Update(T model)
        {

            await UpdateAsync(model);
            return Json(new { state = true, message = "" });

        }

        [HttpPost]
        public async Task<JsonResult> Create(T model)
        {

            if (!ModelState.IsValid)
                return Json(new { state = false, message = "输入不合法" });
            await AddAsync(model);

            return Json(new { state = true, message = "" });

        }

        [ActionName("ListByID")]
        [HttpPost]
        public JsonResult List(D id)
        {
            return Json(ListViewModel(id));
        }

        [ActionName("List")]
        [HttpPost]
        public JsonResult List()
        {
            return Json(ListViewModel());
        }

        protected override void OnException(ExceptionContext filterContext)
        {
            Exception exceptionToThrow = filterContext.Exception;
            string handleErrorAction = this.GetHandleErrorActionName();
            string controllerName = ControllerContext.RouteData.GetRequiredString("controller");
            string actionName = ControllerContext.RouteData.GetRequiredString("action");
            string errorMessage = exceptionToThrow.Message;

            //  ExceptionService ExceptionSer = new ExceptionService();
            //ExceptionSer.Log(new ExceptionViewModel() { Message = exceptionToThrow.Message, ActionName = actionName, ControllerName = controllerName, RequestUrl = Request.Url.ToString(), ParamsSerialize = Json(Request.QueryString).ToString() + Json(Request.Params) });

            if (Request.IsAjaxRequest())
            {
                filterContext.Result = Json(new { state = false, message = "服务端错误" + exceptionToThrow.Message });
                return;
            }
            //下面的有关error View上显示的内容和model再改改。
            ActionDescriptor actionDescriptor = null;
            if (!string.IsNullOrEmpty(handleErrorAction))
            {
                actionDescriptor = Descriptor.FindAction(ControllerContext, handleErrorAction);
            }
            if (actionDescriptor == null)
            {
                filterContext.Result = View("Error");
            }
            else
            {
                ModelState.AddModelError("", errorMessage);
                this.HandleErroeInfo = new ExtendedHandleErrorInfo(exceptionToThrow, controllerName, actionName, errorMessage);
                filterContext.Result = this.HandleErrorActionInvoker.InvokeActionMethod(ControllerContext, actionDescriptor);
            }
        }

        public HandleErrorActionInvoker HandleErrorActionInvoker { get; private set; }


        public ExtendedHandleErrorInfo HandleErroeInfo { get; private set; }

        public string GetHandleErrorActionName()
        {
            string actionName = ControllerContext.RouteData.GetRequiredString("action");
            ActionDescriptor actionDescriptor = this.Descriptor.FindAction(ControllerContext, actionName);
            return "";
        }

        public ControllerDescriptor Descriptor
        {
            get
            {
                ControllerDescriptor descriptor;
                if (controllerDescriptors.TryGetValue(this.GetType(), out descriptor))
                {
                    return descriptor;
                }
                lock (syncHelper)
                {
                    if (controllerDescriptors.TryGetValue(this.GetType(), out descriptor))
                    {
                        return descriptor;
                    }
                    else
                    {
                        descriptor = new ReflectedControllerDescriptor(this.GetType());
                        controllerDescriptors.Add(this.GetType(), descriptor);
                        return descriptor;
                    }
                }
            }
        }

    }

    public class HandleErrorActionInvoker : ControllerActionInvoker
    {

        public virtual ActionResult InvokeActionMethod(ControllerContext controlerContext, ActionDescriptor actionDescriptor)
        {
            IDictionary<string, object> dict = this.GetParameterValues(controlerContext, actionDescriptor);

            return base.InvokeActionMethod(controlerContext, actionDescriptor, dict);
        }

    }

    public class ExtendedHandleErrorInfo : HandleErrorInfo
    {
        public string ErrorMessage { get; private set; }
        public ExtendedHandleErrorInfo(Exception exception, string controllerName, string actionName, string errorMessage)
            : base(exception, controllerName, actionName)
        {
            this.ErrorMessage = errorMessage;
        }
    }
}