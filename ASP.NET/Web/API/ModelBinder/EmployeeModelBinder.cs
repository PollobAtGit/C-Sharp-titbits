using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.ModelBinding;

namespace API.ModelBinder
{
    public class EmployeeModelBinder : IModelBinder
    {
        // POI: We can get HttpMethod from IModelBinder
        public bool BindModel(HttpActionContext actionContext, ModelBindingContext bindingContext)
        {
            throw new NotImplementedException();
        }
    }
}