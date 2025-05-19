using System.Threading.Tasks;
using Microsoft.AspNetCore.Routing;
using Nop.Core;
using Nop.Plugin.Themes.NopGadget.Settings;
using Nop.Services.Configuration;
using Nop.Services.Plugins;
using Nop.Web.Framework;
using Nop.Web.Framework.Infrastructure;
using Nop.Web.Framework.Menu;

namespace Nop.Plugin.Themes.NopGadget
{
    public class NopGadgetTheme : BasePlugin, IAdminMenuPlugin
    {
        // Existing code...

        public async Task ManageSiteMapAsync(AdminMenuItem rootMenuItem)
        {
            var menuItem = new AdminMenuItem
            {
                SystemName = "NopGadgetTheme",
                Title = "Nop Gadget Theme",
                Visible = true,
                IconClass = "fas fa-paint-brush",
                RouteValues = new RouteValueDictionary
                    {
                        { "area", AreaNames.ADMIN },
                        { "controller", "ThemeGadget" },
                        { "action", "Configure" }
                    }
            };

            // Fix: Cast ChildItems to IList<AdminMenuItem> before calling Add
            if (rootMenuItem.ChildItems is IList<AdminMenuItem> childItems)
            {
                childItems.Add(menuItem);
            }

            await Task.CompletedTask;
        }
    }
}