using System.Runtime.Serialization;
using System.ComponentModel.DataAnnotations;

namespace ContactManagement.Areas.Api.Models
{
    public class ContactModel
    {
        public ContactModel(Data.Entity.Contact entity)
        {
            this.ContactId = entity.ContactId;
            this.FirstName = entity.FirstName;
            this.MiddleName = entity.MiddleName;
            this.LastName = entity.LastName;
            this.CompanyName = entity.CompanyName;
            this.Email = entity.Email;
            this.WorkPhone = entity.WorkPhone;
            this.CellPhone = entity.CellPhone;
            this.Category = new CategoryModel(entity.Category);
            this.BirthDate = entity.BirthDate;
        }

        public int ContactId { get; set; }

        [Required(ErrorMessage = "First Name is Required")]
        public string FirstName { get; set; }

        public string MiddleName { get; set; }

        [Required(ErrorMessage = "Last Name is Required")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Company Name is Required")]
        public string CompanyName { get; set; }

        [Required(ErrorMessage = "Email is Required")]
        [RegularExpression(@"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}" +
                            @"\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\" +
                            @".)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$",
                            ErrorMessage = "Email is not valid")]
        public string Email { get; set; }

        public string WorkPhone { get; set; }

        public string CellPhone { get; set; }

        public CategoryModel Category { get; set; }

        public System.DateTime? BirthDate { get; set; }
    }

    [DataContract]
    public class ContactPostModel
    {
        [DataMember]
        [Required(ErrorMessage = "First Name is Required")]
        public string FirstName { get; set; }

        [DataMember]
        public string MiddleName { get; set; }

        [DataMember]
        [Required(ErrorMessage = "Last Name is Required")]
        public string LastName { get; set; }

        [DataMember]
        [Required(ErrorMessage = "Company Name is Required")]
        public string CompanyName { get; set; }

        [DataMember]
        [Required(ErrorMessage = "Email is Required")]
        [RegularExpression(@"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}" +
                            @"\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\" +
                            @".)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$",
                            ErrorMessage = "Email is not valid")]
        public string Email { get; set; }

        [DataMember]
        public string WorkPhone { get; set; }

        [DataMember]
        public string CellPhone { get; set; }

        [DataMember]
        public CategoryModel Category { get; set; }

        [DataMember]
        public System.DateTime? BirthDate { get; set; }

        public Data.Entity.Contact ToEntity()
        {
            return new Data.Entity.Contact
            {
                FirstName = this.FirstName,
                MiddleName = this.MiddleName,
                LastName = this.LastName,
                CompanyName = this.CompanyName,
                Email = this.Email,
                WorkPhone = this.WorkPhone,
                CellPhone = this.CellPhone,
                Category = this.Category.ToEntity(),
                BirthDate = this.BirthDate
            };
        }
    }

    [DataContract]
    public class ContactPutModel
    {
        [DataMember]
        public int ContactId { get; set; }

        [DataMember]
        [Required(ErrorMessage = "First Name is Required")]
        public string FirstName { get; set; }

        [DataMember]
        public string MiddleName { get; set; }

        [DataMember]
        [Required(ErrorMessage = "Last Name is Required")]
        public string LastName { get; set; }

        [DataMember]
        [Required(ErrorMessage = "Company Name is Required")]
        public string CompanyName { get; set; }

        [DataMember]
        [Required(ErrorMessage = "Email is Required")]
        [RegularExpression(@"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}" +
                            @"\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\" +
                            @".)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$",
                            ErrorMessage = "Email is not valid")]
        public string Email { get; set; }

        [DataMember]
        public string WorkPhone { get; set; }

        [DataMember]
        public string CellPhone { get; set; }

        [DataMember]
        public CategoryModel Category { get; set; }

        [DataMember]
        public System.DateTime? BirthDate { get; set; }

        public Data.Entity.Contact ToEntity()
        {
            return new Data.Entity.Contact
            {
                ContactId = this.ContactId,
                FirstName = this.FirstName,
                MiddleName = this.MiddleName,
                LastName = this.LastName,
                CompanyName = this.CompanyName,
                Email = this.Email,
                WorkPhone = this.WorkPhone,
                CellPhone = this.CellPhone,
                Category = this.Category.ToEntity(),
                BirthDate = this.BirthDate
            };
        }
    }

    [DataContract]
    public class ContactDeleteModel
    {
        [DataMember]
        public int ContactId { get; set; }

        [DataMember]
        public string FirstName { get; set; }

        [DataMember]
        public string MiddleName { get; set; }

        [DataMember]
        public string LastName { get; set; }

        [DataMember]
        public string CompanyName { get; set; }

        [DataMember]
        public string Email { get; set; }

        [DataMember]
        public string WorkPhone { get; set; }

        [DataMember]
        public string CellPhone { get; set; }

        [DataMember]
        public CategoryModel Category { get; set; }

        [DataMember]
        public System.DateTime? BirthDate { get; set; }

        public Data.Entity.Contact ToEntity()
        {
            return new Data.Entity.Contact
            {
                ContactId = this.ContactId,
                FirstName = this.FirstName,
                MiddleName = this.MiddleName,
                LastName = this.LastName,
                CompanyName = this.CompanyName,
                Email = this.Email,
                WorkPhone = this.WorkPhone,
                CellPhone = this.CellPhone,
                Category = this.Category.ToEntity(),
                BirthDate = this.BirthDate
            };
        }
    }
}