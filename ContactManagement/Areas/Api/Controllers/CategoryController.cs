using ContactManagement.Areas.Api.Models;
using ContactManagement.Data.Repository;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace ContactManagement.Areas.Api.Controllers
{
    public class CategoryController : ApiController
    {
        private readonly IRestRepository<Data.Entity.Category, int> _categoryRepository;

        public CategoryController()
        {
            this._categoryRepository = new MockCategoryRepository();
        }

        // GET: api/Category
        public IEnumerable<CategoryModel> Get()
        {
            var entities = this._categoryRepository.GetAll();
            return entities.Select(e => new CategoryModel(e));
        }
    }
}