namespace HardwareStore.App.TagHelpers
{
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
    using Microsoft.AspNetCore.Razor.TagHelpers;

    [HtmlTargetElement("li", Attributes = "custom-active")]
    public class ActiveLinkTagHelper : TagHelper
    {
        [ViewContext]
        public ViewContext ViewContext { get; set; }

        public string TextColorClass { get; set; }

        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {

            var currentUrl = ViewContext.HttpContext.Request.Path;
            currentUrl = currentUrl.ToString().Split('?')[0];

            var child = await output.GetChildContentAsync();
            var anchorTag = child.GetContent();

            if (anchorTag.Contains($"href=\"{currentUrl}\""))
            {
                var existingClasses = output.Attributes["class"]?.Value?.ToString() ?? "";
                var childClasses = child.GetContent().Split().ToList();

                var newClass = TextColorClass;
                var index = childClasses.FindIndex(x => x.Contains("class"));

                childClasses.Insert(index + 1, newClass);
                var childHtml = string.Join(" ", childClasses);


                output.Attributes.SetAttribute("class", $"{existingClasses} active");
                output.Content.SetHtmlContent(childHtml);

            }
            output.Attributes.RemoveAll("custom-active");

        }

    }
}
