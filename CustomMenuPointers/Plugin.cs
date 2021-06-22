using CustomMenuPointers.Configuration;
using CustomMenuPointers.Installers;
using IPA;
using SiraUtil.Zenject;
using IPALogger = IPA.Logging.Logger;
using IPA.Config.Stores;
using Config = IPA.Config.Config;

namespace CustomMenuPointers
{
    [Plugin(RuntimeOptions.DynamicInit)]
    public class Plugin
    {
        [Init]
        public void Init(IPALogger logger, Zenjector zenjector, Config config)
        {
            zenjector.OnMenu<ModelSelectViewInstaller>().WithParameters(logger, config.Generated<PluginConfig>());
        }

        [OnEnable]
        public void OnEnable()
        {
        }

        [OnDisable]
        public void OnDisable()
        {
        }
    }
}
