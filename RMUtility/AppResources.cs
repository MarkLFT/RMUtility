using Uno.Toolkit.UI.Material.Markup;

namespace RMUtility;

public sealed class AppResources : ResourceDictionary
{
    public AppResources()
    {
        this.Build(r => r
            .Merged(new XamlControlsResources())
            .UseMaterialToolkit()
        );
    }
}
