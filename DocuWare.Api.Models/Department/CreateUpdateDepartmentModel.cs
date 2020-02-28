using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DocuWare.Api.Models.Department
{
    public class CreateUpdateDepartmentModel
    {
        public CreateUpdateDepartmentModel()
        {

        }

        [Required]
        public String Name { get; set; }

        [Required]
        public int ParentId { get; set; }

        [Required]
        public bool Enabled { get; set; }
    }
}
