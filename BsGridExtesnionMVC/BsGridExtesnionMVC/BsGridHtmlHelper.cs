namespace System.Web.Mvc.Html
{
    using BsGridExt;
    using BsGridExt.BsGridImpl;

    public static class WidgetHtmlHelper
    {
        public static WidgetCollection BsWidgets(this HtmlHelper htmlHelper)
        {
            return new WidgetCollection();
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