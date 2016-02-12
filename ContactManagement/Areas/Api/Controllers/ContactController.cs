using ContactManagement.Areas.Api.Models;
using ContactManagement.Data.Repository;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace ContactManagement.Areas.Api.Controllers
{
    public class ContactController : ApiController
    {
        private readonly IRestRepository<Data.Entity.Contact, int> _contactRepository;

        public ContactController()
        {
            this._contactRepository = new MockContactRepository();
        }

        // GET: api/Contact
        public IEnumerable<ContactModel> Get()
        {
            var entities = this._contactRepository.GetAll();
            return entities.Select(e => new ContactModel(e));
        }

        // GET: api/Contact/5
        public ContactModel Get(int id)
        {
            var entity = this._contactRepository.Get(id);
            return new ContactModel(entity);
        }

        // POST: api/Contact
        [System.Web.Http.Description.ResponseType(typeof(ContactPostModel))] 
        public IHttpActionResult Post([FromBody]ContactPostModel value)
        {
            //Checking if ModelState is invalid and throw exception
            if (!ModelState.IsValid)
            {
                //If ModelState fails validation, returns validation error response
                return BadRequest(ModelState);
            } 
            var entity = this._contactRepository.Post(value.ToEntity());
            //If ModelState validation is successed, returns as a response the Action API name, Contact Id and the model
            return CreatedAtRoute("DefaultApi", new { id = entity.ContactId }, new ContactModel(entity));
        }

        // PUT: api/Contact/5
        [System.Web.Http.Description.ResponseType(typeof(ContactPutModel))] 
        public IHttpActionResult Put([FromBody]ContactPutModel value)
        {
            //Checking if ModelState is invalid and throw exception
            if (!ModelState.IsValid)
            {
                //If ModelState fails validation, returns validation error response
                return BadRequest(ModelState);
            }
            this._contactRepository.Put(value.ToEntity());
            //If ModelState validation is successed, returns as a response the Action API name, Contact Id and the model
            return CreatedAtRoute("DefaultApi", new { id = value.ToEntity().ContactId }, new ContactModel(value.ToEntity()));
        }

        // DELETE: api/Contact/5
        public bool Delete([FromBody]ContactDeleteModel value)
        {
            var resp = this._contactRepository.Delete(value.ToEntity());
            return resp;
        }
    }
}