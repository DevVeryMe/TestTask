using System;
using System.ComponentModel.DataAnnotations;
using TestTask.Constants;

namespace TestTask.Models
{
    public class UpdateUserViewModel
    {
        [Required]
        [Range(0, int.MaxValue)]
        public int Id { get; set; }

        [StringLength(maximumLength: 50, ErrorMessage = ErrorConstants.MaxLengthError)]
        public string Name { get; set; }

        [DataType(DataType.Date)]
        public DateTimeOffset BirthDate { get; set; }

        public bool IsMarried { get; set; }

        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$",
            ErrorMessage = ErrorConstants.InvalidPhoneNumberError)]
        public string PhoneNumber { get; set; }

        [DataType(DataType.Currency)]
        public decimal Salary { get; set; }
    }
}
