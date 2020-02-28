using System;

namespace DocuWare.Data.Access.DAL
{
    public interface ITransaction : IDisposable
    {
        void Commit();
        void Rollback();
    }
}
