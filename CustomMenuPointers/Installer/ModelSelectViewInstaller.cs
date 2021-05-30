using System;
using CustomMenuPointers.FlowCoordinators;
using CustomMenuPointers.UI;
using Zenject;
using SiraUtil;


namespace CustomMenuPointers.Installer
{
    public class ModelSelectViewInstaller : Zenject.Installer
    {
        public override void InstallBindings()
        {
            Container.Bind<CustomMenuPointersController>().FromNewComponentAsViewController().AsSingle();
            Container.Bind<UIFlowCoordinator>().FromNewComponentOnNewGameObject().AsSingle();
            Container.Bind<MenuPointerSelectView>().FromNewComponentAsViewController().AsSingle();
            Container.BindInterfacesTo<MenuButtonUI>().AsSingle();
        }
    }
}