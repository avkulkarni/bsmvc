namespace System.Web.Mvc.Html
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public enum ColType
    {
        RADIO,
        CHECKBOX
    }

    public enum AlignType
    {
        LEFT,
        RIGHT, 
        CENTER    
    }

    public class ColumnsGroup
    {
        private List<Column> _gridColumns;   
     
        //public ColumnsGroup(Column bsColumn)
        //{
        //    this._gridColumns = new List<Column>();
        //    this._gridColumns.Add(bsColumn);
        //}

        public ColumnsGroup AddColumn(Column column)
        {
            this._gridColumns.Add(column);
            return this;
        }

        public ColumnsGroup AddColumn(Action<Column> actionPredicate)
        {
            Column columToAdd = new Column();
            actionPredicate(columToAdd);
            this._gridColumns.Add(columToAdd);
            return this;
        }

        public ColumnsGroup AddColumn(IEnumerable<Column> column)
        {
            this._gridColumns.AddRange(column);
            return this;
        }
    }

    public class Column
    {
        private string _title;
        private string _field;
        private ColType _columnType;
        private Boolean _isEditable = false;
        private Boolean _isSortable = false;
        private string _align = "center";
        private List<string> _columnClasses = new List<string>();
        private Boolean _clickToSelect = false;

        public Column() { }

        public Column(string columnTitle)
        {
            this._title = columnTitle;
        }

        /// <summary>
        /// Sets data-editable attribute
        /// </summary>
        /// <returns></returns>
        public Column Title(string columnTitle)
        {
            this._title = columnTitle;            
            return this;
        }

        /// <summary>
        /// Sets data-editable attribute
        /// </summary>
        /// <returns></returns>
        public Column Editable()
        {
            this._isEditable = true;
            return this;
        }

        /// <summary>
        /// Sets data-sortable attribute
        /// </summary>
        /// <param name="field"></param>
        /// <returns></returns>
        public Column Sortable()
        {
            this._isSortable = true;
            return this;
        }

        /// <summary>
        /// Sets data-field attribute
        /// </summary>
        /// <param name="field"></param>
        /// <returns></returns>
        public Column Field(string field)
        {
            this._field = field;
            return this;
        }

        /// <summary>
        /// Sets data-align attribute
        /// </summary>
        /// <param name="align"></param>
        /// <returns></returns>
        public Column Align(AlignType align)
        {
            this._align = align.ToString().ToLower();
            return this;
        }

        /// <summary>
        /// Sets class attribute
        /// </summary>
        /// <param name="columnClasses"></param>
        /// <returns></returns>
        public Column Classess(IEnumerable<String> columnClasses)
        {
            this._columnClasses.AddRange(columnClasses);
            return this;
        }

        /// <summary>
        /// Sets column type
        /// </summary>
        /// <param name="columnType"></param>
        /// <param name="clickToSelect"></param>
        /// <returns></returns>
        public Column Type(ColType columnType, Boolean clickToSelect)
        {
            this._columnType = columnType;
            this._clickToSelect = clickToSelect;
            return this;
        }

        public override string ToString()
        {
            StringBuilder columnString = new StringBuilder();
            columnString.Append("<th class=' ");

            // Append Classes 
            foreach (string className in this._columnClasses)
            {
                columnString.AppendFormat(" {0}", className);
            }
            columnString.Append(" '");

            // Append data-field
            if (!String.IsNullOrEmpty(this._field))
                columnString.AppendFormat(" data-field='{0}' ", this._field);
            else
                columnString.AppendFormat(" data-field='{0}' ", this._title);

            // Append data-editable
            columnString.AppendFormat(" data-editable='{0}' ", this._isEditable.ToString().ToLower());

            // Append data-sortable
            columnString.AppendFormat(" data-sortable='{0}' ", this._isSortable.ToString().ToLower());

            // Append data-align
            columnString.AppendFormat(" data-align='{0}' ", this._align);
                        
            // Append column name
            columnString.AppendFormat(" >{0}</th>  ", this._title);
                        
            return columnString.ToString();
        }
    }
}
