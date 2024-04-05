namespace RMUtility.Presentation;

public sealed partial class Shell : UserControl, IContentControlProvider
{
    public Shell()
    {
        this.Content(
            new Border()
                .Child(
                    new ContentControl()
                        .Assign(out var splash)
                        .HorizontalAlignment(HorizontalAlignment.Stretch)
                        .VerticalAlignment(VerticalAlignment.Stretch)
                        .HorizontalContentAlignment(HorizontalAlignment.Stretch)
                        .VerticalContentAlignment(VerticalAlignment.Stretch)
                )
                .Background(Theme.Brushes.Background.Default)
            );
        ContentControl = splash;
    }

    public ContentControl ContentControl { get; }
}
