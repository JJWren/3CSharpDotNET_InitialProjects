using System;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

public class NameValid : ValidationAttribute
{
    protected override ValidationResult IsValid(object name, ValidationContext validationContext)
    {
        if (name == null)
        {
            return new ValidationResult("Name is required");
        }
        else
        {
            bool IsNameValid(string inputString)
            {
                Regex namePattern = new Regex(@"^([a-zA-Z ]+)$");
                if (namePattern.IsMatch(inputString))
                    return true;
                else
                    return false;
            }
            if (IsNameValid((string)name) == true)
            {
                return ValidationResult.Success;
            }
            else
            {
                return new ValidationResult("Name must only contain letters and spaces");
            }
        }
    }
}