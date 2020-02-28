using DocuWare.Data.Model;
using System;

namespace DocuWare.Security
{
    public interface ISecurityContext
    {
        User User { get; }

        bool IsAdmin { get; }
        bool IsSuperAdmin { get; }
    }
}
