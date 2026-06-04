using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using taskmanager_mvc.Models;

namespace taskmanager_mvc.Helpers;

public static class HtmlHelperExtensions
{
    public static IHtmlContent PriorityBadge(this IHtmlHelper html, Priority priority)
    {
        var (cssClass, label) = priority switch
        {
            Priority.Visok => ("bg-danger",           "Visok"),
            Priority.Normalan => ("bg-warning text-dark", "Normalan"),
            Priority.Nizak => ("bg-success",           "Nizak"),
            _ => ("bg-secondary",          priority.ToString())
        };

        return new HtmlString($"<span class=\"badge {cssClass}\">{label}</span>");
    }
}