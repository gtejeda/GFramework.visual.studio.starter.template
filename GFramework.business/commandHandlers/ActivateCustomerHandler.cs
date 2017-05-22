using GFramework.core.commanding;
using $ext_projectname$.application.CustomCommands;
using $ext_projectname$.core.customRepositories;

namespace $safeprojectname$.commandHandlers
{
    public class ActivateCustomerHandler: ICommandHandler<ActivateCustomerCommand>
    {


        private readonly ICustomerRepository customerRepository;
        

        public ActivateCustomerHandler(ICustomerRepository CustomerRepository)
        {
            customerRepository = CustomerRepository;
        }

        
        public bool Execute(ActivateCustomerCommand Command, ICommandProcessor CommandProcessor)
        {
            customerRepository.Activate(Command.CustomerId);
            return true;
        }
        


    }
}
