namespace CarStorage.Api.Models.Cars
{
    public class ApiCreateCarModel
    {
        public string Model { get; set; }

        public string ImageUrl { get; set; }

        public string Description { get; set; }

        public int ManufacturerId { get; set; }

        public int CategoryId { get; set; }
    }
}
