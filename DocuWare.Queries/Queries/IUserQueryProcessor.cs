using DocuWare.Api.Models.User;
using DocuWare.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocuWare.Queries.Queries
{
    public interface IUserQueryProcessor
    {
        IQueryable<User> Get();
        User Get(int id);
        Task<User> Create(CreateUpdateUserModel model);
        Task<User> Update(int id, CreateUpdateUserModel model);
        Task Delete(int id);
    }
}
