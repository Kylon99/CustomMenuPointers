using BeatSaberMarkupLanguage;
using BeatSaberMarkupLanguage.MenuButtons;
using BeatSaberMarkupLanguage.Settings;
using BS_Utils.Utilities;
using UnityEngine;

namespace CustomMenuPointers.UI
{
    /// <summary>
    /// The root UI object for this mod
    /// </summary>
    public class CustomMenuPointersUI : MonoBehaviour
    {
        private ModMainFlowCoordinator customMenuPointerMenu;

        private void Awake()
        {
            var menuButton = new MenuButton("Menu Pointers", "Change the pointers seen in the menus!", ShowModFlowCoordinator, true);
            MenuButtons.instance.RegisterButton(menuButton);

            BSMLSettings.instance.AddSettingsMenu("Menu Pointers", Plugin.AssemblyName + ".UI.Views.SettingsView.bsml", MenuSettings.instance);
        }

        public void AddMenuSettings()
        {
        }

        public void ShowModFlowCoordinator()
        {
            if (this.customMenuPointerMenu == null)
                this.customMenuPointerMenu = BeatSaberUI.CreateFlowCoordinator<ModMainFlowCoordinator>();

            if (this.customMenuPointerMenu.IsBusy) return;

            BeatSaberUI.MainFlowCoordinator.InvokeMethod("PresentFlowCoordinator", customMenuPointerMenu, null, false, false);
        }
    }
}
