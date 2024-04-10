using Uno.Toolkit.UI;

namespace RMUtility.Presentation;

public sealed partial class MainPage : Page
{
    public MainPage()
    {
        this.DataContext<BindableMainModel>((page, vm) => page
            .NavigationCacheMode(NavigationCacheMode.Required)
            .Background(ThemeResource.Get<Brush>("ApplicationPageBackgroundThemeBrush"))
            .SafeArea(SafeArea.InsetMask.All)
            .Content(
                new Grid()
                .Region(attached: true)
                .RowDefinitions("Auto,*")
                .Children(
                    new NavigationBar()
                            .Content("Main Page")
                            .Style(StaticResource.Get<Style>("MaterialNavigationBarStyle")),
                    new NavigationView()
                        .Grid(row: 1)
                        .Name("NavView")
                        .Assign(out var NavView)
                        .Region(attached: true)
                        .IsSettingsVisible(false)
                        .MenuItems(
                            new NavigationViewItem()
                                .Content("Home")
                                .Icon(new SymbolIcon(Symbol.Home))
                                .Region(name: "home"),
                            new NavigationViewItem()
                                .Content("Rates")
                                .Icon(new SymbolIcon(Symbol.Calculator))
                                .Region(name: "rates"),
                            new NavigationViewItem()
                                .Content("Settings")
                                .Icon(new SymbolIcon(Symbol.Setting))
                                .Region(name: "settings"))
                        .Content(
                            new Grid()
                            .RowDefinitions("*,Auto")
                            .Children(
                                new Grid()
                                .Region(attached: true, navigator: "Visibility")
                                .Children(
                                    new Grid()
                                        .Children(
                                            new TextBlock()
                                            .Text("Home")
                                            .FontSize(30)
                                            .HorizontalAlignment(HorizontalAlignment.Center)
                                            .VerticalAlignment(VerticalAlignment.Center))
                                        .Visibility(Visibility.Collapsed)
                                        .Region(name: "home"),

                                    new Grid()
                                        .Children(
                                            new TextBlock()
                                            .Text("Rates")
                                            .FontSize(30)
                                            .HorizontalAlignment(HorizontalAlignment.Center)
                                            .VerticalAlignment(VerticalAlignment.Center))
                                        .Visibility(Visibility.Collapsed)
                                        .Region(name: "rates"),

                                    new Grid()
                                        .Children(
                                            new TextBlock()
                                            .Text("Settngs")
                                            .FontSize(30)
                                            .HorizontalAlignment(HorizontalAlignment.Center)
                                            .VerticalAlignment(VerticalAlignment.Center))
                                        .Visibility(Visibility.Collapsed)
                                        .Region(name: "settings")
                                    ),
                                     new TabBar()
                                         .Grid(row: 1)
                                         .Region(attached: true)
                                         .Name("tabBar")
                                         .Assign(out TabBar tabBar)
                                         //.Style(Uno.Toolkit.UI.Markup.Theme.TabBar.Styles.Bottom)
                                         .VerticalAlignment(VerticalAlignment.Bottom)
                                         .Items(
                                             new TabBarItem()
                                                 .Icon(new SymbolIcon(Symbol.Home))
                                                 .Style(StaticResource.Get<Style>("MaterialBottomTabBarItemStyle"))
                                                 .Region(name: "home"),
                                             new TabBarItem()
                                                 .Icon(new SymbolIcon(Symbol.Contact))
                                                 .Style(StaticResource.Get<Style>("MaterialBottomTabBarItemStyle"))
                                                 .Region(name: "rates"),
                                             new TabBarItem()
                                                 .Icon(new SymbolIcon(Symbol.Shop))
                                                 .Style(StaticResource.Get<Style>("MaterialBottomTabBarItemStyle"))
                                                 .Region(name: "settings")
                                         )
                                         .Visibility(Visibility.Visible)
                             )
                    )
                    .VisualStateManager(vsm =>
                        vsm.Group("vsm_group", grid =>
                        {
                            grid.State(name: "Narrow", state =>
                            {
                                //state.Setters(tabBar, tb => tb.Visibility(Visibility.Visible));
                                state.Setters(NavView, nv => nv.IsPaneToggleButtonVisible(false));
                                state.Setters(NavView, nv => nv.PaneDisplayMode(NavigationViewPaneDisplayMode.LeftMinimal));
                                state.Setters(NavView, nv => nv.IsPaneOpen(false));
                            });
                            grid.State(name: "Normal", state =>
                            {
                                state.StateTriggers(new AdaptiveTrigger().MinWindowWidth(700));
                                //.Setters(tabBar, tb => tb.Visibility(Visibility.Collapsed))
                                state.Setters(NavView, nv => nv.IsPaneToggleButtonVisible(true));
                                state.Setters(NavView, nv => nv.PaneDisplayMode(NavigationViewPaneDisplayMode.Auto));
                                state.Setters(NavView, nv => nv.IsPaneOpen(true));
                            });
                            grid.State(name: "Wide", state =>
                            {
                                state.StateTriggers(new AdaptiveTrigger().MinWindowWidth(1000));
                                //.Setters(tabBar, tb => tb.Visibility(Visibility.Collapsed))
                                state.Setters(NavView, nv => nv.IsPaneToggleButtonVisible(true));
                                state.Setters(NavView, nv => nv.PaneDisplayMode(NavigationViewPaneDisplayMode.Auto));
                                state.Setters(NavView, nv => nv.IsPaneOpen(true));
                            });
                        })
                    )
                )
            )
        );
    }
}
