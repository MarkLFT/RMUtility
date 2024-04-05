using Uno.Toolkit.UI;

namespace RMUtility.Presentation;


public sealed partial class MainPage : Page
{
    public MainPage()
    {
        this.DataContext<BindableMainModel>((page, vm) => page
            .NavigationCacheMode(NavigationCacheMode.Required)
            .Background(ThemeResource.Get<Brush>("ApplicationPageBackgroundThemeBrush"))
            .Content(
                new Grid()
                .RowDefinitions("Auto,*")
                .Children(
                    new NavigationBar()
                            .Content("Main Page")
                            .Style(StaticResource.Get<Style>("MaterialNavigationBarStyle")),
                    new NavigationView()
                        .Grid(row: 1)
                        .Name("NavView")
                        .MenuItems(
                            new NavigationViewItem()
                                .Content("Home")
                                .Icon(new SymbolIcon(Symbol.Home)),
                            new NavigationViewItem()
                                .Content("Rates")
                                .Icon(new SymbolIcon(Symbol.Calculator)),
                            new NavigationViewItem()
                                .Content("Settings")
                                .Icon(new SymbolIcon(Symbol.Setting)))
                        .Content(
                            new Grid()
                            .RowDefinitions("*,Auto")
                            .Children(
                                new Grid()
                                .Children(
                                    new Grid()
                                        .Visibility(Visibility.Collapsed)
                                        .Children(
                                            new TextBlock()
                                            .Text("Home")
                                            .FontSize(30)
                                            .HorizontalAlignment(HorizontalAlignment.Center)),

                                    new Grid()
                                        .Visibility(Visibility.Collapsed)
                                        .Children(
                                            new TextBlock()
                                            .Text("Rates")
                                            .FontSize(30)
                                            .HorizontalAlignment(HorizontalAlignment.Center)),

                                    new Grid()
                                        .Visibility(Visibility.Collapsed)
                                        .Children(
                                            new TextBlock()
                                            .Text("Settngs")
                                            .FontSize(30)
                                            .HorizontalAlignment(HorizontalAlignment.Center))
                                    ),
                                    new TabBar()
                                        .Grid(row: 1)
                                        .Name("Tabs")
                                        .VerticalAlignment(VerticalAlignment.Bottom)
                                        .Items(
                                            new TabBarItem()
                                                .Style(StaticResource.Get<Style>("MaterialBottomTabBarItemStyle"))
                                                .Icon(new SymbolIcon(Symbol.Home)),
                                            new TabBarItem()
                                                .Style(StaticResource.Get<Style>("MaterialBottomTabBarItemStyle"))
                                                .Icon(new SymbolIcon(Symbol.Contact)),
                                            new TabBarItem()
                                                .Style(StaticResource.Get<Style>("MaterialBottomTabBarItemStyle"))
                                                .Icon(new SymbolIcon(Symbol.Shop)))
                               )
                         )
                     )
                )
            );
    }
}
