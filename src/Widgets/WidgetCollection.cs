namespace BsMvc
{
    using BsMvc.Widgets.Grid;
    using System.Web.Mvc;

    public class WidgetCollection
    {
        private HtmlHelper _htmlHelper;

        public WidgetCollection(HtmlHelper htmlHelper)
        {
            this._htmlHelper = htmlHelper;
        }

        public Grid Grid(string gridId)
        {
            return new Grid(gridId, this._htmlHelper);
        }
    }
}
