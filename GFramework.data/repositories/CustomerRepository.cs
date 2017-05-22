using System.Configuration;
using System.Data.SqlClient;
using DapperExtensions;
using $ext_projectname$.application.DTOs;
using $ext_projectname$.core.customRepositories;
using $safeprojectname$.mappers;

namespace $safeprojectname$.repositories
{
    public class CustomerRepository: ICustomerRepository
    {
        SqlConnection conn;

        public CustomerRepository()
        {
            DapperExtensions.DapperExtensions.SetMappingAssemblies(new[] { typeof(CustomerMapper).Assembly });
            conn = new SqlConnection(ConfigurationManager.ConnectionStrings["CommandsDb"].ConnectionString);
        }

        public void Activate(int Id)
        {
            var obj = conn.Get<CustomerDTO>(Id);
            obj.IsActive = true;
            conn.Update(obj);
        }

    }
}
