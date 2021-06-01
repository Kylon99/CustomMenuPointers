using System;
using BeatSaberMarkupLanguage;
using CustomMenuPointers.UI;
using HMUI;
using SiraUtil.Tools;
using Zenject;
using SiraUtil.Tools;

namespace CustomMenuPointers.FlowCoordinators
{
    public class UIFlowCoordinator : FlowCoordinator
    {
        private MainFlowCoordinator _mainFlowCoordinator;
        private MenuPointerSelectView _menuPointerSelectView;
        private CMPSettingsView _cmpSettingsView;
        private SiraLog _siraLog;

        [Inject]
        public void Construct(MainFlowCoordinator mainFlowCoordinator, MenuPointerSelectView menuPointerSelectView, CMPSettingsView cmpSettingsView, SiraLog siraLog)
        {
            _mainFlowCoordinator = mainFlowCoordinator;
            _menuPointerSelectView = menuPointerSelectView;
            _cmpSettingsView = cmpSettingsView;
            _siraLog = siraLog;
        }
        
        protected override void DidActivate(bool firstActivation, bool addedToHierarchy, bool screenSystemEnabling)
        {
            try
            {
                if (firstActivation)
                {
                    SetTitle("Menu Pointers");
                    showBackButton = true;
                    ProvideInitialViewControllers(_menuPointerSelectView, _cmpSettingsView);
                }
            }
            catch (Exception ex)
            {
                _siraLog.Error(ex);
            }
            
        }

        protected override void BackButtonWasPressed(ViewController topViewController)
        {
            _mainFlowCoordinator.DismissFlowCoordinator(this);
        }
    }
}