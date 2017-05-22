using $ext_projectname$.core.modelDefinitions;

namespace $safeprojectname$.DTOs
{
    /// <summary>
    /// This is just a sample class to showing how the GFramework works
    /// </summary>
    public class CustomerDTO: ICustomer
    {
        public object Id { get; set;}

        public string Name { get; set; }
        
        public bool IsActive { get; set; }

    }
}
