using Nop.Core.Configuration;

namespace Nop.Plugin.Themes.NopGadget.Settings
{
    public class ThemeGadgetSettings : ISettings
    {
        public string PrimaryColor { get; set; }
        public string LogoPath { get; set; }
        public bool EnableCustomCss { get; set; }
    }
}