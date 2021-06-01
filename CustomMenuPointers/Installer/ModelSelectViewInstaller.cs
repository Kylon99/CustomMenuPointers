using System;
using CustomMenuPointers.FlowCoordinators;
using CustomMenuPointers.UI;
using Zenject;
using SiraUtil;
using IPA.Logging;


namespace CustomMenuPointers.Installer
{
    internal class ModelSelectViewInstaller : Installer<Logger, ModelSelectViewInstaller>
    {
        private readonly Logger _logger;
        internal ModelSelectViewInstaller(Logger logger)
        {
            _logger = logger;
        }

        public override void InstallBindings()
        {
            Container.BindLoggerAsSiraLogger(_logger);
            Container.Bind<CustomMenuPointersController>().FromNewComponentAsViewController().AsSingle();
            Container.Bind<UIFlowCoordinator>().FromNewComponentOnNewGameObject().AsSingle();
            Container.Bind<MenuPointerSelectView>().FromNewComponentAsViewController().AsSingle();
            Container.Bind<CMPSettingsView>().FromNewComponentAsViewController().AsSingle();
            Container.BindInterfacesTo<MenuButtonUI>().AsSingle();
        }
    }
}