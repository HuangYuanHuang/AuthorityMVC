using Common.ExpandMVC.Support;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Common.ExpandMVC
{
    public static class BootstrapTreeView
    {
        public static TreeViewJsonModel BuildTreeView(this IEnumerable<BaseTreeViewModel> list)
        {
            TreeViewJsonModel root = new TreeViewJsonModel() { parent = -1, text = "权限平台", id = 0 };
            List<TreeViewJsonModel> listTree = new List<TreeViewJsonModel>();
            foreach (var item in list)
            {
                foreach (var prop in item.GetType().GetProperties())
                {
                    if (prop.GetCustomAttribute<TreeTextAttribute>() != null)
                    {
                        listTree.Add(new TreeViewJsonModel()
                        {
                            id = item.ID,
                            parent = item.ParentID,
                            text = prop.GetValue(item, null).ToString()
                        });
                        break;
                    }
                }
            }

            foreach (var item in listTree)
            {
                if (item.parent == -1)
                {
                    root = item;
                }
                else
                {
                    TreeViewJsonModel model = FindNextNode(listTree, item.parent);
                    if (model != null)
                        model.nodes.Add(item);
                }
            }
            return root;
        }

        private static TreeViewJsonModel FindNextNode(List<TreeViewJsonModel> listTree, int parentId)
        {
            if (listTree == null)
                return null;
            foreach (var item in listTree)
            {
                if (item.id == parentId)
                    return item;
                TreeViewJsonModel model = FindNextNode(item.nodes, parentId);
                if (model != null)
                    return model;

            }
            return null;
        }


    }
}
