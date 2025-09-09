//using Microsoft.AspNetCore.Mvc.Rendering;
//using System.Web.Mvc;
//using static System.Net.Mime.MediaTypeNames;

//html helpers          vs      tag helpers
//mvc older 4 ,5                  mvc core
//customization of html elements/tags


//namespace mvc_taghelpers_day_26.customhelper
//{
//    public class Customhelper
//    {
//        public static MvcHtmlString Image(string source, string altTxt, string width, string height)
//        {

//            //TagBuilder creates a new tag with the tag name specified

//        }

//        var ImageTag = new System.Web.Mvc.TagBuilder("img");

//        //MergeAttribute Adds attribute to the tag

//        ImageTag.MergeAttribute("src", source);

//ImageTag.MergeAttribute("alt", altTxt);

//ImageTag.MergeAttribute("width", width);

//        ImageTag.MergeAttribute("height", height);



////Return an HTML encoded string with SelfClosing TagRenderMode
// return MvcHtmlString.Create(ImageTag.ToString(TagRenderMode.SelfClosing));
//    }
//}
