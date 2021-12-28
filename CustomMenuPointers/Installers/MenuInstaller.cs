using CustomMenuPointers.UI.FlowCoordinators;
using CustomMenuPointers.Managers;
using CustomMenuPointers.UI;
using IPA.Logging;
using SiraUtil.Logging;
using SiraUtil.Tools.FPFC;
using Zenject;

namespace CustomMenuPointers.Installers
{
    internal class CMPMenuInstaller : Installer
    {
        internal IFPFCSettings _fpfc;
        private SiraLog _siraLog;

        internal CMPMenuInstaller(IFPFCSettings fpfc, SiraLog siraLog)
        {
            _fpfc = fpfc;
            _siraLog = siraLog;
        }

        public override void InstallBindings()
        {
            _siraLog.Info("Installing menu containers..");
            Container.Bind<UIFlowCoordinator>().FromNewComponentOnNewGameObject().AsSingle();
            //Container.Bind<MenuPointerSelectView>().FromNewComponentAsViewController().AsSingle();
            Container.Bind<CMPSettingsView>().FromNewComponentAsViewController().AsSingle();
            Container.BindInterfacesAndSelfTo<CMPManager>().AsSingle();
            Container.BindInterfacesTo<MenuButtonUI>().AsSingle();
            
        }
    }
}