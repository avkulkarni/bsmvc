namespace System.Web.Mvc.Html
{
    using BsMvc;

    public static class BsHtmlHelper
    {
        public static WidgetCollection BsMvc(this HtmlHelper htmlHelper)
        {
            return new WidgetCollection(htmlHelper);
        }
    }
}


/*

@(Html.BsGrid("_fromServer")
    .AddColumn(new Column("EmpName"))
    .AddColumn(new Column("EmployeeId"))
    .AddServerDataUrl(Url.Action("GetCreatedSystemUsers", "SystemUser", "EmployeeManagement"))
    .Render())

*/