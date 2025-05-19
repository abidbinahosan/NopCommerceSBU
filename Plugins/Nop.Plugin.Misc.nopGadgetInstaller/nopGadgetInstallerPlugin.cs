using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Nop.Services.Plugins;

namespace Nop.Plugin.Misc.nopGadgetInstaller
{
    public class nopGadgetInstallerPlugin : BasePlugin
    {
        private readonly IWebHostEnvironment _webHostEnvironment;

        public nopGadgetInstallerPlugin(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
        }

        public override async Task InstallAsync()
        {
            // Copy the theme to the /Themes directory
            var sourcePath = Path.Combine(_webHostEnvironment.ContentRootPath, "Plugins", "Nop.Plugin.Misc.nopGadgetInstaller", "Resources", "nopGadget");
            var targetPath = Path.Combine(_webHostEnvironment.ContentRootPath, "Themes", "nopGadget");

            if (!Directory.Exists(targetPath))
            {
                DirectoryCopy(sourcePath, targetPath, true);
            }

            await base.InstallAsync();
        }

        public override async Task UninstallAsync()
        {
            // (Optional) delete the theme folder when uninstalling
            var targetPath = Path.Combine(_webHostEnvironment.ContentRootPath, "Themes", "nopGadget");
            if (Directory.Exists(targetPath))
            {
                Directory.Delete(targetPath, true);
            }

            await base.UninstallAsync();
        }

        private void DirectoryCopy(string sourceDirName, string destDirName, bool copySubDirs)
        {
            var dir = new DirectoryInfo(sourceDirName);
            var dirs = dir.GetDirectories();

            Directory.CreateDirectory(destDirName);

            foreach (var file in dir.GetFiles())
            {
                string tempPath = Path.Combine(destDirName, file.Name);
                file.CopyTo(tempPath, true);
            }

            if (copySubDirs)
            {
                foreach (var subdir in dirs)
                {
                    string tempPath = Path.Combine(destDirName, subdir.Name);
                    DirectoryCopy(subdir.FullName, tempPath, true);
                }
            }
        }
    }
}
