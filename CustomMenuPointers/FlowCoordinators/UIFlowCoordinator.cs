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

        [Inject]
        public void Construct(MainFlowCoordinator mainFlowCoordinator, MenuPointerSelectView menuPointerSelectView)
        {
            _mainFlowCoordinator = mainFlowCoordinator;
            _menuPointerSelectView = menuPointerSelectView;
        }
        
        protected override void DidActivate(bool firstActivation, bool addedToHierarchy, bool screenSystemEnabling)
        {
            if (firstActivation)
            {
                SetTitle("Menu Pointers");
                showBackButton = true;
                ProvideInitialViewControllers(_menuPointerSelectView);
            }
        }

        protected override void BackButtonWasPressed(ViewController topViewController)
        {
            _mainFlowCoordinator.DismissFlowCoordinator(this);
        }
    }
}