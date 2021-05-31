using System;
using BeatSaberMarkupLanguage;
using BeatSaberMarkupLanguage.Attributes;
using BeatSaberMarkupLanguage.ViewControllers;
using TMPro;

namespace CustomMenuPointers.UI
{
    [ViewDefinition("CustomMenuPointers.UI.CMPSettingsView.bsml")]
    [HotReload(RelativePathToLayout = @"..\UI\CMPSettingsView.bsml")]
    public class CMPSettingsView : BSMLAutomaticViewController
    {
        
    }
}