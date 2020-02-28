using DocuWare.Api.Models.Department;
using DocuWare.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocuWare.Queries.Queries
{
    public interface IDepartmentQueryProceesor
    {
        IQueryable<Department> Get();
        Department Get(int id);
        Task<Department> Create(CreateUpdateDepartmentModel model);
        Task<Department> Update(int id, CreateUpdateDepartmentModel model);
        Task Delete(int id);
    }
}
