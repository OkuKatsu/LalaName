using System;
using System.Numerics;
using Dalamud.Interface.Windowing;
using ImGuiNET;

namespace LalaName.Windows;

public class ConfigWindow : Window, IDisposable
{
    private Configuration configuration;

    // We give this window a constant ID using ###
    // This allows for labels being dynamic, like "{FPS Counter}fps###XYZ counter window",
    // and the window ID will always be "###XYZ counter window" for ImGui
    public ConfigWindow(Plugin plugin) : base("LalaName Plugin Config Menu")
    {
        Flags = ImGuiWindowFlags.NoResize | ImGuiWindowFlags.NoCollapse | ImGuiWindowFlags.NoScrollbar |
                ImGuiWindowFlags.NoScrollWithMouse;

        Size = new Vector2(232, 90);
        SizeCondition = ImGuiCond.Always;

        configuration = plugin.Configuration;
    }

    public void Dispose() { }

    public override void Draw()
    {
        var enable = configuration.IsEnablePlugins;
        if (ImGui.Checkbox("Enable LalaName?", ref enable))
        {
            configuration.IsEnablePlugins = enable;
            configuration.Save();
        }
    }
}
