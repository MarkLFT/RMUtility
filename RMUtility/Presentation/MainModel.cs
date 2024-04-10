namespace RMUtility.Presentation;

public partial record MainModel
{
    private readonly INavigator _navigator;

    public MainModel(
        IOptions<AppConfig> appInfo,
        IAuthenticationService authentication,
        INavigator navigator
        )
    {
        _navigator = navigator;
        _authentication = authentication;
        Title = "Main";
        Title += $" - {appInfo?.Value?.Environment}";
    }

    public string? Title { get; }

    public IState<string> Name => State<string>.Value(this, () => string.Empty);

    public async Task GoToSecond()
    {
        var name = await Name;
        await _navigator.NavigateViewModelAsync<SecondModel>(this, data: new Entity(name!));
    }

    public async ValueTask Logout(CancellationToken token)
    {
        await _authentication.LogoutAsync(token);
    }

    private readonly IAuthenticationService _authentication;
}
