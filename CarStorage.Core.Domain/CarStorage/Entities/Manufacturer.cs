using CarStorage.Core.Domain.Common.Constants;

namespace CarStorage.Core.Domain.CarStorage.Entities
{
    public class Manufacturer
    {
        private Manufacturer(int id, string name)
        {
            Validate(id, name);

            Id = id;
            Name = name;
        }

        private Manufacturer(
            string name)
        {
            Validate(name);

            Name = name;
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public ICollection<Car> Cars { get; set; }

        public static Manufacturer Create(
            int id,
            string name)
        {
            var manufacturer = new Manufacturer(id, name);

            return manufacturer;
        }

        public static Manufacturer Create(string name)
        {
            var manufacturer = new Manufacturer(name);

            return manufacturer;
        }

        private static void Validate(int id, string name)
        {
            if (id == default)
            {
                throw new ArgumentException("The provided id is incorrect.");
            }

            if (name == null || name.Length > ModelConstants.Common.MaxNameLength)
            {
                throw new ArgumentException("The provided name is incorrect.");
            }
        }

        private static void Validate(string name)
        {
            if (name == null || name.Length > ModelConstants.Common.MaxNameLength)
            {
                throw new ArgumentException("The name exceeds the allowed length.");
            }
        }
    }
}
