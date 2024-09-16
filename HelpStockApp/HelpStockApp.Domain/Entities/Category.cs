using HelpStockApp.Domain.Validation;

namespace HelpStockApp.Domain.Entities
{
    public class Category : Entity
    {
        public string Name { get; set; }

        public Category(string name)
        {
            ValidationDomain(name);

        }

        public Category(int id, string name)
        {
            DomainExceptionValidation.When(id < 0, "Invalid Id Value");
            DomainExceptionValidation.When(id.GetType()==typeof(string), "Invalid Id, Int Type Required");
            DomainExceptionValidation.When(id == null, "Id Is Required");
            Id = id;
            ValidationDomain(name);
        }

        public ICollection<Product> Products { get; set; }

        private void ValidationDomain(string name)
        {
            DomainExceptionValidation.When(string.IsNullOrEmpty(name), "Invalid name, name is required");
            DomainExceptionValidation.When(name.Length < 3, "Invalid name,  too short, Minimum 3 characters");
            DomainExceptionValidation.When(name == null, "Invalid name, name is required");

            Name = name;
        }


    }
 
}
