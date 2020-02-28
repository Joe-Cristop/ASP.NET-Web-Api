using DocuWare.Data.Access.Maps.Common;
using DocuWare.Data.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DocuWare.Data.Access.Maps.Main
{
    public class UserMap : IMap
    {
        public void Visit(ModelBuilder builder)
        {
            builder.Entity<User>().ToTable("Users").HasKey(x => x.Id);
        }
    }
}
