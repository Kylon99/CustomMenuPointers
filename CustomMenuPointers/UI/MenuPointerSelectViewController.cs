using HMUI;
using BeatSaberMarkupLanguage.Attributes;
using BeatSaberMarkupLanguage.Parser;
using BeatSaberMarkupLanguage.ViewControllers;
using IPA.Logging;
using TMPro;
using static IPA.Logging.Logger.LogLevel;

namespace CustomMenuPointers.UI
{
    [ViewDefinition("CustomMenuPointers.UI.MenuPointerSelectView.bsml")]
    [HotReload(RelativePathToLayout = @"..\UI\MenuPointerSelectView.bsml")]
    public class MenuPointerSelectView : BSMLAutomaticViewController
    {
        [UIParams] private BSMLParserParams _parserParams;

        [UIAction("reload-btn-action")]
        internal void ReloadButtonAction() => ("Does this work? Yes? Woohoo!");
    }
}