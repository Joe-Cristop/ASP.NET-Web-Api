using System;
using System.Collections.Generic;
using System.Text;

namespace DocuWare.Data.Model
{
    public class Department : CommonModel
    {
        public Department()
        {

        }

        public string Name { get; set; }
        public int ParentId { get; set; }
        public string Hierachy { get; set; }
        public bool Enabled { get; set; }
    }
}
