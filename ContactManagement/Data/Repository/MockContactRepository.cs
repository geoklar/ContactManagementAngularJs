using ContactManagement.Data.Entity;
using System.Linq;

namespace ContactManagement.Data.Repository
{
    public class MockContactRepository : BaseMockRestRepository<Contact, int>
    {
        private int _nextId;

        public MockContactRepository()
        {
            this._nextId = 0;
        }

        public override Contact Post(Contact entity)
        {
            entity.ContactId = this.GetNextId();
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