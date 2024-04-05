namespace RMUtility.Presentation;

public sealed partial class LoginPage : Page
{
    public LoginPage()
    {
        this.DataContext<BindableLoginModel>((page, vm) => page
            .NavigationCacheMode(NavigationCacheMode.Required)
            .Background(ThemeResource.Get<Brush>("ApplicationPageBackgroundThemeBrush"))
            .Content(new Grid()
                .RowDefinitions("Auto,*")
                .Children(
                    new TextBlock()
                        .Text(() => vm.Title)
                        .HorizontalAlignment(HorizontalAlignment.Center),
                    new StackPanel()
                        .Grid(row: 1)
                        .HorizontalAlignment(HorizontalAlignment.Center)
                        .VerticalAlignment(VerticalAlignment.Center)
                        .Width(200)
                        .Spacing(16)
                        .Children(
                            new Button()
                                .Content("Login")
                                .HorizontalAlignment(HorizontalAlignment.Stretch)
                                .Command(() => vm.Login)))));
    }
}
