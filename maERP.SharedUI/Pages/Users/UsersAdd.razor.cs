using maERP.SharedUI.Models.User;
using Microsoft.AspNetCore.Components;

namespace maERP.SharedUI.Pages.Users;

public partial class UsersAdd
{

    [Parameter]
    public string userId { get; set; } = "";

    protected string Title = "hinzuf�gen";

    protected UserVM user = new();

    protected async Task Save()
    {
        await _userService.CreateUser(user);
        ReturnToList();
    }

    public void ReturnToList()
    {
        _navigationManager.NavigateTo("/users");
    }
}