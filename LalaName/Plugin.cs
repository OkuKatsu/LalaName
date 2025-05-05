using Dalamud.Plugin;
using Dalamud.Interface.Windowing;

namespace LalaName;

public sealed class LalaName : IDalamudPlugin
{
    public readonly WindowSystem WindowSystem = new("LalaName");

    public LalaName(IDalamudPluginInterface pluginInterface)
    {
        pluginInterface.Create<Service>();

        _ = pluginInterface.Create<Nameplate>();
    }

    public void Dispose()
    {
        WindowSystem.RemoveAllWindows();
        Service.Nameplate?.Dispose();
    }
}
