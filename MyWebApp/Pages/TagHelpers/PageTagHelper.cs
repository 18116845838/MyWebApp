using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyWebApp.Pages.TagHelpers
{
	[HtmlTargetElement("datetime", Attributes = "asp-showicons,asp-only")]
	public class PageTagHelper : TagHelper
	{
		//        声明一个自定义的TagHelper：DateTimeTagHelper，在Razor中使用：
		//    <datetime>@DateTime.Now</datetime>
		//    生成HTML标签：
		//    <small>2019年7月8日 14点59分</small>
		//    可以添加属性：asp-showicon
		//    <datetime asp-showicon="true"> @DateTime.Now</datetime>
		//    当asp-showicon= "true"时，生成的HTML标签包含一个日历图标：
		//    <small><span class="glyphicon glyphicon-calendar"></span>2019年7月8日 14点59分</small>
		//    再添加属性：asp-only
		//    <datetime asp-only="date"> @DateTime.Now</datetime>
		//    当asp-only= "date"时，生成的HTML标签只显示日期，不显示时间
		//    <small>2019年7月8日</small>
		//提示参考：
		//    output.GetChildContentAsync().Result.GetContent()
		//    output.PreContent.SetHtmlContent("")
		public override void Process(TagHelperContext context, TagHelperOutput output)
		{
			output.TagName = "small";
			if (context.AllAttributes["asp-showicons"].Value.ToString()=="true")
			{
				output.PreContent.AppendHtml("<span class=\"fa fa-calendar \"></span>");
			}//else nothing
			if (context.AllAttributes["asp-only"].Value.ToString()=="date")
			{
				output.Content.AppendHtml(
					Convert.ToDateTime(output.GetChildContentAsync()
					.Result.GetContent()).ToString("yyyy年MM月dd日"));
			}//else nothing

			base.Process(context, output);
		}
	}
}
