using ContactManagement.Data.Entity;
using System.Linq;

namespace ContactManagement.Data.Repository
{
    public class MockCategoryRepository : BaseMockRestRepository<Category, int>
    {
        private int _nextId;

        public MockCategoryRepository()
        {
            this._nextId = 0;
        }

        public override Category Post(Category entity)
        {
            entity.CategoryId = this.GetNextId();
            return base.Post(entity);
        }

        private int GetNextId()
        {
            this._nextId++;
            while (this.GetAll().Any(c => c.Identity == this._nextId)) { this._nextId++; }
            return this._nextId;
        }
    }
}