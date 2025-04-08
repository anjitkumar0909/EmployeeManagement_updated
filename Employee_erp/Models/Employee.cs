using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Employee_erp.Models
{
    public partial class Employee
    {
        public int EmployeeId { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "Invalid email format.")]
        public string Email { get; set; } = null!;
        public string Phone { get; set; } = null!;
        public int? DepartmentId { get; set; }

        public virtual Department? Department { get; set; } /*= null!;*/

    }
}
