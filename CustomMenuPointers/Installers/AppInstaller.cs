using CustomMenuPointers.Configuration;
using Zenject;

namespace CustomMenuPointers.Installers;

internal class CMPAppInstaller : Installer
{
    private readonly PluginConfig _config;

    public CMPAppInstaller(PluginConfig config)
    {
        _config = config;
    }

    public override void InstallBindings()
    {
        Container.BindInstance(_config);
    }
}
