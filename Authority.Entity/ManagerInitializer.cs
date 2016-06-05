using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Authority.Entity
{
    /// <summary>
    /// 初始化数据
    /// </summary>
    public class ManagerInitializer : DropCreateDatabaseIfModelChanges<AuthorityContext>
    {
        public override void InitializeDatabase(AuthorityContext context)
        {
            var config = new Purv_AppConfig() { Description = "权限管理平台", Name = "权限平台" };
            var module = new Purv_Module()
            {
                AppID = config.AppID,
                Authority = 0,
                ClassName = "glyphicon glyphicon-fire",
                ModuleName = "权限管理模块",
                ParentId = -1,
                Description = "权限管理最上层模块",
                Url = "/Authority",
                IsHasChildren = true
            };
            List<Purv_Authority> listAuth = new List<Purv_Authority>()
            {
                new Purv_Authority() { AuthorityName="添加",AuthorityValue=1,FunctionName="AddModel",Html="glyphicon glyphicon-plus"},
                new Purv_Authority() { AuthorityName="修改",AuthorityValue=2,FunctionName="EditModel",Html="glyphicon glyphicon-edit"},
                new Purv_Authority() { AuthorityName="删除",AuthorityValue=4,FunctionName="RemoveModel",Html="glyphicon glyphicon-trash"},
            };
            context.PurvAuthoritys.AddRange(listAuth);
            context.PurvAppConfigs.Add(config);
            context.PurvModules.Add(module);

            context.SaveChanges();

        }
    }
}
