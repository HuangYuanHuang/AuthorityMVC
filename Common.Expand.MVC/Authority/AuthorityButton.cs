using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.ExpandMVC.Authority
{
    /// <summary>
    /// 权限按钮
    /// </summary>
    public class AuthorityButton
    {
        /// <summary>
        /// 标题
        /// </summary>
        public string Title { set; get; } = "添加";

        /// <summary>
        /// ClassName
        /// </summary>
        public string ClassName { set; get; } = "glyphicon-plus";

        /// <summary>
        /// 返回html字符串
        /// </summary>
        /// <returns>   <button type="button" class="btn btn-default"><i class="glyphicon glyphicon-plus"></i> 添加</button></returns>
        public override string ToString()
        {
            return $" <button type = \"button\" class=\"btn btn-default\"> <i class=\"glyphicon {ClassName}\"></i>{Title}</button>";
        }

    }

    /// <summary>
    /// 权限按钮集合
    /// </summary>
    public class BaseAuthority
    {
        /// <summary>
        /// 权限集合
        /// </summary>
        public List<AuthorityButton> ListAuthButtons { set; get; } = new List<AuthorityButton>();

        /// <summary>
        /// ToolbarID
        /// </summary>
        public string ToolbarID { get; set; } = "toolbar";

        /// <summary>
        /// 返回html字符串
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            string temp = $"<div id=\"{ToolbarID}\" class=\"btn-group\">";
            foreach (var item in ListAuthButtons)
            {
                temp += item.ToString();
            }
            return temp + "</div>";
        }
    }
}
