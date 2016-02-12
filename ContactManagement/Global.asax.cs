using ContactManagement.Data.Entity;
using ContactManagement.Data.Repository;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace ContactManagement
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            MockCategoryRepository.Entities = new List<Category> {
                new Category { CategoryId = 1, Name = "Family" },
                new Category { CategoryId = 2, Name = "Friends" },
                new Category { CategoryId = 3, Name = "Coworkers" },
                new Category { CategoryId = 4, Name = "Classmates" }
            };

            MockContactRepository.Entities = new List<Contact> {
                new Contact { ContactId = 1, FirstName = "Homer", MiddleName = "J", LastName = "Simpson", CompanyName = "Springfield Nuclear Power", Email = "homerj@gmail.com", WorkPhone = "4135551234", CellPhone = "4135554321", Category = MockCategoryRepository.Entities.Single(c=>c.CategoryId==1) },
                new Contact { ContactId = 2, FirstName = "Marge", MiddleName = "Bouvier", LastName = "Simpson", CompanyName = "Simpson Household", Email = "bigblue@gmail.com", WorkPhone = "2175553164", CellPhone = "2175559764", Category = MockCategoryRepository.Entities.Single(c=>c.CategoryId==1) },
                new Contact { ContactId = 3, FirstName = "Lisa", MiddleName = null, LastName = "Simpson", CompanyName = "Springfield Elementary", Email = "saxamaphone@mapple.com", WorkPhone = "3145557412", CellPhone = "3145559632", Category = MockCategoryRepository.Entities.Single(c=>c.CategoryId==1) },
                new Contact { ContactId = 4, FirstName = "Maggie", MiddleName = null, LastName = "Simpson", CompanyName = null, Email = "piciface@gmail.com", WorkPhone = "4135559876", CellPhone = "4135556789", Category = MockCategoryRepository.Entities.Single(c=>c.CategoryId==1) },
                new Contact { ContactId = 5, FirstName = "C", MiddleName = "Montgomery", LastName = "Burns", CompanyName = "Springfield Nuclear Power", Email = "eeexcellent@moneybags.com", WorkPhone = "2175551111", CellPhone = "2175551112", Category = MockCategoryRepository.Entities.Single(c=>c.CategoryId==3) },
                new Contact { ContactId = 6, FirstName = "Waylon", MiddleName = null, LastName = "Smithers", CompanyName = "Springfield Nuclear Power", Email = "postmaster@ilovemonty.com", WorkPhone = "8165558624", CellPhone = "8165558426", Category = MockCategoryRepository.Entities.Single(c=>c.CategoryId==3) },
                new Contact { ContactId = 7, FirstName = "Ralph", MiddleName = null, LastName = "Wiggum", CompanyName = "Springfield Elementary", Email = "ilovepaste@aol.com", WorkPhone = "3145550000", CellPhone = "3145550000", Category = MockCategoryRepository.Entities.Single(c=>c.CategoryId==4) },
                new Contact { ContactId = 8, FirstName = "Lenford", MiddleName = null, LastName = "Leonard", CompanyName = "Springfield Nuclear Power", Email = "lenny@gmail.com", WorkPhone = "4135556547", CellPhone = "4135554569", Category = MockCategoryRepository.Entities.Single(c=>c.CategoryId==2) },
                new Contact { ContactId = 9, FirstName = "Carlton", MiddleName = "", LastName = "Carlson", CompanyName = "Springfield Nuclear Power", Email = "carl@gmail.com", WorkPhone = "8165559515", CellPhone = "8165557535", Category = MockCategoryRepository.Entities.Single(c=>c.CategoryId==2) },
                new Contact { ContactId = 10, FirstName = "Barney", MiddleName = null, LastName = "Gumble", CompanyName = "Be Sharp", Email = "buuuurp@duff.com", WorkPhone = "2175553344", CellPhone = "2175559988", Category = MockCategoryRepository.Entities.Single(c=>c.CategoryId==2) }
            };
        }
    }
}