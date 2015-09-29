namespace BsMvc.Widgets.Grid
{
    using System.Collections.Generic;
    using System.Web.Mvc.Html;

    public class ColumnsGroup
    {
        internal List<Column> GridColumns { get { return this._gridColumns; } }
        private List<Column> _gridColumns;

        public ColumnsGroup(IEnumerable<Column> columns)
        {
            this._gridColumns = new List<Column>();
            this._gridColumns.AddRange(columns);
        }
    }

}
