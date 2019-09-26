using BeatSaberMarkupLanguage;
using BS_Utils.Utilities;
using System.Linq;
using UnityEngine;
using VRUI;

namespace CustomMenuPointers.UI
{
    /// <summary>
    /// The main menu for the Custom Menu Pointer view controllers
    /// </summary>
    public class ModMainFlowCoordinator : FlowCoordinator
    {
        private DismissableNavigationController dismissableNavController;

        public void Present()
        {
            var mainFlowCoordinator = Resources.FindObjectsOfTypeAll<MainFlowCoordinator>().First();
            mainFlowCoordinator.InvokeMethod("PresentFlowCoordinator", new object[] { this, null, false, false });
        }

        protected override void DidActivate(bool firstActivation, ActivationType activationType)
        {
            if (firstActivation && activationType == ActivationType.AddedToHierarchy)
            {
                this.title = "Custom Menu Pointers";

                // Create and assign our view controllers
                var selectionListViewController = BeatSaberUI.CreateViewController<SelectionListViewController>();

                this.dismissableNavController = Instantiate(Resources.FindObjectsOfTypeAll<DismissableNavigationController>().First());
                this.dismissableNavController.didFinishEvent += this.Dismiss;

                this.SetViewControllerToNavigationConctroller(this.dismissableNavController, selectionListViewController);
                this.ProvideInitialViewControllers(this.dismissableNavController);
            }
        }

        private void Dismiss(DismissableNavigationController navController)
        {
            var mainFlowCoordinator = Resources.FindObjectsOfTypeAll<MainFlowCoordinator>().First();
            (mainFlowCoordinator as FlowCoordinator).InvokeMethod("DismissFlowCoordinator", new object[] { this, null, false });
        }

    }
}
