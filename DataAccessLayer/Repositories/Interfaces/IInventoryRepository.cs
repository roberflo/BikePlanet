using GFShop.DataAccessLayer.Entities;

namespace GFShop.DataAccessLayer.Repositories.Interfaces
{
    public interface IInventoryRepository
    {
          Inventory Create(Inventory Inventory);
    }
}