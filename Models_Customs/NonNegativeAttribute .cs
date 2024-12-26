using System.ComponentModel.DataAnnotations;

namespace TylorShop.Models_Customs
{

    public class NonNegativeAttribute : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value is double due && due < 0)
            {
                return new ValidationResult("Due cannot be less than 0.");
            }

            return ValidationResult.Success;
        }
    }
}
