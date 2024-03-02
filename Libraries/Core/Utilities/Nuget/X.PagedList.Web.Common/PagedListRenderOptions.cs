namespace Core.Utilities.Nuget.X.PagedList.Web.Common
{
    using global::X.PagedList.Web.Common;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.Encodings.Web;
    public sealed class PagedListRenderOptions
    {
        public PagedListRenderOptions()
        {
            HtmlEncoder = HtmlEncoder.Default;
            DisplayLinkToFirstPage = PagedListDisplayMode.IfNeeded;
            DisplayLinkToLastPage = PagedListDisplayMode.IfNeeded;
            DisplayLinkToPreviousPage = PagedListDisplayMode.IfNeeded;
            DisplayLinkToNextPage = PagedListDisplayMode.IfNeeded;
            DisplayLinkToIndividualPages = true;
            DisplayPageCountAndCurrentLocation = false;
            MaximumPageNumbersToDisplay = 10;
            DisplayEllipsesWhenNotShowingAllPageNumbers = true;
            EllipsesFormat = "&#8230;";
            LinkToFirstPageFormat = "<<";
            LinkToPreviousPageFormat = "<";
            LinkToIndividualPageFormat = "{0}";
            LinkToNextPageFormat = ">";
            LinkToLastPageFormat = ">>";
            PageCountAndCurrentLocationFormat = "Page {0} of {1}.";
            ItemSliceAndTotalFormat = "Showing items {0} through {1} of {2}.";
            FunctionToDisplayEachPageNumber = null;
            ClassToApplyToFirstListItemInPager = null;
            ClassToApplyToLastListItemInPager = null;
            ContainerDivClasses = new[] { "pagination-container" };
            UlElementClasses = new[] { "pagination" };
            LiElementClasses = Enumerable.Empty<string>();
            PageClasses = Enumerable.Empty<string>();
            UlElementattributes = null;
            ActiveLiElementClass = "active";
            EllipsesElementClass = "PagedList-ellipses";
            PreviousElementClass = "PagedList-skipToPrevious";
            NextElementClass = "PagedList-skipToNext";
        }
        public HtmlEncoder HtmlEncoder { get; set; }
        public IEnumerable<string> ContainerDivClasses { get; set; }
        public IEnumerable<string> UlElementClasses { get; set; }
        public IDictionary<string, string> UlElementattributes { get; set; }
        public IEnumerable<string> LiElementClasses { get; set; }
        public string ActiveLiElementClass { get; set; }
        public IEnumerable<string> PageClasses { get; set; }
        public string PreviousElementClass { get; set; }
        public string NextElementClass { get; set; }
        public string EllipsesElementClass { get; set; }
        public string ClassToApplyToFirstListItemInPager { get; set; }
        public string ClassToApplyToLastListItemInPager { get; set; }
        public PagedListDisplayMode Display { get; set; }
        public PagedListDisplayMode DisplayLinkToFirstPage { get; set; }
        public PagedListDisplayMode DisplayLinkToLastPage { get; set; }
        public PagedListDisplayMode DisplayLinkToPreviousPage { get; set; }
        public PagedListDisplayMode DisplayLinkToNextPage { get; set; }
        public bool DisplayLinkToIndividualPages { get; set; }
        public bool DisplayPageCountAndCurrentLocation { get; set; }
        public bool DisplayItemSliceAndTotal { get; set; }
        public int? MaximumPageNumbersToDisplay { get; set; }
        public bool DisplayEllipsesWhenNotShowingAllPageNumbers { get; set; }
        public string EllipsesFormat { get; set; }
        public string LinkToFirstPageFormat { get; set; }
        public string LinkToPreviousPageFormat { get; set; }
        public string LinkToIndividualPageFormat { get; set; }
        public string LinkToNextPageFormat { get; set; }
        public string LinkToLastPageFormat { get; set; }
        public string PageCountAndCurrentLocationFormat { get; set; }
        public string ItemSliceAndTotalFormat { get; set; }
        public Func<int, string> FunctionToDisplayEachPageNumber { get; set; }
        public string DelimiterBetweenPageNumbers { get; set; }
        public static PagedListRenderOptions Classic => new PagedListRenderOptions
        {
            DisplayLinkToFirstPage = PagedListDisplayMode.Never,
            DisplayLinkToLastPage = PagedListDisplayMode.Never,
            DisplayLinkToPreviousPage = PagedListDisplayMode.Always,
            DisplayLinkToNextPage = PagedListDisplayMode.Always
        };
        public static PagedListRenderOptions ClassicPlusFirstAndLast => new PagedListRenderOptions
        {
            DisplayLinkToFirstPage = PagedListDisplayMode.Always,
            DisplayLinkToLastPage = PagedListDisplayMode.Always,
            DisplayLinkToPreviousPage = PagedListDisplayMode.Always,
            DisplayLinkToNextPage = PagedListDisplayMode.Always
        };
        public static PagedListRenderOptions Minimal => new PagedListRenderOptions
        {
            DisplayLinkToFirstPage = PagedListDisplayMode.Never,
            DisplayLinkToLastPage = PagedListDisplayMode.Never,
            DisplayLinkToPreviousPage = PagedListDisplayMode.Always,
            DisplayLinkToNextPage = PagedListDisplayMode.Always,
            DisplayLinkToIndividualPages = false
        };
        public static PagedListRenderOptions MinimalWithPageCountText => new PagedListRenderOptions
        {
            DisplayLinkToFirstPage = PagedListDisplayMode.Never,
            DisplayLinkToLastPage = PagedListDisplayMode.Never,
            DisplayLinkToPreviousPage = PagedListDisplayMode.Always,
            DisplayLinkToNextPage = PagedListDisplayMode.Always,
            DisplayLinkToIndividualPages = false,
            DisplayPageCountAndCurrentLocation = true
        };
        public static PagedListRenderOptions MinimalWithItemCountText => new PagedListRenderOptions
        {
            DisplayLinkToFirstPage = PagedListDisplayMode.Never,
            DisplayLinkToLastPage = PagedListDisplayMode.Never,
            DisplayLinkToPreviousPage = PagedListDisplayMode.Always,
            DisplayLinkToNextPage = PagedListDisplayMode.Always,
            DisplayLinkToIndividualPages = false,
            DisplayItemSliceAndTotal = true
        };
        public static PagedListRenderOptions PageNumbersOnly => new PagedListRenderOptions
        {
            DisplayLinkToFirstPage = PagedListDisplayMode.Never,
            DisplayLinkToLastPage = PagedListDisplayMode.Never,
            DisplayLinkToPreviousPage = PagedListDisplayMode.Never,
            DisplayLinkToNextPage = PagedListDisplayMode.Never,
            DisplayEllipsesWhenNotShowingAllPageNumbers = false
        };
        public static PagedListRenderOptions OnlyShowFivePagesAtATime => new PagedListRenderOptions
        {
            DisplayLinkToFirstPage = PagedListDisplayMode.Never,
            DisplayLinkToLastPage = PagedListDisplayMode.Never,
            DisplayLinkToPreviousPage = PagedListDisplayMode.Always,
            DisplayLinkToNextPage = PagedListDisplayMode.Always,
            MaximumPageNumbersToDisplay = 5
        };
        public static PagedListRenderOptions TwitterBootstrapPager => new PagedListRenderOptions
        {
            DisplayLinkToFirstPage = PagedListDisplayMode.Never,
            DisplayLinkToLastPage = PagedListDisplayMode.Never,
            DisplayLinkToPreviousPage = PagedListDisplayMode.Always,
            DisplayLinkToNextPage = PagedListDisplayMode.Always,
            DisplayLinkToIndividualPages = false,
            ContainerDivClasses = null,
            UlElementClasses = new[] { "pager" },
            ClassToApplyToFirstListItemInPager = null,
            ClassToApplyToLastListItemInPager = null,
            LinkToPreviousPageFormat = "Previous",
            LinkToNextPageFormat = "Next"
        };
        public static PagedListRenderOptions TwitterBootstrapPagerAligned => new PagedListRenderOptions
        {
            DisplayLinkToFirstPage = PagedListDisplayMode.Never,
            DisplayLinkToLastPage = PagedListDisplayMode.Never,
            DisplayLinkToPreviousPage = PagedListDisplayMode.Always,
            DisplayLinkToNextPage = PagedListDisplayMode.Always,
            DisplayLinkToIndividualPages = false,
            ContainerDivClasses = null,
            UlElementClasses = new[] { "pager" },
            ClassToApplyToFirstListItemInPager = "previous",
            ClassToApplyToLastListItemInPager = "next",
            LinkToPreviousPageFormat = "&larr; Older",
            LinkToNextPageFormat = "Newer &rarr;"
        };
        public Func<ITagBuilder, ITagBuilder, ITagBuilder> FunctionToTransformEachPageLink { get; set; }
        public static PagedListRenderOptions EnableUnobtrusiveAjaxReplacing(PagedListRenderOptions options, AjaxOptions ajaxOptions)
        {
            if (options is PagedListRenderOptions renderOptions)
            {
                renderOptions.FunctionToTransformEachPageLink = (liTagBuilder, aTagBuilder) =>
                {
                    var liClass = liTagBuilder.Attributes.ContainsKey("class")
                        ? liTagBuilder.Attributes["class"] ?? string.Empty
                        : string.Empty;
                    if (ajaxOptions != null && !liClass.Contains("disabled") && !liClass.Contains("active"))
                    {
                        foreach (var ajaxOption in ajaxOptions.ToUnobtrusiveHtmlAttributes())
                        {
                            aTagBuilder.Attributes.Add(ajaxOption.Key, ajaxOption.Value.ToString());
                        }
                    }
                    liTagBuilder.AppendHtml(aTagBuilder.ToString());
                    return liTagBuilder;
                };
            }
            return options;
        }
        public static PagedListRenderOptions EnableUnobtrusiveAjaxReplacing(string id)
        {
            if (id.StartsWith("#"))
                id = id.Substring(1);
            var ajaxOptions = new AjaxOptions()
            {
                HttpMethod = "GET",
                InsertionMode = InsertionMode.Replace,
                UpdateTargetId = id
            };
            return EnableUnobtrusiveAjaxReplacing(new PagedListRenderOptions(), ajaxOptions);
        }
        public static PagedListRenderOptions EnableUnobtrusiveAjaxReplacing(AjaxOptions ajaxOptions)
        {
            return EnableUnobtrusiveAjaxReplacing(new PagedListRenderOptions(), ajaxOptions);
        }
    }
}