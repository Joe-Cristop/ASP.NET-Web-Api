using DocuWare.Api.Common.Exceptions;
using DocuWare.Api.Models.Department;
using DocuWare.Data.Access.DAL;
using DocuWare.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocuWare.Queries.Queries
{
    class DepartmentQueryProcessor : IDepartmentQueryProceesor
    {
        private readonly IUnitOfWork _uow;

        public DepartmentQueryProcessor(IUnitOfWork uow)
        {
            _uow = uow;
        }

        private IQueryable<Department> GetQuery()
        {
            return _uow.Query<Department>().Where(x => !x.IsDeleted);
        }

        public async Task<Department> Create(CreateUpdateDepartmentModel model)
        {
            if (GetQuery().Any(u => u.ParentId == model.ParentId && u.Name.Equals(model.Name.Trim())))
            {
                throw new BadRequestException("Same department is already in use.");
            }

            Department parent = GetQuery().FirstOrDefault(x => x.Id == model.ParentId);

            if (null == parent)
            {
                throw new BadRequestException("Super department does not exist.");
            }

            Department department = new Department
            {
                Name = model.Name.Trim(),
                ParentId = model.ParentId,
                Hierachy = parent.Hierachy,
                Enabled = parent.Enabled,
            };

            _uow.Add(department);
            await _uow.CommitAsync();
            department.Hierachy = parent.Hierachy + department.Id + ".";
            _uow.Update(department);
            await _uow.CommitAsync();
            return department;
        }

        public async Task Delete(int id)
        {
            Department department = GetQuery().FirstOrDefault(d => d.Id == id);

            if (null == department)
            {
                throw new NotFoundException("Department is not found");
            }

            if (department.IsDeleted) return;
            department.IsDeleted = true;
            await _uow.CommitAsync();
        }

        public IQueryable<Department> Get()
        {
            return GetQuery().OrderBy(x => x.Hierachy);
        }

        public Department Get(int id)
        {
            Department department = GetQuery().FirstOrDefault(x => x.Id == id);

            if (null == department)
            {
                throw new NotFoundException("Depart is not found");
            }

            return department;
        }

        public async Task<Department> Update(int id, CreateUpdateDepartmentModel model)
        {
            Department department = GetQuery().FirstOrDefault(d => d.Id == id);

            if (null == department)
            {
                throw new NotFoundException("Department is not found");
            }

            Department newParent = GetQuery().FirstOrDefault(d => d.Id == model.ParentId);

            if (null == newParent)
            {
                throw new NotFoundException("Super department is not found");
            }

            string newHierachy = newParent.Hierachy + department.Id + ".";

            IQueryable<Department> children = GetQuery().Where(d => d.Id != department.Id && d.Hierachy.StartsWith(department.Hierachy));

            foreach (Department child in children)
            {
                child.Hierachy = newHierachy + child.Hierachy.Substring(department.Hierachy.Length);
            }

            department.Name = model.Name.Trim();
            department.ParentId = model.ParentId;
            department.Hierachy = newHierachy;
            department.Enabled = model.Enabled;

            await _uow.CommitAsync();

            return department;
        }
    }
}
