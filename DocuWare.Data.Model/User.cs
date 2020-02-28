using System;

namespace DocuWare.Data.Model
{
    public class User : CommonModel
    {
        public User()
        {

        }

        public string UserName { get; set; }
        public string Identification { get; set; }
        public int DepartmentId { get; set; }
        public virtual Department Department { get; set; }
    }
}
