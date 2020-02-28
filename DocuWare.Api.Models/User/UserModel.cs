using System;
using System.Collections.Generic;
using System.Text;

namespace DocuWare.Api.Models.User
{
    public class UserModel
    {
        public UserModel()
        {

        }

        public int Id { get; set; }
        public string UserName { get; set; }
        public string Identification { get; set; }
        public string DepartmentId { get; set; }
    }
}
