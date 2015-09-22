namespace System.Web.Mvc.Html
{
    using BsGridExt.BsGridImpl;

    public static class BsGridHtmlHelper
    {
        public static BsHtmlGrid BsGrid(this HtmlHelper htmlHelper, string gridId)
        {
            return new BsHtmlGrid(gridId);
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