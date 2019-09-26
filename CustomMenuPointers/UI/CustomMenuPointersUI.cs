using BeatSaberMarkupLanguage.Settings;
using CustomUI.MenuButton;
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
            this.customMenuPointerMenu = new GameObject(nameof(ModMainFlowCoordinator)).AddComponent<ModMainFlowCoordinator>();
        }

        public void AddUIElements()
        {
            // Show the Menu Pointer settings menu button
            BSMLSettings.instance.AddSettingsMenu(
                "Menu Pointers",
                Plugin.AssemblyName + ".UI.Views.SettingsView.bsml",
                MenuSettings.instance);

            var menuButton = MenuButtonUI.AddButton("Menu Pointers", "Change the pointers seen in the menus!", () =>
            {
                this.customMenuPointerMenu.Present();
            });
        }
    }
}
