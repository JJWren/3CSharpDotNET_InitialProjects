using System;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

public class AliasValid : ValidationAttribute
{
    protected override ValidationResult IsValid(object alias, ValidationContext validationContext)
    {
        if (alias == null)
        {
            return new ValidationResult("Name is required");
        }
        else
        {
            bool IsNameValid(string inputString)
            {
                Regex aliasPattern = new Regex(@"^([a-zA-Z0-9]+)$");
                if (aliasPattern.IsMatch(inputString))
                    return true;
                else
                    return false;
            }
            if (IsNameValid((string)alias) == true)
            {
                return ValidationResult.Success;
            }
            else
            {
                return new ValidationResult("Alias must only contain letters and numbers");
            }
        }
    }
}