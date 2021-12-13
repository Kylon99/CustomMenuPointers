using CustomMenuPointers.UI.FlowCoordinators;
using CustomMenuPointers.Managers;
using CustomMenuPointers.UI;
using IPA.Logging;
using SiraUtil.Tools.FPFC;
using Zenject;

namespace CustomMenuPointers.Installers
{
    internal class CMPMenuInstaller : Installer
    {
        internal IFPFCSettings _fpfc;

        internal CMPMenuInstaller(IFPFCSettings fpfc)
        {
            _fpfc = fpfc;
        }

        public override void InstallBindings()
        {
            Container.Bind<UIFlowCoordinator>().FromNewComponentOnNewGameObject().AsSingle();
            //Container.Bind<MenuPointerSelectView>().FromNewComponentAsViewController().AsSingle();
            Container.Bind<CMPSettingsView>().FromNewComponentAsViewController().AsSingle();
            Container.BindInterfacesAndSelfTo<CMPManager>().AsSingle();
            Container.BindInterfacesTo<MenuButtonUI>().AsSingle();
            
        }
    }
}