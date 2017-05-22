using GFramework.core.domainEntities;

namespace $safeprojectname$.modelDefinitions
{
    /// <summary>
    /// This is just a sample class to showing how the GFramework works
    /// </summary>
    public interface ICustomer: IEntity
    {
        string Name { get; }

        bool IsActive { get; }
    }
}
