using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using DapperExtensions;
using GFramework.core.domainEntities;
using GFramework.core.querying;
using $safeprojectname$.mappers;

namespace $safeprojectname$.querying
{
    public class GenericQueryingService<T> : IQueryingService<T> where T : class, IEntity
    {
        SqlConnection conn;

        public GenericQueryingService()
        {
            DapperExtensions.DapperExtensions.SetMappingAssemblies(new[] { typeof(CustomerMapper).Assembly });
            conn = new SqlConnection(ConfigurationManager.ConnectionStrings["QueryDb"].ConnectionString);
        }


        public IList<T> GetAll()
        {
            var list = conn.GetList<T>();
            return (IList<T>)list;
        }

        public T GetSingle(object Id)
        {
            var entity = conn.Get<T>(Id);
            return entity;
        }
    }

}
