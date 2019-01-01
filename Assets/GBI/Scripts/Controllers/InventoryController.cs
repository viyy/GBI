namespace Geekbrains {
    /// <summary>
    /// Класс конроллера инвентаря персонажа
    /// </summary>
    /// <see cref="BaseController{T}"/> <br/>
    /// <see cref="InventoryModel"/>
    public class InventoryController : BaseController<InventoryModel>
    {
        public InventoryController(InventoryModel inventoryModel) : base(inventoryModel) {}
    }
}