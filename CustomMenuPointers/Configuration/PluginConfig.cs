using System.Runtime.CompilerServices;
using IPA.Config.Stores;

[assembly: InternalsVisibleTo(GeneratedStore.AssemblyVisibilityTarget)]
namespace CustomMenuPointers.Configuration
{
    internal class PluginConfig
    {
        public virtual bool CmpEnabled { get; set; }
        public virtual bool UseSfPointer { get; set; }
    }
}
