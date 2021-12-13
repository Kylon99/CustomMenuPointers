using System.Text;
using SiraUtil.Tools;
using BeatSaberMarkupLanguage.Attributes;
using BeatSaberMarkupLanguage.ViewControllers;
using CustomMenuPointers.Configuration;
using CustomMenuPointers.Managers;
using CustomMenuPointers.UI;
using SiraUtil.Logging;
using Zenject;

namespace CustomMenuPointers.UI
{
    [ViewDefinition("CustomMenuPointers.UI.CMPSettingsView.bsml")]
    [HotReload(RelativePathToLayout = @"..\UI\CMPSettingsView.bsml")]
    public class CMPSettingsView : BSMLAutomaticViewController
    {
        private CMPManager _cmpManager;
        private SiraLog _siraLog;
        private PluginConfig _config;

        [Inject]
        internal void Construct(SiraLog siraLog, CMPManager cmpManager, PluginConfig config)
        {
            _siraLog = siraLog;
            _cmpManager = cmpManager;
            _config = config;
        }

        private async void ToggleCmp(bool enableCmp)
        {
            _config.CmpEnabled = enableCmp;
            await _cmpManager.ToggleCustomMenuPointers(enableCmp);
        }

        [UIValue("cmp-enabled")]
        private bool CmpEnabled
        {
            get => _config.CmpEnabled;
            set => ToggleCmp(value);
        }

        [UIValue("sf-pointer")]
        private bool UseSfPointer
        {
            get => _config.UseSfPointer;
            set => _config.UseSfPointer = value;
        }

        [UIAction("reload")]
        private void Reload()
        {
            _cmpManager.ReloadModel();
        }

        [UIAction("removeMesh")]
        private void RemoveMesh()
        {
            _cmpManager?.ToggleCustomMenuPointers(false);
        }
    }
}
