using CarStorage.Core.Domain.Common.Constants;

namespace CarStorage.Core.Domain.CarStorage.Entities
{
    public class Category
    {
        private Category(string name, string description)
        {
            Validate(name, description);

            Name = name;
            Description = description;
        }

        public int Id { get; private set; }

        public string Name { get; private set; }

        public string Description { get; private set; }

        public ICollection<Car> Cars { get; private set; }

        private static Category Create(string name, string description)
        {
            var category = new Category(name, description);

            return category;
        }

        private static void Validate(string name, string description)
        {
            if (name == null || name.Length > ModelConstants.Common.MaxNameLength)
            {
                throw new ArgumentException("The provided name is incorrect.");
            }

            if (description.Length > ModelConstants.Common.MaxDescriptionLength)
            {
                throw new ArgumentException("The description exceeds the allowed length.");
            }
        }
    }
}
