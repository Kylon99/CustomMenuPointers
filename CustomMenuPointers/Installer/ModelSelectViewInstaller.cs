using System;
using CustomMenuPointers.FlowCoordinators;
using CustomMenuPointers.UI;
using Zenject;
using SiraUtil;
using IPA.Logging;


namespace CustomMenuPointers.Installer
{
    public class ModelSelectViewInstaller : Installer<Logger, Installer>
    {
        private readonly Logger _logger;
        
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