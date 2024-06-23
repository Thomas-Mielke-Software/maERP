using maERP.SharedUI.Contracts;
using maERP.SharedUI.Models.Warehouse;
using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace maERP.SharedUI.Pages.Warehouses;

public partial class WarehousesEdit
{
    [Inject]
    public required NavigationManager _navigationManager { get; set; }

    [Inject]
    public required IWarehouseService _warehouseService { get; set; }

    [Parameter]
    public int warehouseId { get; set; }

    // ReSharper disable once NotAccessedField.Local
    MudForm? _form;

    // ReSharper disable once NotAccessedField.Local
    protected string Title = "hinzufügen";

    protected WarehouseVM warehouse = new();

    protected override async Task OnParametersSetAsync()
    {
        if (warehouseId != 0)
        {
            Title = "Bearbeiten";
            warehouse = await _warehouseService.GetWarehouseDetails(warehouseId);
        }
    }

    protected async Task Save()
    {
        if (warehouseId != 0)
        {
            await _warehouseService.UpdateWarehouse(warehouseId, warehouse);
        }
        else
        {
            await _warehouseService.CreateWarehouse(warehouse);
        }

        NavigateToList();
    }

    public void NavigateToList()
    {
        StateHasChanged();
        _navigationManager.NavigateTo("/Warehouses");
    }
}