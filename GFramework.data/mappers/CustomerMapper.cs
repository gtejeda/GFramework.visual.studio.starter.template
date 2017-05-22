using DapperExtensions.Mapper;
using $ext_projectname$.application.DTOs;

namespace $safeprojectname$.mappers
{
    public class CustomerMapper : ClassMapper<CustomerDTO>
    {
        public CustomerMapper()
        {

            //use different table name
            Table("Customers");

            //use a custom schema
            Schema("Demo");

            //have a custom primary key
            Map(x => x.Id).Key(KeyType.Identity);

            //Use a different name property from database column
            //Map(x => x.Foo).Column("Bar");

            //Ignore this property entirely
            //Map(x => x.SecretDataMan).Ignore();

            //optional, map all other columns
            AutoMap();
        }
    }
}
