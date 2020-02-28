using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DocuWare.Api.Models.User
{
    public class CreateUpdateUserModel
    {
        public CreateUpdateUserModel()
        {

        }

        [Required]
        public string UserName { get; set; }
        
        [Required]
        public string Identification { get; set; }

        [Required]
        public int DepartmentId { get; set; }
    }
}
