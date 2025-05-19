using System.Threading.Tasks;
using Microsoft.AspNetCore.Routing;
using Nop.Core;
using NopStation.Theme.nopGadget.Settings;
using Nop.Services.Configuration;
using Nop.Services.Plugins;
using Nop.Web.Framework;
using Nop.Web.Framework.Infrastructure;
using Nop.Web.Framework.Menu;

namespace Nop.Plugin.Themes.NopGadget
{
    public class NopGadgetTheme : BasePlugin, IAdminMenuPlugin
    {
        private readonly ISettingService _settingService;

        public NopGadgetTheme(ISettingService settingService)
        {
            _settingService = settingService;
        }

        public override async Task InstallAsync()
        {
            // Set default settings
            var settings = new ThemeGadgetSettings
            {
                PrimaryColor = "#007bff", // default blue
                LogoPath = "/themes/nopgadget/content/images/logo.png",
                EnableCustomCss = false
            };

            await _settingService.SaveSettingAsync(settings);

            await base.InstallAsync();
        }

        public override async Task UninstallAsync()
        {
            // Remove settings
            await _settingService.DeleteSettingAsync<ThemeGadgetSettings>();

            await base.UninstallAsync();
        }

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
                    { "area", AreaNames.Admin },
                    { "controller", "ThemeGadget" },
                    { "action", "Configure" }
                }
            };

            rootMenuItem.ChildItems.Add(menuItem);

            await Task.CompletedTask;
        }
    }
}
