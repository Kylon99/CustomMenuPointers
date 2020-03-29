using BeatSaberMarkupLanguage;
using HMUI;

namespace CustomMenuPointers.UI
{
    /// <summary>
    /// The main menu for the Custom Menu Pointer view controllers
    /// </summary>
    public class ModMainFlowCoordinator : FlowCoordinator
    {
        private SelectionListViewController selectionListViewController;
        public bool IsBusy { get; set; }

        private void Awake()
        {
            selectionListViewController = BeatSaberUI.CreateViewController<SelectionListViewController>();
        }

        protected override void DidActivate(bool firstActivation, ActivationType activationType)
        {
            if (firstActivation)
            {
                this.title = "Custom Menu Pointers";
                showBackButton = true;
            }

            IsBusy = true;
            this.ProvideInitialViewControllers(selectionListViewController);
            IsBusy = false;
        }

        protected override void BackButtonWasPressed(ViewController topViewController)
        {
            if (IsBusy) return;
            BeatSaberUI.MainFlowCoordinator.DismissFlowCoordinator(this);
        }
    }
}
