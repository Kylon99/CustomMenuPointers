using SiraUtil.Tools;
using BeatSaberMarkupLanguage.Attributes;
using BeatSaberMarkupLanguage.ViewControllers;
using CustomMenuPointers.Configuration;
using IPA.Config.Data;
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

        [UIValue("toggle-cmp")]
        private bool toggleCMP
        {
            get => PluginConfig.Instance.toggleCMP;
            set => PluginConfig.Instance.toggleCMP = value;
        }

        [UIValue("sf-pointer")]
        private bool sfPointers
        {
            get => PluginConfig.Instance.sfPointer;
            set => PluginConfig.Instance.sfPointer = value;
        }
    }
}
