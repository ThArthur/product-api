using Flunt.Validations;

namespace AppTreinamento.Domain.Products
{
    public class Category : Entity
    {
        public bool Active { get; private set; }

        public Category(string name, string createdBy, string editedBy)
        {
            Name = name;
            Active = true;
            CreatedBy = createdBy;
            EditedBy = editedBy;
            CreatedOn = DateTime.Now;
            EditedOn = DateTime.Now;

            Validate();         
        }

        private void Validate()
        {
            var contract = new Contract<Category>()
                .IsNotNullOrEmpty(Name, "Nome é Obrigatório!")
                .IsNotNullOrEmpty(CreatedBy, "CreatedBy é Obrigatório!")
                .IsNotNullOrEmpty(EditedBy, "EditedBy é Obrigatório!");

            AddNotifications(contract);
        }

        public void EditInfo(string name, bool active)
        {
            Name = name;
            Active = active;

            Validate();
        }
    }
}
