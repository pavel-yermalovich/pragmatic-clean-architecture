using Serilog.Context;

namespace Bookify.Api.Middleware;

public class RequestContextLoggingMiddleware
{
	private const string CorrelationIdHeaderName = "X-Correlation-Id";
	
	private readonly RequestDelegate _next;

	public RequestContextLoggingMiddleware(RequestDelegate next)
	{
		_next = next;
	}

	public Task Invoke(HttpContext context)
	{
		using (LogContext.PushProperty("CorrelationId", GetCorrelationId(context)))
		{
			return _next(context);
		}
	}

	private static string GetCorrelationId(HttpContext httpContext)
	{
		httpContext.Request.Headers.TryGetValue(CorrelationIdHeaderName, out var correlationId);

		return correlationId.FirstOrDefault() ?? httpContext.TraceIdentifier;
	}
}

