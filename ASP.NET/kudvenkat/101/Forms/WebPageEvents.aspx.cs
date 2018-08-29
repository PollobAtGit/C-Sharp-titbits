using System;

namespace _101.Forms
{
    public partial class WebPageEvents : System.Web.UI.Page
    {
        // Response.Write writes to the response stream. It doesn't write then returns from the event.
        // Writing to stream can be thought of as writing something to a current of bytes (stream)
        // That's why rendered page shows all texts wrote from the events here

        protected void Page_PreInit(object sender, EventArgs e) => Response.WriteHtmlLine("from page_preinit web page");

        protected void Page_Init(object sender, EventArgs e) => Response.WriteHtmlLine("from page_init web page");

        protected void Page_InitComplete(object sender, EventArgs e) => Response.WriteHtmlLine("from page_initcomplete");

        protected void Page_PreLoad(object sender, EventArgs e) => Response.WriteHtmlLine("from page_preload");

        protected void Page_Load(object sender, EventArgs e) => Response.WriteHtmlLine("from page_load");

        // control events will be invoked after page load

        protected void PostBack_Click(object sender, EventArgs e) => Response.WriteHtmlLine("from postback_click event");

        protected void TextWillChange_TextChanged(object sender, EventArgs e) => Response.WriteHtmlLine("from text will change (cached) event");

        protected void TextWillChangeWithAutoPostBack_TextChanged(object sender, EventArgs e) => Response.WriteHtmlLine("from text changed event but triggered through auto post back");

        // control event execution completed

        protected void Page_LoadComplete(object sender, EventArgs e) => Response.WriteHtmlLine("from page_loadcomplete");

        protected void Page_PreRender(object sender, EventArgs e) => Response.WriteHtmlLine("from page_prerender");

        protected void Page_PreRenderComplete(object sender, EventArgs e) => Response.WriteHtmlLine("from page_prerendercomplete");

        protected void Page_Unload(object sender, EventArgs e)
        {
            //Response is not available in this context.because the web page has already been destroyed
            //Response.Write("from page_unload");
        }
    }
}