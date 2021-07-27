using CustomMenuPointers.Configuration;
using CustomMenuPointers.UI.FlowCoordinators;
using CustomMenuPointers.Managers;
using CustomMenuPointers.UI;
using IPA.Logging;
using Zenject;
using SiraUtil;

namespace CustomMenuPointers.Installers
{
    internal class ModelSelectViewInstaller : Installer
    {
        private readonly Logger _logger;
        private readonly PluginConfig _config;

        internal ModelSelectViewInstaller(Logger logger, PluginConfig config)
        {
            _logger = logger;
            _config = config;
        }

        public override void InstallBindings()
        {
            Container.BindLoggerAsSiraLogger(_logger);
            Container.BindInstance(_config);
            Container.Bind<UIFlowCoordinator>().FromNewComponentOnNewGameObject().AsSingle();
            //Container.Bind<MenuPointerSelectView>().FromNewComponentAsViewController().AsSingle();
            Container.Bind<CMPSettingsView>().FromNewComponentAsViewController().AsSingle();
            Container.BindInterfacesAndSelfTo<CMPManager>().AsSingle();
            Container.BindInterfacesTo<MenuButtonUI>().AsSingle();
        }
    }
}