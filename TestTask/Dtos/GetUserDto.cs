﻿using System;

namespace TestTask.Dtos
{
    public class GetUserDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public DateTimeOffset BirthDate { get; set; }

        public bool IsMarried { get; set; }

        public string PhoneNumber { get; set; }

        public decimal Salary { get; set; }
    }
}
