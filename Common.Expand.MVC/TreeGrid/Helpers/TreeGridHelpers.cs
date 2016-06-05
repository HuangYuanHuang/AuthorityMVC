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
      

    

        public static TreeGridBuilder<TModel> TreeGrid<TModel>(this HtmlHelper helper, GridTreeDataModel model, string id, string className, object htmlAttributes = null)
        {
           
            var obj = new TreeGridBuilder<TModel> (model, id,className, htmlAttributes);         
            return obj;
        }

    }
}
