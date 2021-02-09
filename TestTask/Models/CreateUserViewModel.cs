using System;
using System.ComponentModel.DataAnnotations;
using TestTask.Constants;

namespace TestTask.Models
{
    public class CreateUserViewModel
    {
        [Required(ErrorMessage = ErrorConstants.RequiredFieldError)]
        [StringLength(maximumLength: 50, ErrorMessage = ErrorConstants.MaxLengthError)]
        public string Name { get; set; }

        [Required(ErrorMessage = ErrorConstants.RequiredFieldError)]
        public DateTimeOffset BirthDate { get; set; }

        [Required(ErrorMessage = ErrorConstants.RequiredFieldError)]
        public bool IsMarried { get; set; }

        [Required(ErrorMessage = ErrorConstants.RequiredFieldError)]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", 
            ErrorMessage = ErrorConstants.InvalidPhoneNumberError)]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = ErrorConstants.RequiredFieldError)]
        [DataType(DataType.Currency)]
        public decimal Salary { get; set; }
    }
}
