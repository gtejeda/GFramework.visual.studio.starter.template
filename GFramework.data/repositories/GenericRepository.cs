using System.Configuration;
using System.Data.SqlClient;
using DapperExtensions;
using GFramework.core.domainEntities;
using GFramework.data.dapper.persistence;
using $safeprojectname$.mappers;

namespace $safeprojectname$.repositories
{
    public class GenericRepository<T> : IDapperRepository<T> where T : class, IEntity
    {
        SqlConnection conn;

        public GenericRepository()
        {
            DapperExtensions.DapperExtensions.SetMappingAssemblies(new [] {typeof(CustomerMapper).Assembly});
            conn = new SqlConnection(ConfigurationManager.ConnectionStrings["CommandsDb"].ConnectionString);
        }


        public void Create(T Entity)
        {

            conn.Insert(Entity);
        }


        public void Update(T Entity)
        {
            conn.Update(Entity);
        }

        

        public void Delete(T Entity)
        {
            conn.Delete(Entity);
        }


    }
}
