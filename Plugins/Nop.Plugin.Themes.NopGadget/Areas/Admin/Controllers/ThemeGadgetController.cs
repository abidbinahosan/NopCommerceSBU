using Microsoft.AspNetCore.Mvc;
using Nop.Plugin.Themes.NopGadget.Areas.Admin.Models;
using Nop.Plugin.Themes.NopGadget.Settings;
using Nop.Services.Configuration;
using Nop.Web.Framework;
using Nop.Web.Framework.Controllers;
using Nop.Web.Framework.Mvc.Filters;

namespace Nop.Plugin.Themes.NopGadget.Areas.Admin.Controllers
{
    [Area(AreaNames.ADMIN)]
    [AuthorizeAdmin]
    public class ThemeGadgetController : BasePluginController
    {
        private readonly ISettingService _settingService;

        public ThemeGadgetController(ISettingService settingService)
        {
            _settingService = settingService;
        }

        public async Task<IActionResult> Configure()
        {
            var settings = await _settingService.LoadSettingAsync<ThemeGadgetSettings>();

            var model = new ThemeGadgetSettingsModel
            {
                PrimaryColor = settings.PrimaryColor,
                LogoPath = settings.LogoPath,
                EnableCustomCss = settings.EnableCustomCss
            };

            return View("~/Plugins/Theme.NopGadget/Areas/Admin/Views/ThemeGadget/Configure.cshtml", model);
        }

        [HttpPost]
        public async Task<IActionResult> Configure(ThemeGadgetSettingsModel model)
        {
            if (!ModelState.IsValid)
                return await Configure();

            var settings = new ThemeGadgetSettings
            {
                PrimaryColor = model.PrimaryColor,
                LogoPath = model.LogoPath,
                EnableCustomCss = model.EnableCustomCss
            };

            await _settingService.SaveSettingAsync(settings);

            ViewBag.Success = "Settings saved successfully!";

            return await Configure();
        }
    }
}