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


    public class Grid : IHtmlString
    {
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

        public Grid(string gridId, HtmlHelper htmlHelper)
        {
            this._gridId = gridId;
            this._htmlHelper = htmlHelper;
        }

        #region GRID_ATTRS

        public Grid Classes(IEnumerable<String> tableClasses)
        {
            _tableClasses.AddRange(tableClasses);
            _tableClasses = _tableClasses.Distinct().ToList();
            return this;
        }

        public Grid Height(int dataHeight)
        {
            this._dataHeight = dataHeight;
            return this;
        }
        public Grid UndefinedText(string undefinedText)
        {
            this._undefinedText = undefinedText;
            return this;
        }

        public Grid Striped()
        {
            this._isDataStriped = true;
            return this;
        }

        public Grid SortName(string sortName)
        {
            this._sortName = sortName;
            return this;
        }

        public Grid SortOrder(string sortOrder)
        {
            this._sortOrder = sortOrder;
            return this;
        }

        public Grid IconsPrefix(string iconsPrefix)
        {
            this._iconsPrefix = iconsPrefix;
            return this;
        }

        public Grid Columns(List<Column> columns)
        {
            this._columnsGroups.Add(new ColumnsGroup(columns));
            return this;
        }

        public Grid Method(string methodType)
        {
            this._methodType = methodType;
            return this;
        }

        public Grid Url(string url)
        {
            this._url = url;
            return this;
        }

        public Grid Cache(Boolean isCache)
        {
            this._isCache = isCache;
            return this;
        }

        public Grid ContentType(string contentType)
        {
            this._contentType = contentType;
            return this;
        }

        public Grid DataType(string dataType)
        {
            this._contentType = dataType;
            return this;
        }

        public Grid AjaxOptions(string ajaxOptions)
        {
            this._ajaxOptions = ajaxOptions;
            return this;
        }

        public Grid QueryParams(string queryParamsFunName)
        {
            this._queryParamsFunName = queryParamsFunName;
            return this;
        }

        public Grid QueryParamsType(string queryParamsType)
        {
            this._queryParamsType = queryParamsType;
            return this;
        }

        public Grid ResponseHandler(string responseHandlerFunName)
        {
            this._responseHandlerFunName = responseHandlerFunName;
            return this;
        }


        public Grid Pagination()
        {
            this._isPagination = true;
            return this;
        }



        public Grid SidePagination(EPagination spOption)
        {
            this._sidePagination = spOption.ToString().ToLower();
            return this;
        }

        public Grid PageNumber(int pageNumber)
        {
            this._pageNumber = pageNumber;
            return this;
        }

        public Grid PageSize(int pageSize)
        {
            this._pageSize = pageSize;
            return this;
        }

        public Grid PageList(string pageList)
        {
            this._pageList = pageList;
            return this;
        }

        public Grid SelectItemName(string selectItemName)
        {
            this._selectItemName = selectItemName;
            return this;
        }

        public Grid SmartDisplay(Boolean smartDisplay)
        {
            this._isSmartDisplay = smartDisplay;
            return this;
        }


        public Grid Search(Boolean search)
        {
            this._isSearch = search;
            return this;
        }

        public Grid StrictSearch(Boolean strictSearch)
        {
            this._isStrictSearch = strictSearch;
            return this;
        }


        public Grid SearchText(string searchText)
        {
            this._searchText = searchText;
            return this;
        }

        public Grid SearchTimeOut(int searchTimeOut)
        {
            this._searchTimeOut = searchTimeOut;
            return this;
        }

        public Grid TrimOnSearch(Boolean trimOnSearch)
        {
            this._isTrimOnSearch = trimOnSearch;
            return this;
        }

        public Grid ShowHeader(Boolean showHeader)
        {
            this._isShowHeader = showHeader;
            return this;
        }

        public Grid ShowFooter(Boolean showFooter)
        {
            this._showFooter = showFooter;
            return this;
        }



        public Grid ShowColumns(Boolean isShowColumns)
        {
            this._isShowColumns = isShowColumns;
            return this;
        }

        public Grid ShowRefresh(Boolean isShowRefresh)
        {
            this._isShowRefresh = isShowRefresh;
            return this;
        }

        public Grid ShowToggle(Boolean isShowToggle)
        {
            this._isShowToggle = isShowToggle;
            return this;
        }

        public Grid ShowPaginationSwitch(Boolean showPaginationSwitch)
        {
            this._isShowPaginationSwitch = showPaginationSwitch;
            return this;
        }

        public Grid MinimumCountColumns(Boolean minimumCountColumns)
        {
            this._isMinimumCountColumns = minimumCountColumns;
            return this;
        }

        public Grid IdField(string idField)
        {
            this._idField = idField;
            return this;
        }

        public Grid UniqueId(string uniqueId)
        {
            this._uniqueId = uniqueId;
            return this;
        }

        public Grid CardView(Boolean isCardView)
        {
            this._isCardView = isCardView;
            return this;
        }

        public Grid DetailView(Boolean isDetailView)
        {
            this._isDetailView = isDetailView;
            return this;
        }

        public Grid DetailFormatter(Boolean detailFormatterFunName)
        {
            this._detailFormatterFunName = detailFormatterFunName;
            return this;
        }

        public Grid SearchAlign(string searchAlign)
        {
            this._searchAlign = searchAlign;
            return this;
        }

        public Grid ButtonsAlign(string buttonsAlign)
        {
            this._buttonsAlign = buttonsAlign;
            return this;
        }

        public Grid ToolbarAlign(string toolbarAlign)
        {
            this._toolbarAlign = toolbarAlign;
            return this;
        }

        public Grid PaginationVAlign(string paginationVAlign)
        {
            this._paginationVAlign = paginationVAlign;
            return this;
        }

        public Grid PaginationHAlign(string paginationHAlign)
        {
            this._paginationHAlign = paginationHAlign;
            return this;
        }

        public Grid PaginationDetailHAlign(string paginationDetailHAlign)
        {
            this._paginationDetailHAlign = paginationDetailHAlign;
            return this;
        }

        public Grid PaginationFirstText(string paginationFirstText)
        {
            this._paginationFirstText = paginationFirstText;
            return this;
        }


        public Grid PaginationPreText(string paginationPreText)
        {
            this._paginationPreText = paginationPreText;
            return this;
        }

        public Grid PaginationNextText(string paginationNextText)
        {
            this._paginationNextText = paginationNextText;
            return this;
        }

        public Grid PaginationLastText(string paginationLastText)
        {
            this._paginationLastText = paginationLastText;
            return this;
        }

        public Grid ClickToSelect(Boolean clickToSelect)
        {
            this._isClickToSelect = clickToSelect;
            return this;
        }

        public Grid SingleSelect(Boolean singleSelect)
        {
            this._isSingleSelect = singleSelect;
            return this;
        }

        public Grid Toolbar(string toolbar)
        {
            this._toolbar = toolbar;
            return this;
        }

        public Grid CheckboxHeader(Boolean checkboxHeader)
        {
            this._isCheckboxHeader = checkboxHeader;
            return this;
        }

        public Grid MaintainSelected(Boolean maintainSelected)
        {
            this._isMaintainSelected = maintainSelected;
            return this;
        }

        public Grid Sortable(Boolean sortable)
        {
            this._isSortable = sortable;
            return this;
        }
        public Grid silentSort(Boolean silentSort)
        {
            this.isSilentSort = silentSort;
            return this;
        }

        public Grid RowStyle(string rowStyleFunName)
        {
            this._rowStyleFunName = rowStyleFunName;
            return this;
        }

        public Grid rowAttributes(string rowAttributesFunName)
        {
            this._rowAttributesFunName = rowAttributesFunName;
            return this;
        }

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
            return "";
        }

        private string RenderJavascript()
        {
            List<List<Column>> clnsList = new List<List<Column>>();
            this._columnsGroups.ForEach(col => clnsList.Add(col.GridColumns));            
            // string columnsJson = "";

            //if (clnsList.Count == 1)
            //{
            //    columnsJson = "{'columns':" + JsonConvert.SerializeObject(clnsList.FirstOrDefault()) + "}";
            //}
            //else
            //{
            //    columnsJson = "{'columns':" + JsonConvert.SerializeObject(clnsList) + "}";
            //}

            if (clnsList.Count == 1)
            {
                //columnsJson = "JSON.parse('" + JsonConvert.SerializeObject(clnsList.FirstOrDefault()) + "')";
                this._gridColumnsJson = clnsList.FirstOrDefault();
            }
            else
            {
                //columnsJson = "JSON.parse('" + JsonConvert.SerializeObject(clnsList) + "')";
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
            // Append Table classes
            StringBuilder tableClassesStr = new StringBuilder();
            _tableClasses.ForEach(cl => tableClassesStr.AppendFormat(" {0} ", cl.ToString()));
            this._tableClassesStr = tableClassesStr.ToString();
            StringBuilder htmlTable = new StringBuilder();
//            htmlTable = htmlTable.AppendFormat(@"
//                <table id='{0}'
//                       data-classes='{1}'
//                       data-url='{2}' 
//                       data-undefined-text='{3}'                      
//                       data-striped='{4}'
//                       data-search='{5}'
//                       data-show-refresh='{6}'
//                       data-show-toggle='{7}'
//                       data-show-columns='{8}'                        
//                       data-pagination='{9}'
//                       data-height='{10}'
//                       data-side-pagination='{11}'></table>",
//             this._gridId, tableClassesStr.ToString(), this._url, "-",
//             this._isDataStriped.ToString().ToLower(), this._isSearch.ToString().ToLower(),
//             this._isShowRefresh.ToString().ToLower(), this._isShowToggle.ToString().ToLower(),
//             this._isShowColumns.ToString().ToLower(), this._isPagination.ToString().ToLower(),
//             this._dataHeight.ToString().ToLower(), this._sidePagination);

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

