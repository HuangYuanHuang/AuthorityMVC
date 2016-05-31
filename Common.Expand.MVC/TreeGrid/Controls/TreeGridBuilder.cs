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

        public event Func<IEnumerable<TModel>> LoadTreeDateEvent;
        public event Func<string> LoadToobarButtonEvent;
        public string ToHtmlString()
        {
            return builder.InnerHtml;
        }
        public TreeGridBuilder(string url, string id = null, string tableClass = null, object htmlAttributes = null)
        {

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

                tag.SetInnerText(pair.Value.GetValue(value).ToString());
            }


            list.Add(tag);
        }

        public void ApplyDataCoumn()
        {
            if (LoadTreeDateEvent != null)
            {
                foreach (var item in LoadTreeDateEvent())
                {
                    builder.InnerHtml += ApplyTrColumnHtml(LoadBody, item);
                }
            }
        }
    }

}
