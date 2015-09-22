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

    public class BsColumn
    {
        private string _title;
        private string _field;
        private ColType _columnType;
        private Boolean _isEditable = false;
        private Boolean _isSortable = false;
        private string _align = "center";
        private List<string> _columnClasses = new List<string>();
        private Boolean _clickToSelect = false;

        public BsColumn(string columnTitle)
        {
            this._title = columnTitle;
        }

        /// <summary>
        /// Sets data-editable attribute
        /// </summary>
        /// <returns></returns>
        public BsColumn Editable()
        {
            this._isEditable = true;
            return this;
        }

        /// <summary>
        /// Sets data-sortable attribute
        /// </summary>
        /// <param name="field"></param>
        /// <returns></returns>
        public BsColumn Sortable()
        {
            this._isSortable = true;
            return this;
        }

        /// <summary>
        /// Sets data-field attribute
        /// </summary>
        /// <param name="field"></param>
        /// <returns></returns>
        public BsColumn Field(string field)
        {
            this._field = field;
            return this;
        }

        /// <summary>
        /// Sets data-align attribute
        /// </summary>
        /// <param name="align"></param>
        /// <returns></returns>
        public BsColumn Align(AlignType align)
        {
            this._align = align.ToString().ToLower();
            return this;
        }

        /// <summary>
        /// Sets class attribute
        /// </summary>
        /// <param name="columnClasses"></param>
        /// <returns></returns>
        public BsColumn Classess(IEnumerable<String> columnClasses)
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
        public BsColumn Type(ColType columnType, Boolean clickToSelect)
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
