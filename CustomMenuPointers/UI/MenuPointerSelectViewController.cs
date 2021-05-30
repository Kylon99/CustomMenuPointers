using HMUI;
using BeatSaberMarkupLanguage.Attributes;
using BeatSaberMarkupLanguage.ViewControllers;
using TMPro;

namespace CustomMenuPointers.UI
{
    [ViewDefinition("CustomMenuPointers.UI.MenuPointerSelectView.bsml")]
    [HotReload(RelativePathToLayout = @"..\UI\MenuPointerSelectView.bsml")]
    public class MenuPointerSelectView : BSMLAutomaticViewController
    {
        [UIComponent("text")] private TextMeshProUGUI text;

        [UIAction("press")]
        private void ButtonPress()
        {
            text.text = "Oh shit, this text changed!";
        }
    }
}