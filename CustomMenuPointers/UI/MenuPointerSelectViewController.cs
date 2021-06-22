using BeatSaberMarkupLanguage.Attributes;
using BeatSaberMarkupLanguage.ViewControllers;

namespace CustomMenuPointers.UI
{
    [ViewDefinition("CustomMenuPointers.UI.MenuPointerSelectView.bsml")]
    [HotReload(RelativePathToLayout = @"..\UI\MenuPointerSelectView.bsml")]
    public class MenuPointerSelectView : BSMLAutomaticViewController
    {
        
    }
}