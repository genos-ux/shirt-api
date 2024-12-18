using System.ComponentModel.DataAnnotations;

namespace shirt_api.Models.Validations
{
    public class Shirt_EnsureCorrectSizingAttribute : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            var shirt = validationContext.ObjectInstance as Shirt;

            if(shirt != null && !string.IsNullOrWhiteSpace(shirt.Gender))
            {
                if(shirt.Gender.Equals("men") && shirt.Size < 8)
                {
                    return new ValidationResult("The size has to be greater or equal to 8.");
                }

                else if(shirt.Gender.Equals("women") && shirt.Size < 6)
                {
                    return new ValidationResult("The size has to be greater or equal to 6.");

                }
            }

            return ValidationResult.Success;
        }
    }
}
