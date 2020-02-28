using DocuWare.Data.Access.Maps.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Configuration;

namespace DocuWare.Data.Access.DAL
{
    public class MainDbContext : DbContext
    {
        public MainDbContext(DbContextOptions<MainDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            IEnumerable<IMap> mappings = MappingsHelper.GetMainMappings();

            foreach (IMap mapping in mappings)
            {
                mapping.Visit(modelBuilder);
            }
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer("Server=192.168.1.200;Database=docuware;User Id=sa;Password=aaaa;");
        }
    }
}
