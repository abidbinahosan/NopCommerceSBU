using Nop.Core.Configuration;

namespace NopStation.Theme.nopGadget.Settings
{
    public class ThemeGadgetSettings : ISettings
    {
        public string PrimaryColor { get; set; }
        public string LogoPath { get; set; }
        public bool EnableCustomCss { get; set; }
    }
}
