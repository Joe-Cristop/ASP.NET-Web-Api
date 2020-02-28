using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace DocuWare.Api.Models.Department
{
    public class DepartmentModel
    {
        public DepartmentModel()
        {
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int ParentId { get; set; }

        public string Hierachy { get; set; }
        [DefaultValue(true)]
        public bool Enabled { get; set; }
    }
}
