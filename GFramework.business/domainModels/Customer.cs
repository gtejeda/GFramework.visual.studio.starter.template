using GFramework.core.domainEntities;
using $ext_projectname$.core.modelDefinitions;

namespace $safeprojectname$.domainModels
{
    /// <summary>
    /// This is just a sample class to showing how the GFramework works
    /// </summary>
    public class Customer: ICustomer, IValidateableEntity
    {

        public object Id { get; private set; }

        public string Name { get; private set; }

        public bool IsActive { get; private set; }


        public void Validate()
        {
            
        }
        
        public bool IsValid { get; private set; }

        

    }
}
