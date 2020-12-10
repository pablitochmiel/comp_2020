using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Spa.Pages
{
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public class ErrorModel : PageModel
    {
        public ErrorModel(string? requestId)
        {
            RequestId = requestId;
        }
        // private readonly ILogger<ErrorModel> _logger;
        //
        // public ErrorModel(ILogger<ErrorModel> logger)
        // {
        //     _logger = logger;
        // }

        public string? RequestId { get; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);

        // public void OnGet()
        // {
        //     RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier;
        // }
    }
}