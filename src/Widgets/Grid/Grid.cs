namespace BsMvc.Widgets.Grid
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Web;
    using System.Web.Mvc;
    using System.Web.Mvc.Html;
    using System.Linq;
    using Newtonsoft.Json;

    public enum EPagination
    {
        CLIENT,
        SERVER
    }

    public enum EHAlign
    {
        LEFT,
        RIGHT
    }

    public enum EVAlign
    {
        TOP,
        BOTTOM,
        BOTH
    }


    public class Grid : IHtmlString
    {
        #region PRIVATE
        private HtmlHelper _htmlHelper;
        private List<ColumnsGroup> _columnsGroups = new List<ColumnsGroup>();
        private string _gridId;

        [JsonProperty("columns", DefaultValueHandling = DefaultValueHandling.Ignore)]
        private Object _gridColumnsJson;

        [JsonProperty("url", DefaultValueHandling = DefaultValueHandling.Ignore)]        
        private string _url;

        [JsonProperty("classes", DefaultValueHandling = DefaultValueHandling.Ignore)]
        private String _tableClassesStr;
        private List<String> _tableClasses = new List<string>();

        [JsonProperty("striped", DefaultValueHandling = DefaultValueHandling.Ignore)]        
        private Boolean _isDataStriped;

        [JsonProperty("showRefresh", DefaultValueHandling = DefaultValueHandling.Ignore)]        
        private Boolean _isShowRefresh;

        [JsonProperty("showToggle", DefaultValueHandling = DefaultValueHandling.Ignore)]        
        private Boolean _isShowToggle;

        [JsonProperty("showColumns", DefaultValueHandling = DefaultValueHandling.Ignore)]        
        private Boolean _isShowColumns = true;

        [JsonProperty("pagination", DefaultValueHandling = DefaultValueHandling.Ignore)]        
        private Boolean _isPagination;

        [JsonProperty("height", DefaultValueHandling = DefaultValueHandling.Ignore)]
        private int _dataHeight;

        [JsonProperty("sidePagination", DefaultValueHandling = DefaultValueHandling.Ignore)]
        private string _sidePagination = "client";

        [JsonProperty("undefinedText", DefaultValueHandling = DefaultValueHandling.Ignore)]
        private string _undefinedText;

        [JsonProperty("sortName", DefaultValueHandling = DefaultValueHandling.Ignore)]
        private string _sortName;

        [JsonProperty("sortOrder", DefaultValueHandling = DefaultValueHandling.Ignore)]
        private string _sortOrder;

        [JsonProperty("iconsPrefix", DefaultValueHandling = DefaultValueHandling.Ignore)]
        private string _iconsPrefix;

        [JsonProperty("method", DefaultValueHandling = DefaultValueHandling.Ignore)]
        private string _methodType;

        [JsonProperty("cache", DefaultValueHandling = DefaultValueHandling.Ignore)]
        private bool _isCache;

        [JsonProperty("contentType", DefaultValueHandling = DefaultValueHandling.Ignore)]
        private string _contentType;

        [JsonProperty("ajaxOptions", DefaultValueHandling = DefaultValueHandling.Ignore)]
        private string _ajaxOptions;

        [JsonProperty("queryParams", DefaultValueHandling = DefaultValueHandling.Ignore)]        
        private string _queryParamsFunName;

        [JsonProperty("queryParamsType", DefaultValueHandling = DefaultValueHandling.Ignore)]                
        private string _queryParamsType;

        [JsonProperty("responseHandler", DefaultValueHandling = DefaultValueHandling.Ignore, TypeNameHandling=TypeNameHandling.None)]        
        private string _responseHandlerFunName;

        [JsonProperty("pageNumber", DefaultValueHandling = DefaultValueHandling.Ignore)]
        private int _pageNumber;

        [JsonProperty("pageList", DefaultValueHandling = DefaultValueHandling.Ignore)]
        private string _pageList;

        [JsonProperty("pageSize", DefaultValueHandling = DefaultValueHandling.Ignore)]
        private int _pageSize;

        [JsonProperty("selectItemName", DefaultValueHandling = DefaultValueHandling.Ignore)]
        private string _selectItemName;

        [JsonProperty("smartDisplay", DefaultValueHandling = DefaultValueHandling.Ignore)]
        private bool _isSmartDisplay;

        [JsonProperty("search", DefaultValueHandling = DefaultValueHandling.Ignore)]
        private bool _isSearch;

        [JsonProperty("strictSearch", DefaultValueHandling = DefaultValueHandling.Ignore)]
        private bool _isStrictSearch;

        [JsonProperty("searchText", DefaultValueHandling = DefaultValueHandling.Ignore)]
        private string _searchText;

        [JsonProperty("searchTimeOut", DefaultValueHandling = DefaultValueHandling.Ignore)]
        private int _searchTimeOut;

        [JsonProperty("trimOnSearch", DefaultValueHandling = DefaultValueHandling.Ignore)]
        private bool _isTrimOnSearch;

        [JsonProperty("showFooter", DefaultValueHandling = DefaultValueHandling.Ignore)]
        private bool _showFooter;

        [JsonProperty("showPaginationSwitch", DefaultValueHandling = DefaultValueHandling.Ignore)]
        private bool _isShowPaginationSwitch;

        [JsonProperty("minimumCountColumns", DefaultValueHandling = DefaultValueHandling.Ignore)]
        private bool _isMinimumCountColumns;

        [JsonProperty("idField", DefaultValueHandling = DefaultValueHandling.Ignore)]
        private string _idField;

        [JsonProperty("uniqueId", DefaultValueHandling = DefaultValueHandling.Ignore)]
        private string _uniqueId;

        [JsonProperty("cardView", DefaultValueHandling = DefaultValueHandling.Ignore)]
        private bool _isCardView;

        [JsonProperty("detailView", DefaultValueHandling = DefaultValueHandling.Ignore)]
        private bool _isDetailView;

        [JsonProperty("detailFormatter", DefaultValueHandling = DefaultValueHandling.Ignore)]
        private bool _detailFormatterFunName;

        [JsonProperty("searchAlign", DefaultValueHandling = DefaultValueHandling.Ignore)]
        private string _searchAlign;

        [JsonProperty("buttonsAlign", DefaultValueHandling = DefaultValueHandling.Ignore)]
        private string _buttonsAlign;

        [JsonProperty("toolbarAlign", DefaultValueHandling = DefaultValueHandling.Ignore)]
        private string _toolbarAlign;

        [JsonProperty("paginationVAlign", DefaultValueHandling = DefaultValueHandling.Ignore)]
        private string _paginationVAlign;

        [JsonProperty("paginationDetailHAlign", DefaultValueHandling = DefaultValueHandling.Ignore)]
        private string _paginationDetailHAlign;

        [JsonProperty("paginationHAlign", DefaultValueHandling = DefaultValueHandling.Ignore)]
        private string _paginationHAlign;

        [JsonProperty("paginationFirstText", DefaultValueHandling = DefaultValueHandling.Ignore)]
        private string _paginationFirstText;

        [JsonProperty("paginationPreText", DefaultValueHandling = DefaultValueHandling.Ignore)]
        private string _paginationPreText;

        [JsonProperty("paginationNextText", DefaultValueHandling = DefaultValueHandling.Ignore)]
        private string _paginationNextText;

        [JsonProperty("paginationLastText", DefaultValueHandling = DefaultValueHandling.Ignore)]
        private string _paginationLastText;

        [JsonProperty("clickToSelect", DefaultValueHandling = DefaultValueHandling.Ignore)]
        private bool _isClickToSelect;

        [JsonProperty("singleSelect", DefaultValueHandling = DefaultValueHandling.Ignore)]
        private bool _isSingleSelect;

        [JsonProperty("toolbar", DefaultValueHandling = DefaultValueHandling.Ignore)]
        private string _toolbar;

        [JsonProperty("checkboxHeader", DefaultValueHandling = DefaultValueHandling.Ignore)]
        private bool _isCheckboxHeader;

        [JsonProperty("maintainSelected", DefaultValueHandling = DefaultValueHandling.Ignore)]
        private bool _isMaintainSelected;

        [JsonProperty("sortable", DefaultValueHandling = DefaultValueHandling.Ignore)]
        private bool _isSortable;

        [JsonProperty("silentSort", DefaultValueHandling = DefaultValueHandling.Ignore)]
        private bool isSilentSort;

        [JsonProperty("rowStyle", DefaultValueHandling = DefaultValueHandling.Ignore)]
        private string _rowStyleFunName;

        [JsonProperty("rowAttributes", DefaultValueHandling = DefaultValueHandling.Ignore)]
        private string _rowAttributesFunName;

        [JsonProperty("locale", DefaultValueHandling = DefaultValueHandling.Ignore)]
        private string _locale;

        [JsonProperty("showHeader", DefaultValueHandling = DefaultValueHandling.Ignore)]
        private bool _isShowHeader;

        #endregion

        public Grid(string gridId, HtmlHelper htmlHelper)
        {
            this._gridId = gridId;
            this._htmlHelper = htmlHelper;
        }

        #region GRID_ATTRS

        /// <summary>
        /// The class name of table. By default, the table is bordered, you can add 'table-no-bordered' to remove table-bordered style.
        /// </summary>
        /// <param name="tableClasses"></param>
        /// <returns></returns>
        public Grid Classes(IEnumerable<String> tableClasses)
        {
            _tableClasses.AddRange(tableClasses);
            _tableClasses = _tableClasses.Distinct().ToList();
            return this;
        }

        /// <summary>
        /// The height of table.
        /// </summary>
        /// <param name="dataHeight"></param>
        /// <returns></returns>
        public Grid Height(int dataHeight)
        {
            this._dataHeight = dataHeight;
            return this;
        }

        /// <summary>
        /// Defines the default undefined text.
        /// </summary>
        /// <param name="undefinedText"></param>
        /// <returns></returns>
        public Grid UndefinedText(string undefinedText)
        {
            this._undefinedText = undefinedText;
            return this;
        }

        /// <summary>
        /// True to stripe the rows.
        /// </summary>
        /// <returns></returns>
        public Grid Striped()
        {
            this._isDataStriped = true;
            return this;
        }

        /// <summary>
        /// Defines which column can be sorted.
        /// </summary>
        /// <param name="sortName"></param>
        /// <returns></returns>
        public Grid SortName(string sortName)
        {
            this._sortName = sortName;
            return this;
        }

        /// <summary>
        /// Defines the column sort order, can only be 'asc' or 'desc'.
        /// </summary>
        /// <param name="sortOrder"></param>
        /// <returns></returns>
        public Grid SortOrder(string sortOrder)
        {
            this._sortOrder = sortOrder;
            return this;
        }

        /// <summary>
        /// Defines icon set name ('glyphicon' or 'fa' for FontAwesome). By default 'glyphicon' is used.
        /// </summary>
        /// <param name="iconsPrefix"></param>
        /// <returns></returns>
        public Grid IconsPrefix(string iconsPrefix)
        {
            this._iconsPrefix = iconsPrefix;
            return this;
        }

        /// <summary>
        /// The table columns list
        /// </summary>
        /// <param name="columns"></param>
        /// <returns></returns>
        public Grid Columns(List<Column> columns)
        {
            this._columnsGroups.Add(new ColumnsGroup(columns));
            return this;
        }

        /// <summary>
        /// The method type to request remote data.
        /// </summary>
        /// <param name="methodType"></param>
        /// <returns></returns>
        public Grid Method(string methodType)
        {
            this._methodType = methodType;
            return this;
        }

        /// <summary>
        /// <para>A URL to request data from remote site. </para> 
        /// <para>Note that the required server response format is different depending on whether the 'sidePagination' option is specified.</para> 
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public Grid Url(string url)
        {
            this._url = url;
            return this;
        }

        /// <summary>
        /// False to disable caching of AJAX requests.
        /// </summary>
        /// <param name="isCache"></param>
        /// <returns></returns>
        public Grid Cache(Boolean isCache)
        {
            this._isCache = isCache;
            return this;
        }

        /// <summary>
        /// The contentType of request remote data.
        /// </summary>
        /// <param name="contentType"></param>
        /// <returns></returns>
        public Grid ContentType(string contentType)
        {
            this._contentType = contentType;
            return this;
        }

        /// <summary>
        /// The type of data that you are expecting back from the server.
        /// </summary>
        /// <param name="dataType"></param>
        /// <returns></returns>
        public Grid DataType(string dataType)
        {
            this._contentType = dataType;
            return this;
        }

        /// <summary>
        /// Additional options for submit ajax request. 
        /// </summary>
        /// <param name="ajaxOptions">a JSON string for ajax options</param>
        /// <returns></returns>
        public Grid AjaxOptions(string ajaxOptions)
        {
            this._ajaxOptions = ajaxOptions;
            return this;
        }

        /// <summary>
        /// <para>When requesting remote data, you can send additional parameters by modifying queryParams. </para>
        /// <para>If queryParamsType = 'limit', the params object contains: </para>
        /// <para>limit, offset, search, sort, order Else, it contains: </para>
        /// <para>pageSize, pageNumber, searchText, sortName, sortOrder. </para>
        /// <para>Return false to stop request.</para>
        /// </summary>
        /// <param name="queryParamsFunName">Name of the function that you have written in javascript.</param>
        /// <returns></returns>
        public Grid QueryParams(string queryParamsFunName)
        {
            this._queryParamsFunName = queryParamsFunName;
            return this;
        }

        /// <summary>
        /// Set 'limit' to send query params width RESTFul type.
        /// </summary>
        /// <param name="queryParamsType"></param>
        /// <returns></returns>
        public Grid QueryParamsType(string queryParamsType)
        {
            this._queryParamsType = queryParamsType;
            return this;
        }

        /// <summary>
        /// <para>Before load remote data, handler the response data format, </para>
        /// <para>the parameters object contains: res: the response data.</para>
        /// </summary>
        /// <param name="responseHandlerFunName">response handler function name that you have written in javascript</param>
        /// <returns></returns>
        public Grid ResponseHandler(string responseHandlerFunName)
        {
            this._responseHandlerFunName = responseHandlerFunName;
            return this;
        }

        /// <summary>
        /// True to show a pagination toolbar on table bottom
        /// </summary>
        /// <returns></returns>
        public Grid Pagination()
        {
            this._isPagination = true;
            return this;
        }

        /// <summary>
        /// <para>Defines the side pagination of table, can only be 'client' or 'server'. </para>
        /// <para>Using 'server' side requires either setting the 'url' or 'ajax' option. </para>
        /// <para>Note that the required server response format is different depending on </para>
        /// <para>whether the 'client' or 'server' option is specified.</para>
        /// </summary>
        /// <param name="spOption"></param>
        /// <returns></returns>
        public Grid SidePagination(EPagination spOption)
        {
            this._sidePagination = spOption.ToString().ToLower();
            return this;
        }

        /// <summary>
        /// When set pagination property, initialize the page number.
        /// </summary>
        /// <param name="pageNumber"></param>
        /// <returns></returns>
        public Grid PageNumber(int pageNumber)
        {
            this._pageNumber = pageNumber;
            return this;
        }

        /// <summary>
        /// When set pagination property, initialize the page size.
        /// </summary>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public Grid PageSize(int pageSize)
        {
            this._pageSize = pageSize;
            return this;
        }

        /// <summary>
        /// <para>When set pagination property, initialize the page size selecting list. </para>
        /// <para>If you include the 'All' option, all the records will be shown in your table</para>
        /// </summary>
        /// <param name="pageList"></param>
        /// <returns></returns>
        public Grid PageList(string pageList)
        {
            this._pageList = pageList;
            return this;
        }

        /// <summary>
        /// The name of radio or checkbox input.
        /// </summary>
        /// <param name="selectItemName"></param>
        /// <returns></returns>
        public Grid SelectItemName(string selectItemName)
        {
            this._selectItemName = selectItemName;
            return this;
        }

        /// <summary>
        /// True to display pagination or card view smartly.
        /// </summary>
        /// <param name="smartDisplay"></param>
        /// <returns></returns>
        public Grid SmartDisplay(Boolean smartDisplay)
        {
            this._isSmartDisplay = smartDisplay;
            return this;
        }

        /// <summary>
        /// Enable the search input.
        /// </summary>
        /// <param name="search"></param>
        /// <returns></returns>
        public Grid Search(Boolean search)
        {
            this._isSearch = search;
            return this;
        }

        /// <summary>
        /// Enable the strict search.
        /// </summary>
        /// <param name="strictSearch"></param>
        /// <returns></returns>
        public Grid StrictSearch(Boolean strictSearch)
        {
            this._isStrictSearch = strictSearch;
            return this;
        }

        /// <summary>
        /// When set search property, initialize the search text.
        /// </summary>
        /// <param name="searchText"></param>
        /// <returns></returns>
        public Grid SearchText(string searchText)
        {
            this._searchText = searchText;
            return this;
        }

        /// <summary>
        /// Set timeout for search fire.
        /// </summary>
        /// <param name="searchTimeOut"></param>
        /// <returns></returns>
        public Grid SearchTimeOut(int searchTimeOut)
        {
            this._searchTimeOut = searchTimeOut;
            return this;
        }

        /// <summary>
        /// True to trim spaces in search field.
        /// </summary>
        /// <param name="trimOnSearch"></param>
        /// <returns></returns>
        public Grid TrimOnSearch(Boolean trimOnSearch)
        {
            this._isTrimOnSearch = trimOnSearch;
            return this;
        }

        /// <summary>
        /// False to hide the table header.
        /// </summary>
        /// <param name="showHeader"></param>
        /// <returns></returns>
        public Grid ShowHeader(Boolean showHeader)
        {
            this._isShowHeader = showHeader;
            return this;
        }

        /// <summary>
        /// If true shows summary footer row
        /// </summary>
        /// <param name="showFooter"></param>
        /// <returns></returns>
        public Grid ShowFooter(Boolean showFooter)
        {
            this._showFooter = showFooter;
            return this;
        }

        /// <summary>
        /// True to show the columns drop down list.
        /// </summary>
        /// <param name="isShowColumns"></param>
        /// <returns></returns>
        public Grid ShowColumns(Boolean isShowColumns)
        {
            this._isShowColumns = isShowColumns;
            return this;
        }

        /// <summary>
        /// True to show the refresh button.
        /// </summary>
        /// <param name="isShowRefresh"></param>
        /// <returns></returns>
        public Grid ShowRefresh(Boolean isShowRefresh)
        {
            this._isShowRefresh = isShowRefresh;
            return this;
        }

        /// <summary>
        /// True to show the toggle button to toggle table / card view.
        /// </summary>
        /// <param name="isShowToggle"></param>
        /// <returns></returns>
        public Grid ShowToggle(Boolean isShowToggle)
        {
            this._isShowToggle = isShowToggle;
            return this;
        }

        /// <summary>
        /// True to show the pagination switch button.
        /// </summary>
        /// <param name="showPaginationSwitch"></param>
        /// <returns></returns>
        public Grid ShowPaginationSwitch(Boolean showPaginationSwitch)
        {
            this._isShowPaginationSwitch = showPaginationSwitch;
            return this;
        }

        /// <summary>
        /// The minimum number of columns to hide from the columns drop down list.
        /// </summary>
        /// <param name="minimumCountColumns"></param>
        /// <returns></returns>
        public Grid MinimumCountColumns(Boolean minimumCountColumns)
        {
            this._isMinimumCountColumns = minimumCountColumns;
            return this;
        }

        /// <summary>
        /// Indicate which field is an identity field.
        /// </summary>
        /// <param name="idField"></param>
        /// <returns></returns>
        public Grid IdField(string idField)
        {
            this._idField = idField;
            return this;
        }

        /// <summary>
        /// Indicate an unique identifier for each row.
        /// </summary>
        /// <param name="uniqueId"></param>
        /// <returns></returns>
        public Grid UniqueId(string uniqueId)
        {
            this._uniqueId = uniqueId;
            return this;
        }

        /// <summary>
        /// True to show card view table, for example mobile view.
        /// </summary>
        /// <param name="isCardView"></param>
        /// <returns></returns>
        public Grid CardView(Boolean isCardView)
        {
            this._isCardView = isCardView;
            return this;
        }

        /// <summary>
        /// True to show detail view table.
        /// </summary>
        /// <param name="isDetailView"></param>
        /// <returns></returns>
        public Grid DetailView(Boolean isDetailView)
        {
            this._isDetailView = isDetailView;
            return this;
        }

        /// <summary>
        /// Format your detail view when detailView is set to true.
        /// </summary>
        /// <param name="detailFormatterFunName"></param>
        /// <returns></returns>
        public Grid DetailFormatter(Boolean detailFormatterFunName)
        {
            this._detailFormatterFunName = detailFormatterFunName;
            return this;
        }

        /// <summary>
        /// Indicate how to align the search input. 'left', 'right' can be used.
        /// </summary>
        /// <param name="searchAlign"></param>
        /// <returns></returns>
        public Grid SearchAlign(EHAlign searchAlign)
        {
            this._searchAlign = searchAlign.ToString().ToLower();
            return this;
        }

        /// <summary>
        /// Indicate how to align the toolbar buttons. 'left', 'right' can be used.
        /// </summary>
        /// <param name="buttonsAlign"></param>
        /// <returns></returns>
        public Grid ButtonsAlign(EHAlign buttonsAlign)
        {
            this._buttonsAlign = buttonsAlign.ToString().ToLower();
            return this;
        }

        /// <summary>
        /// Indicate how to align the custom toolbar. 'left', 'right' can be used.
        /// </summary>
        /// <param name="toolbarAlign"></param>
        /// <returns></returns>
        public Grid ToolbarAlign(EHAlign toolbarAlign)
        {
            this._toolbarAlign = toolbarAlign.ToString().ToLower();
            return this;
        }

        /// <summary>
        /// Indicate how to align the pagination. 'top', 'bottom', 'both' (put the pagination on top and bottom) can be used.
        /// </summary>
        /// <param name="paginationVAlign"></param>
        /// <returns></returns>
        public Grid PaginationVAlign(EVAlign paginationVAlign)
        {
            this._paginationVAlign = paginationVAlign.ToString().ToLower();
            return this;
        }

        /// <summary>
        /// Indicate how to align the pagination. 'left', 'right' can be used.
        /// </summary>
        /// <param name="paginationHAlign"></param>
        /// <returns></returns>
        public Grid PaginationHAlign(EHAlign paginationHAlign)
        {
            this._paginationHAlign = paginationHAlign.ToString().ToLower();
            return this;
        }

        /// <summary>
        /// Indicate how to align the pagination detail. 'left', 'right' can be used.
        /// </summary>
        /// <param name="paginationDetailHAlign"></param>
        /// <returns></returns>
        public Grid PaginationDetailHAlign(EHAlign paginationDetailHAlign)
        {
            this._paginationDetailHAlign = paginationDetailHAlign.ToString().ToLower();
            return this;
        }

        /// <summary>
        /// Indicate the icon or text to be shown in the pagination detail, the first button of the pagination detail.
        /// </summary>
        /// <param name="paginationFirstText"></param>
        /// <returns></returns>
        public Grid PaginationFirstText(string paginationFirstText)
        {
            this._paginationFirstText = paginationFirstText;
            return this;
        }

        /// <summary>
        /// Indicate the icon or text to be shown in the pagination detail, the previous button.
        /// </summary>
        /// <param name="paginationPreText"></param>
        /// <returns></returns>
        public Grid PaginationPreText(string paginationPreText)
        {
            this._paginationPreText = paginationPreText;
            return this;
        }

        /// <summary>
        /// Indicate the icon or text to be shown in the pagination detail, the next button.
        /// </summary>
        /// <param name="paginationNextText"></param>
        /// <returns></returns>
        public Grid PaginationNextText(string paginationNextText)
        {
            this._paginationNextText = paginationNextText;
            return this;
        }

        /// <summary>
        /// Indicate the icon or text to be shown in the pagination detail, the last button.
        /// </summary>
        /// <param name="paginationLastText"></param>
        /// <returns></returns>
        public Grid PaginationLastText(string paginationLastText)
        {
            this._paginationLastText = paginationLastText;
            return this;
        }

        /// <summary>
        /// True to select checkbox or radiobox when clicking rows.
        /// </summary>
        /// <param name="clickToSelect"></param>
        /// <returns></returns>
        public Grid ClickToSelect(Boolean clickToSelect)
        {
            this._isClickToSelect = clickToSelect;
            return this;
        }

        /// <summary>
        /// True to allow checkbox selecting only one row.
        /// </summary>
        /// <param name="singleSelect"></param>
        /// <returns></returns>
        public Grid SingleSelect(Boolean singleSelect)
        {
            this._isSingleSelect = singleSelect;
            return this;
        }

        /// <summary>
        /// A jQuery selector that indicates the toolbar
        /// </summary>
        /// <param name="toolbar"></param>
        /// <returns></returns>
        public Grid Toolbar(string toolbar)
        {
            this._toolbar = toolbar;
            return this;
        }

        /// <summary>
        /// False to hide check-all checkbox in header row.
        /// </summary>
        /// <param name="checkboxHeader"></param>
        /// <returns></returns>
        public Grid CheckboxHeader(Boolean checkboxHeader)
        {
            this._isCheckboxHeader = checkboxHeader;
            return this;
        }

        /// <summary>
        /// True to maintain selected rows on change page and search.
        /// </summary>
        /// <param name="maintainSelected"></param>
        /// <returns></returns>
        public Grid MaintainSelected(Boolean maintainSelected)
        {
            this._isMaintainSelected = maintainSelected;
            return this;
        }

        /// <summary>
        /// False to disable sortable of all columns.
        /// </summary>
        /// <param name="sortable"></param>
        /// <returns></returns>
        public Grid Sortable(Boolean sortable)
        {
            this._isSortable = sortable;
            return this;
        }

        /// <summary>
        /// Set false to sort the data silently. This options works when the sidePagination option is set to server.
        /// </summary>
        /// <param name="silentSort"></param>
        /// <returns></returns>
        public Grid SilentSort(Boolean silentSort)
        {
            this.isSilentSort = silentSort;
            return this;
        }

        /// <summary>
        /// <para>The row style formatter function, takes two parameters: </para>
        /// <para>row: the row record data.</para>
        /// <para>index: the row index.</para>
        /// <para>Support classes or css.</para>
        /// </summary>
        /// <param name="rowStyleFunName">function name that you have written in javascript</param>
        /// <returns></returns>
        public Grid RowStyle(string rowStyleFunName)
        {
            this._rowStyleFunName = rowStyleFunName;
            return this;
        }

        /// <summary>
        /// <para>The row attribute formatter function, takes two parameters: </para>
        /// <para>row: the row record data.</para>
        /// <para>index: the row index.</para>
        /// <para>Support all custom attributes.</para>
        /// </summary>
        /// <param name="rowAttributesFunName">function name that you have written in javascript</param>
        /// <returns></returns>
        public Grid rowAttributes(string rowAttributesFunName)
        {
            this._rowAttributesFunName = rowAttributesFunName;
            return this;
        }

        /// <summary>
        /// <para>Sets the locale to use (i.e. 'fr-CA'). Locale files must be pre-loaded. Allows for fallback locales, if loaded, in the following order:</para>
        /// <para>First tries for the locale as specified,</para>
        /// <para>Then tries the locale with '_' translated to '-' and the region code upper cased,</para>
        /// <para>Then tries the the short locale code (i.e. 'fr' instead of 'fr-CA'),</para>
        /// <para>And finally will use the last locale file loaded (or the default locale if no locales loaded).</para>
        /// <para>If left undfined or an empty string, uses the last locale loaded (or 'en-US' if no locale files loaded).</para>
        /// </summary>
        /// <param name="locale"></param>
        /// <returns></returns>
        public Grid Locale(string locale)
        {
            this._locale = locale;
            return this;
        }

        #endregion

        public override string ToString()
        {
            string html = this.RenderHtml();
            string javascript = this.RenderJavascript();

            this._htmlHelper.ViewContext.Writer.Write(html);
            this._htmlHelper.ViewContext.Writer.WriteAsync(javascript);
            return String.Empty;
        }

        private string RenderJavascript()
        {
            List<List<Column>> clnsList = new List<List<Column>>();
            this._columnsGroups.ForEach(col => clnsList.Add(col.GridColumns));

            if (clnsList.Count == 1)
            {
                this._gridColumnsJson = clnsList.FirstOrDefault();
            }
            else
            {
                this._gridColumnsJson = clnsList;
            }
            
            // Remember that when using StringBuiler, you need to replace { in the string with {{
            // columnsJson = columnsJson.Replace("{", "{{").Replace("}", "}}");
            StringBuilder javascript = new StringBuilder();
            javascript.AppendFormat(@"
                    <script>
                        $(document).ready(function() {{
                            $('#{0}').bootstrapTable({1});
                        }});
                    </script>", this._gridId, JsonConvert.SerializeObject(this));

            return javascript.ToString();
        }

        private string RenderHtml()
        {
            // Create Table classes
            StringBuilder tableClassesStr = new StringBuilder();
            _tableClasses.ForEach(cl => tableClassesStr.AppendFormat(" {0} ", cl.ToString()));
            this._tableClassesStr = tableClassesStr.ToString();

            StringBuilder htmlTable = new StringBuilder();
            htmlTable = htmlTable.AppendFormat(@"<table id='{0}'></table>", this._gridId);
            return htmlTable.ToString();
        }

        public MvcHtmlString Render()
        {
            return new MvcHtmlString(this.ToString());
        }

        public string ToHtmlString()
        {
            return this.Render().ToString();
        }
    }
}


//<!-- Bootstrap Table (& Editable) Styles -->
//<link rel="stylesheet" href="~/BsMvc/Grid/bootstrap-table/bootstrap-table.min.css">
//<link rel="stylesheet" href="~/BsMvc/Grid/bootstrap-xeditable/css/bootstrap-editable.css">

//<!-- Bootstrap Table (& Editable) Scripts -->
//<!-- <script src="~/Scripts/bootstrap.js"></script> -->
//<script src="~/BsMvc/Grid/bootstrap-table/bootstrap-table.min.js"></script>
//<script src="~/BsMvc/Grid/bootstrap-xeditable/js/bootstrap-editable.min.js"></script>
//<script src="~/BsMvc/Grid/bootstrap-table/extensions/editable/bootstrap-table-editable.min.js"></script>


//<div class="row">
//        @(Html.BsMvc().Grid("someId").Columns(new List<Column>{
//        new Column("State").Field("state").RowSpan(2).CheckBox(),
//        new Column("EmpId").Field("id").RowSpan(2),
//        new Column("Emp Details").ColSpan(2)
//        })
//        .Columns(new List<Column>{
//        new Column("Emp Name").Field("name"),
//        new Column("Emp Address").Field("price"),
//        })
//        .Height(400)
//        .Url("/Home/GetData")
//        .Pagination()
//        .SidePagination(BsMvc.Widgets.Grid.EPagination.SERVER)
//        .Render())

//    </div>


//<div class="row">
//    @(Html.BsMvc().Grid("someId12").Columns(new List<Column>{
//        new Column("EmpId").Field("id").Class("col-xs-3"),
//        new Column("Emp Details").Field("name").Class("col-xs-3"),
//        new Column("Price ").Field("price").Editable("number", "Some Title").Class("col-xs-3")
//    })
//    .Height(400)
//    .Url("/Home/GetDataSimple")
//    .Pagination()
//    .ShowColumns(true)
//    .ShowToggle(true)
//    .ShowRefresh(true)
//    .SidePagination(BsMvc.Widgets.Grid.EPagination.CLIENT)
//    .Render())
//</div>

