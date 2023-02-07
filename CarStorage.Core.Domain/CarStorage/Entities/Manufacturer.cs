using CarStorage.Core.Domain.Common.Constants;

namespace CarStorage.Core.Domain.CarStorage.Entities
{
    public class Manufacturer
    {
        private Manufacturer(
            string name)
        {
            Validate(name);

            Name = name;
        }

        public int Id { get; private set; }

        public string Name { get; private set; }

        public ICollection<Car> Cars { get; private set; }

        public static Manufacturer Create(string name)
        {
            var manufacturer = new Manufacturer(name);

            return manufacturer;
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
