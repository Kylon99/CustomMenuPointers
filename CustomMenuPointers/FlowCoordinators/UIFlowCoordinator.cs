using System;
using CustomMenuPointers.UI;
using HMUI;
using Zenject;

namespace CustomMenuPointers.FlowCoordinators
{
    public class UIFlowCoordinator : FlowCoordinator, IInitializable, IDisposable
    {
        private MainFlowCoordinator _mainFlowCoordinator;
        private MenuPointerSelectView _menuPointerSelectView;

        [Inject]
        public void Construct(MainFlowCoordinator mainFlowCoordinator, MenuPointerSelectView menuPointerSelectView)
        {
            _mainFlowCoordinator = mainFlowCoordinator;
            _menuPointerSelectView = menuPointerSelectView;

        }
    }
}