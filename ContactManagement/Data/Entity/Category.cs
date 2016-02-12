namespace ContactManagement.Data.Entity
{
    public class Category : IEntity<int>
    {
        public int CategoryId { get; set; }

        public string Name { get; set; }

        public int Identity
        {
            get { return this.CategoryId; }
        }
    }
}