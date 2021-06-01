using SiraUtil.Tools;
using BeatSaberMarkupLanguage.Attributes;
using BeatSaberMarkupLanguage.ViewControllers;
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

        [UIValue("Toggle CMP")]
        private bool togglePointers = true;

        [UIValue("SFPointer")]
        private bool sfPointers = true;

    }
}
