using GFramework.core.Commanding;

namespace $safeprojectname$.CustomCommands
{

    /// <summary>
    /// This is just a sample class to showing how the GFramework works
    /// Commands must be used to make changes to the database
    /// </summary>
    public class ActivateCustomerCommand: BaseCommand
    {

        public int CustomerId { get; set; }
        
        public ActivateCustomerCommand(int CustomerId, string ExecutedBy) : base(ExecutedBy)
        {
            this.CustomerId = CustomerId;
        }
        
    }
}
