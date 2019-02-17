using GFShop.DataAccessLayer.Entities;
using GFShop.DataAccessLayer.Repositories.Interfaces;

namespace GFShop.DataAccessLayer.Repositories
{
    public class InventoryRepository: RepositoryBase, IInventoryRepository
    {
        public InventoryRepository(GFStoreContext Context) : base(Context)
        {

        }

        public Inventory Create(Inventory Inventory)
        {
            _context.Inventory.Add(Inventory);
            _context.SaveChanges();

            return Inventory;
        }
    }
}