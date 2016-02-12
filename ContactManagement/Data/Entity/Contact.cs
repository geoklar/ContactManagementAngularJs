using System.ComponentModel.DataAnnotations;
namespace ContactManagement.Data.Entity
{
    public class Contact : IEntity<int>
    {
        public int ContactId { get; set; }

        public string FirstName { get; set; }

        public string MiddleName { get; set; }

        public string LastName { get; set; }

        public string CompanyName { get; set; }

        public string Email { get; set; }

        public string WorkPhone { get; set; }

        public string CellPhone { get; set; }

        public Category Category { get; set; }

        public System.DateTime? BirthDate { get; set; }

        public int Identity
        {
            get { return this.ContactId; }
        }
    }
}