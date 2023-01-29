namespace CarStorage.Core.Application.Dtos.Cars
{
    public class CarDto
    {
        public int Id { get; set; }

        public string Model { get; set; }

        public string ImageUrl { get; set; }

        public string ManufacturerName { get; set; }

        public string CategoryName { get; set; }

        public string Description { get; set; }
    }
}
