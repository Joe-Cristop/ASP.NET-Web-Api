using DocuWare.Data.Access.Maps.Common;
using DocuWare.Data.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DocuWare.Data.Access.Maps.Main
{
    public class DepartmentMap : IMap
    {
        public void Visit(ModelBuilder builder)
        {
            builder.Entity<Department>().ToTable("Departments").HasKey(x => x.Id);
        }
    }
}
