using BeatSaberMarkupLanguage.Attributes;

namespace CustomMenuPointers.UI
{
    public class MenuSettings : PersistentSingleton<MenuSettings>
    {
        [UIValue("showLeftPointer")]
        private bool showLeftPointer = ConfigOptions.instance.ShowLeftCustomMenuPointer;

        [UIValue("showRightPointer")]
        private bool showRightPointer = ConfigOptions.instance.ShowRightCustomMenuPointer;

        [UIAction("reloadClicked")]
        private void OnReloadCLicked()
        {
            CustomMenuPointers.instance.ShowMenuPointers();
        }

        [UIAction("onShowLeftPointerChanged")]
        private void OnShowLeftPointerChanged(bool value)
        {
            ConfigOptions.instance.ShowLeftCustomMenuPointer = value;
            CustomMenuPointers.instance.ShowMenuPointers();
        }

        [UIAction("onShowRightPointerChanged")]
        private void OnShowRightPointerChanged(bool value)
        {
            ConfigOptions.instance.ShowRightCustomMenuPointer = value;
            CustomMenuPointers.instance.ShowMenuPointers();
        }

    }
}
