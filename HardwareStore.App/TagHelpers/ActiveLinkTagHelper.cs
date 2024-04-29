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

                
                var index = childClasses.FindIndex(x => x.Contains("class"));
                if (index != -1)
                {
                    var classString =
                    $"{childClasses[index].Replace("class=", string.Empty).Replace("\"", string.Empty)}";
                    

                    childClasses[index] = $"class=\"{classString} {TextColorClass}\"";
                }
                

                var childHtml = string.Join(" ", childClasses);

                output.Attributes.SetAttribute("class", $"{existingClasses} active");
                output.Content.SetHtmlContent(childHtml);

            }
            output.Attributes.RemoveAll("custom-active");

        }

    }
}
