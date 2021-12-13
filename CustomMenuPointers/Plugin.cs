using System.Data.Common;
using CustomMenuPointers.Configuration;
using CustomMenuPointers.Installers;
using IPA;
using SiraUtil.Zenject;
using SiraUtil.Tools.FPFC;
using IPALogger = IPA.Logging.Logger;
using IPA.Config.Stores;
using Config = IPA.Config.Config;

namespace CustomMenuPointers
{
    [Plugin(RuntimeOptions.DynamicInit), NoEnableDisable]
    public class Plugin
    {
        [Init]
        public void Init(IPALogger logger, Zenjector zenjector, Config config)
        {
            zenjector.UseLogger(logger);
                
            zenjector.Install<CMPAppInstaller>(Location.App, config.Generated<PluginConfig>());
            zenjector.Install<CMPMenuInstaller>(Location.Menu);
        }
    }
}
