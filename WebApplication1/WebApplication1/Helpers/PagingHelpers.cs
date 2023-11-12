using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using System.Text;
using System.Web;
using WebApplication1.Models.ViewModels;

namespace WebApplication1.Helpers
{
    public static class PagingHelpers
    {
        public static IHtmlContent PageLinks(this IHtmlHelper html, PageInfo pageInfo, Func<int, string> pageUrl)
        {
            HtmlContentBuilder hb = new();
            for (int i = 1; i <= pageInfo.totalPages; i++)
            {
                TagBuilder tag = new("a");
                tag.MergeAttribute("href", pageUrl(i));
                tag.InnerHtml.AppendHtml(i.ToString());

                if (i == pageInfo.pageNumber)
                {
                    tag.AddCssClass("selected");
                    tag.AddCssClass("btn-primary");
                }
                tag.AddCssClass("btn btn-default");

                if((i >= pageInfo.pageNumber - 1 && i <= pageInfo.pageNumber + 1) || i == pageInfo.totalPages || i == 1)
                {
                    hb.AppendHtml(tag);
                }
                else if(i == pageInfo.pageNumber + 2 || i == pageInfo.pageNumber - 2)
                {
                    hb.AppendHtml("...");
                } 
            }

            return hb;
        }
    }
}
