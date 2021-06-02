using SiraUtil.Tools;
using BeatSaberMarkupLanguage.Attributes;
using BeatSaberMarkupLanguage.ViewControllers;
using CustomMenuPointers.Configuration;
using CustomMenuPointers.MenuPointers;
using CustomMenuPointers.UI;
using Zenject;

namespace CustomMenuPointers.UI
{
    [ViewDefinition("CustomMenuPointers.UI.CMPSettingsView.bsml")]
    [HotReload(RelativePathToLayout = @"..\UI\CMPSettingsView.bsml")]
    public class CMPSettingsView : BSMLAutomaticViewController
    {
        private CMPManager _cmpManager;
        private SiraLog _siraLog = null;

        [Inject]
        internal void Construct(SiraLog siraLog, CMPManager cmpManager)
        {
            _siraLog = siraLog;
            _cmpManager = cmpManager;
        }

        [UIValue("toggle-cmp")]
        private bool toggleCMP
        {
            get => PluginConfig.Instance.toggleCMP;
            set
            {
                _cmpManager.ToggleCustomMenuPointers(value).GetAwaiter().GetResult();
                PluginConfig.Instance.toggleCMP = value;
            }
        }

        [UIValue("sf-pointer")]
        private bool sfPointers
        {
            get => PluginConfig.Instance.sfPointer;
            set => PluginConfig.Instance.sfPointer = value;
        }

        [UIAction("reload")]
        private void Reload()
        {
            _cmpManager.reloadModel();
        }
    }
}
