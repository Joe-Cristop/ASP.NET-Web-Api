using DocuWare.Api.Common.Exceptions;
using DocuWare.Api.Models.User;
using DocuWare.Data.Access.DAL;
using DocuWare.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocuWare.Queries.Queries
{
    public class UserQueryProcessor : IUserQueryProcessor
    {
        private readonly IUnitOfWork _uow;

        public UserQueryProcessor(IUnitOfWork uow)
        {
            _uow = uow;
        }

        private IQueryable<User> GetQuery()
        {
            return _uow.Query<User>().Where(x => !x.IsDeleted);
        }

        public async Task<User> Create(CreateUpdateUserModel model)
        {
            if (GetQuery().Any(u => u.Identification == model.Identification.Trim()))
            {
                throw new BadRequestException("The identification is alreay in use.");
            }

            User user = new User
            {
                UserName = model.UserName.Trim(),
                Identification = model.Identification.Trim(),
                DepartmentId = model.DepartmentId,
            };

            _uow.Add(user);
            await _uow.CommitAsync();

            return user;
        }

        public async Task Delete(int id)
        {
            User user = GetQuery().FirstOrDefault(u => u.Id == id);

            if (null == user)
            {
                throw new NotFoundException("User is not found");
            }

            if (user.IsDeleted) return;
            user.IsDeleted = true;
            await _uow.CommitAsync();
        }

        public IQueryable<User> Get()
        {
            return GetQuery();
        }

        public User Get(int id)
        {
            User user = GetQuery().FirstOrDefault(x => x.Id == id);
            if (null == user)
            {
                throw new NotFoundException("User is not found");
            }

            return user;
        }

        public async Task<User> Update(int id, CreateUpdateUserModel model)
        {
            User user = GetQuery().FirstOrDefault(x => x.Id == id);

            if (null == user)
            {
                throw new NotFoundException("User is not found");
            }

            user.UserName = model.UserName.Trim();
            user.DepartmentId = model.DepartmentId;
            user.Identification = model.Identification;

            await _uow.CommitAsync();
            return user;
        }
    }
}
