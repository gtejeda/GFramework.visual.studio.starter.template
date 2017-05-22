using System;
using System.Collections.Generic;
using System.Web.Mvc;
using GFramework.core.commanding;
using GFramework.core.querying;
using GFramework.data.dapper.commands;
using Microsoft.Practices.Unity;
using $ext_projectname$.application.CustomCommands;
using $ext_projectname$.application.DTOs;

namespace $safeprojectname$.Controllers
{
    public class CustomersController : Controller
    {

        public ActionResult Index()
        {
            IList<CustomerDTO> classes = null;

            try
            {
                classes = CustomerQueryDb.GetAll();
            }
            catch (Exception ex) 
            {
                if (ex.Message.Contains("Demo.Customers"))
                {
                    throw new ApplicationException(ex.Message +
                        " - Make sure you run the demo scripts in the data project");
                }
            }

            return View(classes);
        }




        public ActionResult Create()
        {
            return View();
        }




        [HttpPost]
        public ActionResult Create(CustomerDTO RecordToInsert)
        {
            var cmd = new CreateEntityCommand<CustomerDTO>(RecordToInsert, User.Identity.Name);
            CommandProcessor.ExecuteCommand(cmd, Container);

            return RedirectToAction("Index");
        }



        

        public ActionResult Edit(int Id)
        {
            var obj = CustomerQueryDb.GetSingle(Id);
            return View(obj);
        }




        [HttpPost]
        public ActionResult Edit(CustomerDTO RecordToInsert)
        {
            var cmd = new UpdateEntityCommand<CustomerDTO>(RecordToInsert, User.Identity.Name);
            CommandProcessor.ExecuteCommand(cmd, Container);

            return RedirectToAction("Index");
        }

        


        public ActionResult Delete(int Id)
        {
            var cmd = new DeleteEntityCommand<CustomerDTO>(new CustomerDTO{Id = Id}, User.Identity.Name);
            CommandProcessor.ExecuteCommand(cmd, Container);

            return RedirectToAction("Index");
        }





        public ActionResult Activate(int Id)
        {
            var cmd = new ActivateCustomerCommand(Id, User.Identity.Name);
            CommandProcessor.ExecuteCommand(cmd, Container);

            return RedirectToAction("Index");
        }









        [Dependency]
        public IQueryingService<CustomerDTO> CustomerQueryDb { get; set; }



        [Dependency]
        public ICommandProcessor CommandProcessor { get; set; }



        [Dependency]
        public IUnityContainer Container { get; set; }
    }
}