using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Trips.UI.Filter
{
    // Global page filter
    public class LogPageFilter : IAsyncPageFilter
    {
        public async Task OnPageHandlerExecutionAsync(PageHandlerExecutingContext context, PageHandlerExecutionDelegate next)
            => await next.Invoke();

        public async Task OnPageHandlerSelectionAsync(PageHandlerSelectedContext context)
            => await File.WriteAllLinesAsync(@"dump.txt",
                new string[] { context.HttpContext.Request.Path.Value });
    }
}
