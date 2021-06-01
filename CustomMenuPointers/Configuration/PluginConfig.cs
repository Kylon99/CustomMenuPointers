using System.Runtime.CompilerServices;
using IPA.Config.Stores;
using static CustomMenuPointers.UI.CMPSettingsView;

[assembly: InternalsVisibleTo(GeneratedStore.AssemblyVisibilityTarget)]
namespace CustomMenuPointers.Configuration
{
    internal class PluginConfig
    {
        public static PluginConfig Instance { get; set; } = null!;

        public virtual bool togglePointers { get; set; } = false;
        public virtual bool sfPointer { get; set; } = false;
    }
}
