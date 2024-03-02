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

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {

            var currentUrl = ViewContext.HttpContext.Request.Path;
            currentUrl = currentUrl.ToString().Split('?')[0];

            var anchorTag = output.GetChildContentAsync().Result.GetContent();

            if (anchorTag.Contains($"href=\"{currentUrl}\""))
            {
                var existingClasses = output.Attributes["class"]?.Value?.ToString() ?? "";
                output.Attributes.SetAttribute("class", $"{existingClasses} active");

            }
            output.Attributes.RemoveAll("custom-active");

        }
    }
}
