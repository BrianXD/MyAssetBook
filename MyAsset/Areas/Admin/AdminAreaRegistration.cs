using System.Web.Mvc;

namespace MyAsset.Areas.Admin
{
    public class AdminAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "Admin";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "Admin_default",
                "SkillTree/Admin/{controller}/{action}/{id}",
                new { action = "Edit", id = UrlParameter.Optional }
            );
        }
    }
}