namespace System.Web.Mvc.Html
{
    using BsMvc.Widgets.Grid.GridExt;
    using Newtonsoft.Json;
    using System;

    public class Column
    {
        [JsonProperty("title", DefaultValueHandling = DefaultValueHandling.Ignore)]        
        private string _title;

        [JsonProperty("field", DefaultValueHandling = DefaultValueHandling.Ignore)]        
        private string _field;

        [JsonProperty("editable", DefaultValueHandling = DefaultValueHandling.Ignore)]
        private Editable _editable;

        [JsonProperty("sortable", DefaultValueHandling = DefaultValueHandling.Ignore)]
        private Boolean _isSortable = false;

        [JsonProperty("align", DefaultValueHandling = DefaultValueHandling.Ignore)]
        private string _align = "center";

        [JsonProperty("class", DefaultValueHandling=DefaultValueHandling.Ignore)]        
        private string _columnClasses;

        [JsonProperty("clickToSelect", DefaultValueHandling = DefaultValueHandling.Ignore)]        
        private Boolean _clickToSelect;

        [JsonProperty("rowspan", DefaultValueHandling = DefaultValueHandling.Ignore)]        
        private int _rowSpan;

        [JsonProperty("colspan", DefaultValueHandling = DefaultValueHandling.Ignore)]        
        private int _colSpan;

        [JsonProperty("checkbox", DefaultValueHandling = DefaultValueHandling.Ignore)]        
        private bool _checkBox;

        [JsonProperty("radio", DefaultValueHandling = DefaultValueHandling.Ignore)]        
        private bool _isRadio;

        [JsonProperty("titleTooltip", DefaultValueHandling = DefaultValueHandling.Ignore)]        
        private string _titleTooltip;

        [JsonProperty("valign", DefaultValueHandling = DefaultValueHandling.Ignore)]        
        private string _valign;

        [JsonProperty("falign", DefaultValueHandling = DefaultValueHandling.Ignore)]        
        private string _falign;

        [JsonProperty("halign", DefaultValueHandling = DefaultValueHandling.Ignore)]        
        private string _halign;

        [JsonProperty("width", DefaultValueHandling = DefaultValueHandling.Ignore)]        
        private int _width;

        [JsonProperty("order", DefaultValueHandling = DefaultValueHandling.Ignore)]        
        private string _order;

        [JsonProperty("visible", DefaultValueHandling = DefaultValueHandling.Ignore)]        
        private bool _isVisible;

        [JsonProperty("cardVisible", DefaultValueHandling = DefaultValueHandling.Ignore)]        
        private bool _isCardVisible;

        [JsonProperty("switchable", DefaultValueHandling = DefaultValueHandling.Ignore)]        
        private bool _isSwitchable;

        [JsonProperty("formatter", DefaultValueHandling = DefaultValueHandling.Ignore)]        
        private string _formatter;

        [JsonProperty("footerFormatter", DefaultValueHandling = DefaultValueHandling.Ignore)]        
        private string _footerFormatter;

        [JsonProperty("sortName", DefaultValueHandling = DefaultValueHandling.Ignore)]        
        private string _sortName;

        [JsonProperty("sorter", DefaultValueHandling = DefaultValueHandling.Ignore)]        
        private string _sorter;

        [JsonProperty("cellStyle", DefaultValueHandling = DefaultValueHandling.Ignore)]        
        private string _cellStyle;

        [JsonProperty("searchable", DefaultValueHandling = DefaultValueHandling.Ignore)]        
        private bool _isSearchable;

        [JsonProperty("searchFormatter", DefaultValueHandling = DefaultValueHandling.Ignore)]        
        private bool _isSearchFormatter;

        public Column(string columnTitle)
        {
            this._title = columnTitle;
        }

        /// <summary>
        /// True to show a radio. The radio column has fixed width.
        /// </summary>
        /// <returns></returns>
        public Column Radio()
        {
            this._isRadio = true;
            return this;
        }

        /// <summary>
        /// True to show a checkbox. The checkbox column has fixed width.
        /// </summary>
        /// <returns></returns>
        public Column CheckBox()
        {
            this._checkBox = true;
            return this;
        }

        /// <summary>
        /// The column field name.
        /// </summary>
        /// <param name="field"></param>
        /// <returns></returns>
        public Column Field(string field)
        {
            this._field = field;
            return this;
        }

        /// <summary>
        /// The column title tooltip text. This option also support the title HTML attribute
        /// </summary>
        /// <param name="titleTooltip"></param>
        /// <returns></returns>
        public Column TitleTooltip(string titleTooltip)
        {
            this._titleTooltip = titleTooltip;
            return this;
        }

        /// <summary>
        /// The column class name.
        /// </summary>
        /// <param name="columnClasses"></param>
        /// <returns></returns>
        public Column Class(string columnClasses)
        {
            this._columnClasses = columnClasses;
            return this;
        }

        /// <summary>
        /// Indicate how many rows a cell should take up.
        /// </summary>
        /// <param name="rowSpan"></param>
        /// <returns></returns>
        public Column RowSpan(int rowSpan)
        {
            this._rowSpan = rowSpan;
            return this;
        }

        /// <summary>
        /// Indicate how many columns a cell should take up.
        /// </summary>
        /// <param name="colSpan"></param>
        /// <returns></returns>
        public Column ColSpan(int colSpan)
        {
            this._colSpan = colSpan;
            return this;
        }

        /// <summary>
        /// Indicate how to align the column data. 
        /// </summary>
        /// <param name="align">'left', 'right', 'center' can be used.</param>
        /// <returns></returns>
        public Column Align(string align)
        {
            this._align = align.ToString().ToLower();
            return this;
        }

        /// <summary>
        /// Indicate how to align the table header. 
        /// </summary>
        /// <param name="align">'left', 'right', 'center' can be used.</param>
        /// <returns></returns>
        public Column hAlign(string align)
        {
            this._halign = align.ToString().ToLower();
            return this;
        }

        /// <summary>
        /// Indicate how to align the table footer.
        /// </summary>
        /// <param name="align">'left', 'right', 'center' can be used.</param>
        /// <returns></returns>
        public Column fAlign(string align)
        {
            this._falign = align.ToString().ToLower();
            return this;
        }

        /// <summary>
        /// Indicate how to align the cell data.
        /// </summary>
        /// <param name="align">'top', 'middle', 'bottom' can be used.</param>
        /// <returns></returns>
        public Column vAlign(string align)
        {
            this._valign = align.ToString().ToLower();
            return this;
        }

        /// <summary>
        /// The width of column. If not defined, the width will auto expand to fit its contents. 
        /// Though if the table is left responsive and sized too small this 'width' might be ignored (use min/max-width via class or such then).
        /// </summary>
        /// <param name="width"></param>
        /// <returns></returns>
        public Column Width(int width)
        {
            this._width = width;
            return this;
        }

        /// <summary>
        /// True to allow the column can be sorted.
        /// </summary>
        /// <returns></returns>
        public Column Sortable()
        {
            this._isSortable = true;
            return this;
        }

        /// <summary>
        /// The default sort order, can only be 'asc' or 'desc'.
        /// </summary>
        /// <param name="order">'asc' or 'desc'.</param>
        /// <returns></returns>
        public Column Order(string order)
        {
            this._order = order;
            return this;
        }

        /// <summary>
        /// False to hide the columns item.
        /// </summary>
        /// <param name="isVisible">true or false</param>
        /// <returns></returns>
        public Column Visible(Boolean isVisible)
        {
            this._isVisible = isVisible;
            return this;
        }

        /// <summary>
        /// False to hide the columns item in card view state.
        /// </summary>
        /// <param name="isCardVisible">true or false</param>
        /// <returns></returns>
        public Column CardVisible(Boolean isCardVisible)
        {
            this._isCardVisible = isCardVisible;
            return this;
        }

        /// <summary>
        /// False to disable the switchable of columns item.
        /// </summary>
        /// <param name="isSwitchable">true or false</param>
        /// <returns></returns>
        public Column Switchable(Boolean isSwitchable)
        {
            this._isSwitchable = isSwitchable;
            return this;
        }

        /// <summary>
        /// True to select checkbox or radiobox when the column is clicked.
        /// </summary>
        /// <param name="isClickToSelect">true or false</param>
        /// <returns></returns>
        public Column ClickToSelect(Boolean isClickToSelect)
        {
            this._clickToSelect = isClickToSelect;
            return this;
        }

        /// <summary>
        /// The context (this) is the column Object. 
        /// The cell formatter function, take three parameters: 
        /// value: the field value. 
        /// row: the row record data.
        /// index: the row index.
        /// </summary>
        /// <param name="formatterFunctionName"></param>
        /// <returns></returns>
        public Column Formatter(string formatterFunctionName)
        {
            this._formatter = formatterFunctionName;
            return this;
        }

        /// <summary>
        /// The context (this) is the column Object. 
        /// The function, take one parameter: 
        /// data: Array of all the data rows. 
        /// the function should return a string with the text to show in the footer cell.
        /// </summary>
        /// <param name="footerFormatter"></param>
        /// <returns></returns>
        public Column FooterFormatter(string footerFormatter)
        {
            this._footerFormatter = footerFormatter;
            return this;
        }

        /// <summary>
        /// The custom field sort function that used to do local sorting, take two parameters: 
        /// a: the first field value.
        /// b: the second field value.
        /// </summary>
        /// <param name="sorterFunctionName"></param>
        /// <returns></returns>
        public Column Sorter(string sorterFunctionName)
        {
            this._sorter = sorterFunctionName;
            return this;
        }

        /// <summary>
        /// Provide a customizable sort-name, not the default sort-name in the header, or the field name of the column. 
        /// For example, a column might display the value of fieldName of "html" such as "<b><span style="color:red">abc</span></b>", 
        /// but a fieldName to sort is "content" with the value of "abc".
        /// </summary>
        /// <param name="sortName"></param>
        /// <returns></returns>
        public Column SortName(string sortName)
        {
            this._sortName = sortName;
            return this;
        }

        /// <summary>
        /// The cell style formatter function, take three parameters: 
        /// value: the field value.
        /// row: the row record data.
        /// index: the row index.
        /// Support classes or css.
        /// </summary>
        /// <param name="cellStyle"></param>
        /// <returns></returns>
        public Column CellStyle(string cellStyle)
        {
            this._cellStyle = cellStyle;
            return this;
        }

        /// <summary>
        /// True to search data for this column.
        /// </summary>
        /// <param name="isSearchable">true or false</param>
        /// <returns></returns>
        public Column Searchable(Boolean isSearchable)
        {
            this._isSearchable = isSearchable;
            return this;
        }

        /// <summary>
        /// True to search use formated data.
        /// </summary>
        /// <param name="isSearchFormatter">true or false</param>
        /// <returns></returns>
        public Column SearchFormatter(Boolean isSearchFormatter)
        {
            this._isSearchFormatter = isSearchFormatter;
            return this;
        }
        
        /// <summary>
        /// Set the column editable options.
        /// </summary>
        /// <param name="type">Can support following : 
        /// <para >text | textarea | select | date | datetime | dateui | combodate | checklist | wysihtml5 | typeahead | typeaheadjs | select2 </para>
        /// <para> html5types can have following options : password | email | url | tel | number | range | time ] </para> 
        /// </param>
        /// <param name="title">Edit dialog title</param>
        /// <param name="container">Edit dialog container</param>
        /// <returns></returns>
        public Column Editable(string type, string title, string validate= null, string container = "body")
        {
            this._editable = new Editable(type, title, validate, container);
            return this;
        }
    }
}
