using Microsoft.AspNetCore.Mvc;
using Nop.Services.Configuration;
using Nop.Web.Framework.Controllers;
using NopStation.Theme.nopGadget.Models.Configuration;
using NopStation.Theme.nopGadget.Settings;

namespace NopStation.Theme.nopGadget.Controllers.Admin
{
    [Area("Admin")]
    public class ThemeGadgetSettingsController : BasePluginController
    {
        private readonly ISettingService _settingService;
        private readonly ThemeGadgetSettings _themeSettings;

        public ThemeGadgetSettingsController(ISettingService settingService, ThemeGadgetSettings themeSettings)
        {
            _settingService = settingService;
            _themeSettings = themeSettings;
        }

        public IActionResult Configure()
        {
            var model = new Models.Configuration.ThemeGadgetSettingsModel
            {
                PrimaryColor = _themeSettings.PrimaryColor,
                LogoPath = _themeSettings.LogoPath,
                EnableCustomCss = _themeSettings.EnableCustomCss,
            };
            return View("~/Plugins/NopGadgetTheme/Views/Admin/Configure.cshtml", model);
        }

        [HttpPost]
        public IActionResult Configure(ThemeGadgetSettingsModel model)
        {
            if (!ModelState.IsValid)
                return Configure();

            _themeSettings.PrimaryColor = model.PrimaryColor;
            _themeSettings.LogoPath = model.LogoPath;
            _themeSettings.EnableCustomCss = model.EnableCustomCss;

            _settingService.SaveSetting(_themeSettings);

            // Success notification
            SuccessNotification("Settings saved");

            return Configure();
        }
    }
}

