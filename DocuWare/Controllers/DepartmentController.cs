using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DocuWare.Api.Models.Department;
using DocuWare.Data.Model;
using DocuWare.Filters;
using DocuWare.Maps;
using DocuWare.Queries.Queries;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DocuWare.Controllers
{
    [Route("api/[controller]")]
    public class DepartmentController : Controller
    {
        private readonly IDepartmentQueryProceesor _query;
        private readonly IAutoMapper _mapper;

        public DepartmentController(IDepartmentQueryProceesor query, IAutoMapper mapper)
        {
            _query = query;
            _mapper = mapper;
        }

        [HttpGet]
        public IQueryable<DepartmentModel> Get()
        {
            IQueryable<Department> result = _query.Get();
            IQueryable<DepartmentModel> models = _mapper.Map<Department, DepartmentModel>(result);
            return models;
        }

        [HttpGet("{id}")]
        public DepartmentModel Get(int id)
        {
            Department item = _query.Get(id);
            DepartmentModel model = _mapper.Map<DepartmentModel>(item);
            return model;
        }

        [HttpPost]
        [ValidateModel]
        public async Task<DepartmentModel> Post([FromBody]CreateUpdateDepartmentModel requestModel)
        {
            Department item = await _query.Create(requestModel);
            DepartmentModel model = _mapper.Map<DepartmentModel>(item);
            return model;
        }

        [HttpPut("{id}")]
        [ValidateModel]
        public async Task<DepartmentModel> Put(int id, [FromBody]CreateUpdateDepartmentModel requestModel)
        {
            Department item = await _query.Update(id, requestModel);
            DepartmentModel model = _mapper.Map<DepartmentModel>(item);
            return model;
        }

        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            //await _query.Delete(id);
        }
    }
}