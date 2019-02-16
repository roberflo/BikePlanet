using GFShop.DataAccessLayer.Entities;

namespace GFShop.DataAccessLayer.Repositories.Interfaces
{
    public abstract class RepositoryBase
    {
    protected GFStoreContext _context { get; set; }

        public RepositoryBase(GFStoreContext repositoryContext) => this._context = repositoryContext;
    }
}

 
    