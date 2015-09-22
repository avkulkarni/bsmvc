namespace BsGridExt.BsGridImpl
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Web;
    using System.Web.Mvc;
    using System.Web.Mvc.Html;
    using System.Linq;

    public enum SidePageOptions
    {
        CLIENT,
        SEREVER
    }
    
    public class BsHtmlGrid : IHtmlString
    {
        private List<BsColumn> _gridColumns = new List<BsColumn>();
        private string _gridId;
        private string _url;
        private List<String> _tableClasses = new List<string>();
        private Boolean _isDataStriped;
        private Boolean _isDataSearch;
        private Boolean _isShowRefresh;
        private Boolean _isShowToggle ;        
        private Boolean _isShowColumns;
        private Boolean _isPagination;
        private int _dataHeight;
        private string _sidePagination = "client";

        public BsHtmlGrid(string gridId)
        {
            this._gridId = gridId;
            this._tableClasses.Add("table");
            //this._tableClasses.Add("table-hover");
            //this._tableClasses.Add("table-condensed");             
        }


        public BsHtmlGrid Classes(IEnumerable<String> tableClasses)
        {
            _tableClasses.AddRange(tableClasses);
            _tableClasses = _tableClasses.Distinct().ToList();
            return this;
        }

        /// <summary>
        /// Adds Column to the Grid
        /// </summary>
        /// <param name="column"></param>
        /// <returns></returns>
        public BsHtmlGrid AddColumn(BsColumn column)
        {
            this._gridColumns.Add(column);
            return this;
        }

        /// <summary>
        /// Adds Column to the Grid
        /// </summary>
        /// <param name="columns"></param>
        /// <returns></returns>
        public BsHtmlGrid AddColumn(IEnumerable<BsColumn> columns)
        {
            this._gridColumns.AddRange(columns);
            return this;
        }

        /// <summary>
        /// Sets data-url attribute
        /// </summary>
        /// <param name="serverDataUrl"></param>
        /// <returns></returns>
        public BsHtmlGrid Url(string url)
        {
            this._url = url;
            return this;
        }

        /// <summary>
        /// Sets data-stripped attribute 
        /// </summary>
        /// <param name="isDataStriped"></param>
        /// <returns></returns>
        public BsHtmlGrid DataStriped(Boolean isDataStriped)
        {
            this._isDataStriped = isDataStriped;
            return this;
        }

        /// <summary>
        /// Sets data-search attribute 
        /// </summary>
        /// <param name="isDataSearch"></param>
        /// <returns></returns>
        public BsHtmlGrid DataSearch(Boolean isDataSearch)
        {
            this._isDataSearch = isDataSearch;
            return this;
        }

        /// <summary>
        /// Sets data-show-refresh attribute 
        /// </summary>
        /// <param name="isShowRefresh"></param>
        /// <returns></returns>
        public BsHtmlGrid ShowRefresh(Boolean isShowRefresh)
        {
            this._isShowRefresh = isShowRefresh;
            return this;
        }

        /// <summary>
        /// Sets data-show-toggle attribute 
        /// </summary>
        /// <param name="isShowToggle"></param>
        /// <returns></returns>
        public BsHtmlGrid ShowToggle(Boolean isShowToggle)
        {
            this._isShowToggle = isShowToggle;
            return this;
        }

        /// <summary>
        /// Sets data-show-columns attribute 
        /// </summary>
        /// <param name="isShowColumns"></param>
        /// <returns></returns>
        public BsHtmlGrid ShowColumns(Boolean isShowColumns)
        {
            this._isShowColumns = isShowColumns;
            return this;
        }

        /// <summary>
        /// Sets data-pagination attribute 
        /// </summary>
        /// <param name="isPagination"></param>
        /// <returns></returns>
        public BsHtmlGrid Pagination(Boolean isPagination)
        {
            this._isPagination = isPagination;
            return this;
        }

        /// <summary>
        /// Sets data-height attribute 
        /// </summary>
        /// <param name="dataHeight"></param>
        /// <returns></returns>
        public BsHtmlGrid Height(int dataHeight)
        {
            this._dataHeight = dataHeight;
            return this;
        }


        /// <summary>
        /// Sets data-side-pagination option.
        /// </summary>
        /// <param name="spOption"></param>
        /// <returns></returns>
        public BsHtmlGrid SidePagination(SidePageOptions spOption)
        {
            this._sidePagination = spOption.ToString().ToLower();
            return this;
        }

        public override string ToString()
        {
            StringBuilder htmlTable = new StringBuilder();
            htmlTable = htmlTable.Append("<table ");

            // Append Table classes
            StringBuilder tableClassesStr = new StringBuilder();
            _tableClasses.ForEach(cl => tableClassesStr.AppendFormat(" {0} ", cl.ToString()));
            htmlTable.AppendFormat(" data-classes='{0}' ", tableClassesStr.ToString());

            // Append Server Data URL
            if (!String.IsNullOrEmpty(this._url))
                htmlTable.AppendFormat(" data-url='{0}'", this._url);
                      
                        
            //htmlTable.AppendFormat("<table data-toggle='table' data-url='{0}' data-classes='table table-hover table-condensed' data-striped='true' data-search='true' data-show-refresh='true' 
            // data-show-toggle='true' data-show-columns='true' data-pagination='true' data-height='400'>", this._url);

            // Add data-toggle attribute
            htmlTable.AppendFormat(" data-toggle='{0}' ", "table");
            
            // Add data-striped attribute
            htmlTable.AppendFormat(" data-striped='{0}' ", this._isDataStriped.ToString().ToLower());

            // Add data-search attribute
            htmlTable.AppendFormat(" data-search='{0}' ", this._isDataSearch.ToString().ToLower());

            // Add data-show-refresh attribute
            htmlTable.AppendFormat(" data-show-refresh='{0}' ", this._isShowRefresh.ToString().ToLower());

            // Add data-show-toggle attribute
            htmlTable.AppendFormat(" data-show-toggle='{0}' ", this._isShowToggle.ToString().ToLower());

            // Add data-show-columns attribute
            htmlTable.AppendFormat(" data-show-columns='{0}' ", this._isShowColumns.ToString().ToLower());

            // Add data-pagination attribute
            htmlTable.AppendFormat(" data-pagination='{0}' ", this._isPagination.ToString().ToLower());

            // Add data-height attribute
            htmlTable.AppendFormat(" data-height='{0}' ", this._dataHeight.ToString().ToLower());

            // Close table tag
            htmlTable.Append(" > ");

            StringBuilder htmlRowHeaders = new StringBuilder();
            htmlRowHeaders.Append("<thead> <tr>");
            this._gridColumns.ForEach(gr => htmlRowHeaders.Append(gr.ToString()));            
            htmlRowHeaders.Append(" </tr> </thead>");

            htmlTable.Append(htmlRowHeaders);

            htmlTable.Append("   </table>");
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
