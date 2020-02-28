using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DocuWare.Api.Models.User;
using DocuWare.Data.Model;
using DocuWare.Filters;
using DocuWare.Maps;
using DocuWare.Queries.Queries;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DocuWare.Controllers
{
    [Route("api/[controller]")]
    public class UserController : Controller
    {
        private readonly IUserQueryProcessor _query;
        private readonly IAutoMapper _mapper;

        public UserController(IUserQueryProcessor query, IAutoMapper mapper)
        {
            _query = query;
            _mapper = mapper;
        }

        [HttpGet]
        public IQueryable<UserModel> Get()
        {
            IQueryable<User> result = _query.Get();
            IQueryable<UserModel> models = _mapper.Map<User, UserModel>(result);
            return models;
        }

        [HttpGet("{id}")]
        public UserModel Get(int id)
        {
            User item = _query.Get(id);
            UserModel model = _mapper.Map<UserModel>(item);
            return model;
        }

        [HttpPost]
        [ValidateModel]
        public async Task<UserModel> Post([FromBody]CreateUpdateUserModel requestModel)
        {
            User item = await _query.Create(requestModel);
            UserModel model = _mapper.Map<UserModel>(item);
            return model;
        }

        [HttpPut("{id}")]
        [ValidateModel]
        public async Task<UserModel> Put(int id, [FromBody]CreateUpdateUserModel requestModel)
        {
            User item = await _query.Update(id, requestModel);
            UserModel model = _mapper.Map<UserModel>(item);
            return model;
        }

        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await _query.Delete(id);
        }
    }
}