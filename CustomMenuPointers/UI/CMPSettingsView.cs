using System;
using SiraUtil.Tools;
using BeatSaberMarkupLanguage;
using BeatSaberMarkupLanguage.Attributes;
using BeatSaberMarkupLanguage.Parser;
using BeatSaberMarkupLanguage.ViewControllers;
using CustomMenuPointers.FlowCoordinators;
using TMPro;
using SiraUtil.Tools;
using Zenject;

namespace CustomMenuPointers.UI
{
    [ViewDefinition("CustomMenuPointers.UI.CMPSettingsView.bsml")]
    [HotReload(RelativePathToLayout = @"..\UI\CMPSettingsView.bsml")]
    public class CMPSettingsView : BSMLAutomaticViewController
    {
        private SiraLog _siraLog = null;

        [Inject]
        internal void Construct(SiraLog siraLog)
        {
            _siraLog = siraLog;
        }
        
        [UIAction("reload")]
    }
}