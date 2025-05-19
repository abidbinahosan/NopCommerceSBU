using Nop.Web.Framework.Models;
using Nop.Web.Framework.Mvc.ModelBinding;

namespace NopStation.Theme.nopGadget.Models.Configuration
{
    public record ThemeGadgetSettingsModel : BaseNopModel
    {
        [NopResourceDisplayName("NopGadget.Theme.PrimaryColor")]
        public string PrimaryColor { get; set; }

        [NopResourceDisplayName("NopGadget.Theme.LogoPath")]
        public string LogoPath { get; set; }

        [NopResourceDisplayName("NopGadget.Theme.EnableCustomCss")]
        public bool EnableCustomCss { get; set; }
    }
}
