using BankApp.Web.Data.Context;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace BankApp.Web.TagHelpers
{

    [HtmlTargetElement("getAccountCount")]
    public class GetBankAccountCount : TagHelper
    {
        public int UserId { get; set; }
        private readonly BankContext _bankContext;
       
        public GetBankAccountCount(BankContext bankContext)
        {
            _bankContext = bankContext;
        }
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            var accountCount = _bankContext.Accounts.Count(x => x.UserId == UserId);
            var html = $"<span class='badge bg-danger'> {accountCount}</span>";

            output.Content.SetHtmlContent(html);
        }
    }
}
