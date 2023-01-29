using CarStorage.Core.Domain.Common.Constants;

namespace CarStorage.Core.Domain.CarStorage.Entities
{
    public class Car
    {
        private Car(
            string model,
            string imageUrl,
            string description,
            int categoryId,
            int manufacturerId)
        {
            Validate(
                model,
                imageUrl,
                description,
                categoryId,
                manufacturerId);

            Model = model;
            ImageUrl = imageUrl;
            Description = description;
            CategoryId = categoryId;
            ManufacturerId = manufacturerId;
        }

        public int Id { get; set; }

        public string Model { get; set; }

        public string ImageUrl { get; set; }

        public int ManufacturerId { get; set; }

        public int CategoryId { get; set; }

        public string Description { get; set; }

        public Manufacturer Manufacturer { get; set; }

        public Category Category { get; set; }

        public static Car Create(
            string model,
            string imageUrl,
            string description,
            int categoryId,
            int manufacturerId)
        {
            var car = new Car(
                model,
                imageUrl,
                description,
                categoryId,
                manufacturerId);

            return car;
        }

        public Car UpdateModel(string model)
        {
            if (Model != model)
            {
                if (model.Length > ModelConstants.Common.MaxModelLength)
                {
                    throw new ArgumentException("The model exceeds the allowed length.");
                }
            }

            return this;
        }

        public Car UpdateImageUrl(string imageUrl)
        {
            if (ImageUrl != imageUrl)
            {
                if (imageUrl.Length > ModelConstants.Common.MaxImageUrlLenght)
                {
                    throw new ArgumentException("The image url exceeds the allowed length.");
                }

                ImageUrl = imageUrl;
            }

            return this;
        }

        public Car UpdateDescription(string description)
        {
            if (Description != description)
            {
                if (description.Length > ModelConstants.Common.MaxDescriptionLength)
                {
                    throw new ArgumentException("The description exceeds the allowed length.");
                }

                Description = description;
            }

            return this;
        }

        private static void Validate(
            string model,
            string imageUrl,
            string description,
            int categoryId,
            int manufacturerId)
        {
            if (model == null || model.Length > ModelConstants.Common.MaxModelLength)
            {
                throw new ArgumentException("The provided model is incorrect.");
            }

            if (imageUrl.Length > ModelConstants.Common.MaxImageUrlLenght)
            {
                throw new ArgumentException("The image url exceeds the allowed length.");
            }

            if (description.Length > ModelConstants.Common.MaxDescriptionLength)
            {
                throw new ArgumentException("The description exceeds the allowed length.");
            }

            if (categoryId == default)
            {
                throw new ArgumentException("The provided category identifier is incorrect.");
            }

            if (manufacturerId == default)
            {
                throw new ArgumentException("The manufacturer identifier is incorrect.");
            }
        }
    }
}
