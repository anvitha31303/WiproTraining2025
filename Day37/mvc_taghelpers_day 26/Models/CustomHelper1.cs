using Microsoft.AspNetCore.Razor.TagHelpers;
using System.Text;

namespace mvc_taghelpers_day_26.Models
{
    public class CustomHelper1
    {
        public class MyCustomTagHelper : TagHelper
        {

            public string Name { get; set; }

            public override void Process(TagHelperContext context, TagHelperOutput output)
            {


                output.TagName = "CustomTagHelper";


                output.TagMode = TagMode.StartTagAndEndTag;

                var sb = new StringBuilder();

                sb.AppendFormat("<span>Hi!{0} </ span > ", this.Name);

                output.PreContent.SetHtmlContent(sb.ToString());
            }
        }
    }
}
