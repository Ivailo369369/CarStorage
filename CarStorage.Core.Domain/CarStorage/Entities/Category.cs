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

        private Category(
            int id,
            string name,
            string description)
        {
            Validate(id, name, description);

            Id = id;
            Name = name;
            Description = description;
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public ICollection<Car> Cars { get; set; }

        private static Category Create(
            int id,
            string name,
            string description)
        {
            var category = new Category(id, name, description);

            return category;
        }

        private static Category Create(string name, string description)
        {
            var category = new Category(name, description);

            return category;
        }

        private static void Validate(
            int id,
            string name,
            string description)
        {
            if (id == default)
            {
                throw new ArgumentException("The provided id is incorrect.");
            }

            if (name == null || name.Length > ModelConstants.Common.MaxNameLength)
            {
                throw new ArgumentException("The provided name is incorrect.");
            }

            if (description.Length > ModelConstants.Common.MaxDescriptionLength)
            {
                throw new ArgumentException("The description exceeds the allowed length.");
            }
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
