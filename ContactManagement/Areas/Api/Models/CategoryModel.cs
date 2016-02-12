using System.Runtime.Serialization;

namespace ContactManagement.Areas.Api.Models
{
    [DataContract]
    public class CategoryModel
    {
        public CategoryModel()
        { }

        public CategoryModel(Data.Entity.Category entity)
        {
            this.CategoryId = entity.CategoryId;
            this.Name = entity.Name;
        }

        [DataMember]
        public int CategoryId { get; set; }

        [DataMember]
        public string Name { get; set; }

        public Data.Entity.Category ToEntity()
        {
            return new Data.Entity.Category
            {
                CategoryId = this.CategoryId,
                Name = this.Name
            };
        }
    }
}