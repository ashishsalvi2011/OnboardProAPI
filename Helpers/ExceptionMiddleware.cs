using OnboardPro.Interface;

namespace OnboardPro.Helper
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionMiddleware> _logger;
        private readonly IResponse _responseService;

        public ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger, IResponse responseService)
        {
            _next = next;
            _logger = logger;
            _responseService = responseService;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Unhandled Exception Occurred!");

                httpContext.Response.ContentType = "application/json";
                httpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;

                var errorResponse = _responseService.FailureResult(ex.Message);
                await httpContext.Response.WriteAsJsonAsync(errorResponse);
            }
        }
    }
}
