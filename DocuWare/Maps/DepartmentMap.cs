using AutoMapper;
using DocuWare.Api.Models.Department;
using DocuWare.Data.Model;
using DocuWare.Maps;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DocuWare.Maps
{
    public class DepartmentMap : IAutoMapperTypeConfigurator
    {
        public void Configure(IMapperConfigurationExpression configuration)
        {
            configuration.CreateMap<Department, DepartmentModel>();
        }
    }
}
