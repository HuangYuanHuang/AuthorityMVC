using Common.ExpandMVC;
using Common.ExpandMVC.TreeGrid.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System.Web.Mvc
{
    public static class TreeGridHelpers
    {
        /// <summary>
        /// 加载按钮权限
        /// </summary>
        public static event Func<string> LoadAuthorityEvent;

    

        public static TreeGridBuilder<TModel> TreeGrid<TModel>(this HtmlHelper helper, string url, string id, string className, object htmlAttributes = null)
        {
           
            var obj = new TreeGridBuilder<TModel> ( url, id,className, htmlAttributes);
            obj.LoadToobarButtonEvent += TreeGridHelpers.LoadAuthorityEvent;
          
            return obj;
        }

    }
}
