using Common.ExpandMVC.Support;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Common.ExpandMVC.TreeGrid.Controls
{
    public class TreeGridBuilder<TModel> : IHtmlString //where TModel : BaseTreeViewModel
    {
        private readonly TagBuilder builder;
        private List<TagBuilder> columns = new List<TagBuilder>();
        string authStrhtml = "";


        private IEnumerable<BaseTreeViewModel> listDatas;


        public string ToHtmlString()
        {
            //
            return "<div class='fixed-table-toolbar'><div class='bars pull-left'>" + authStrhtml + "</div></div>\r\n" + builder.ToString(TagRenderMode.Normal);
        }
        public TreeGridBuilder(GridTreeDataModel model, string id = null, string tableClass = null, object htmlAttributes = null)
        {
            authStrhtml = model.Authoritys.ToString();
            this.listDatas = model.TreeModels;
            builder = new TagBuilder("table");
            string className = "table";
            if (id != null)
            {
                builder.Attributes.Add("id", id);
            }
            if (tableClass != null)
            {
                className += (" " + tableClass.Trim());
            }
            builder.Attributes.Add("class", className);

            builder.MergeAttributes(htmlAttributes as IDictionary<string, object> ?? HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes));

            builder.InnerHtml += ApplyTrColumnHtml(LoadThead, null);
            ApplyDataCoumn();
        }
        private TagBuilder ApplyTrColumnHtml(Action<KeyValuePair<string, PropertyInfo>, DisplayAttribute, List<TagBuilder>, object> action, object value)
        {
            TagBuilder trBuilder = new TagBuilder("tr");
            List<TagBuilder> listColumn = new List<TagBuilder>();
            typeof(TModel).GetSortedProperties().ToDictionary(x => x.Name, x => x).ForEach(pair =>
            {
                DisplayAttribute display = pair.Value.GetCustomAttribute<DisplayAttribute>();
                HiddenInputAttribute hidden = pair.Value.GetCustomAttribute<HiddenInputAttribute>();

                if (hidden == null || hidden.DisplayValue == true)
                {
                    if (display == null || display.GetAutoGenerateField() == null || display.AutoGenerateField == true)
                    {
                        action(pair, display, listColumn, value);
                    }
                }
            });

            listColumn.ForEach(d => trBuilder.InnerHtml += d);
            return trBuilder;

        }

        private void LoadThead(KeyValuePair<string, PropertyInfo> pair, DisplayAttribute display, List<TagBuilder> list, object value)
        {
            var tag = new TagBuilder("td");
            if (display != null && !string.IsNullOrEmpty(display.GetName()))
            {

                tag.Attributes.Add("name", pair.Key);
                tag.SetInnerText(display.GetName());
            }


            list.Add(tag);
        }

        private void LoadBody(KeyValuePair<string, PropertyInfo> pair, DisplayAttribute display, List<TagBuilder> list, object value)
        {
            var tag = new TagBuilder("td");
            if (display != null && !string.IsNullOrEmpty(display.GetName()))
            {
                if (pair.Value.Name == "State")
                {
                   
                    tag.InnerHtml = "<label><input name=\"form-field-radio\" type=\"radio\" /><span class=\"text\"></span></label> ";
                }
                else
                    tag.SetInnerText(pair.Value.GetValue(value).ToString());
            }


            list.Add(tag);
        }

        public void ApplyDataCoumn()
        {

            foreach (var item in listDatas)
            {
                var tagBuilder = ApplyTrColumnHtml(LoadBody, item);

                if (item.ParentID != -1)
                {
                    tagBuilder.AddCssClass("treegrid-parent-" + item.ParentID);
                }
                tagBuilder.AddCssClass("treegrid-" + item.ID);
                builder.InnerHtml += tagBuilder;
            }
        }
    }

}
