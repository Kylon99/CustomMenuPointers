using System;
using BeatSaberMarkupLanguage;
using CustomMenuPointers.UI;
using HMUI;
using Zenject;

namespace CustomMenuPointers.FlowCoordinators
{
    public class UIFlowCoordinator : FlowCoordinator
    {
        private MainFlowCoordinator _mainFlowCoordinator;
        private MenuPointerSelectView _menuPointerSelectView;
        private CMPSettingsView _cmpSettingsView;

        [Inject]
        public void Construct(MainFlowCoordinator mainFlowCoordinator, MenuPointerSelectView menuPointerSelectView, CMPSettingsView cmpSettingsView)
        {
            _mainFlowCoordinator = mainFlowCoordinator;
            _menuPointerSelectView = menuPointerSelectView;
            _cmpSettingsView = cmpSettingsView;

        }
        
        protected override void DidActivate(bool firstActivation, bool addedToHierarchy, bool screenSystemEnabling)
        {
            if (firstActivation)
            {
                SetTitle("Menu Pointers");
                showBackButton = true;
                ProvideInitialViewControllers(_menuPointerSelectView, _cmpSettingsView);
            }
        }

        protected override void BackButtonWasPressed(ViewController topViewController)
        {
            _mainFlowCoordinator.DismissFlowCoordinator(this);
        }
    }
}