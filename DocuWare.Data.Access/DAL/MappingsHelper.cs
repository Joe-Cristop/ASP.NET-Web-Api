using DocuWare.Data.Access.Maps.Common;
using DocuWare.Data.Access.Maps.Main;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace DocuWare.Data.Access.DAL
{
    public static class MappingsHelper
    {
        public static IEnumerable<IMap> GetMainMappings()
        {
            IEnumerable<TypeInfo> assemblyTypes = typeof(UserMap).GetTypeInfo().Assembly.DefinedTypes;
            IEnumerable<TypeInfo> mappings = assemblyTypes
                .Where(t => t.Namespace != null && t.Namespace.Contains(typeof(UserMap).Namespace))
                .Where(t => typeof(IMap).GetTypeInfo().IsAssignableFrom(t));

            mappings = mappings.Where(x => !x.IsAbstract);
            return mappings.Select(m => (IMap)Activator.CreateInstance(m.AsType())).ToArray();
        }
    }
}
