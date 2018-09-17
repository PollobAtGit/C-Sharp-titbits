using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Trips.UI.Operation;

namespace Trips.UI.Pages.IOC
{
    public class IndexModel : PageModel
    {
        [BindProperty]
        public IOperation TransientOperation { get; }

        [BindProperty]
        public IScopedOperation ScopedOperation { get; }

        [BindProperty]
        public ISingletonOperation SingletonOperation { get; }

        #region Dummy service

        [BindProperty]
        public IOperation DummyTransientOperation { get; }

        [BindProperty]
        public IScopedOperation DummyScopedOperation { get; }

        [BindProperty]
        public ISingletonOperation DummySingletonOperation { get; }

        #endregion

        [BindProperty]
        public Operation.Operation Operation { get; }

        [BindProperty]
        public Operation.Operation ViaServiceOperation { get; }

        public IndexModel(
            OperationService service,
            //DummyOperationService dummyOperationService,
            Operation.Operation operation)
        {
            //TransientOperation = service.TransientOperation;
            //ScopedOperation = service.ScopedOperation;
            //SingletonOperation = service.SingletonOperation;

            //DummyScopedOperation = dummyOperationService.ScopedOperation;
            //DummySingletonOperation = dummyOperationService.SingletonOperation;
            //DummyTransientOperation = dummyOperationService.TransientOperation;

            Operation = operation;
            ViaServiceOperation = service.Operation;
        }

        public void OnGet()
        {

        }
    }
}