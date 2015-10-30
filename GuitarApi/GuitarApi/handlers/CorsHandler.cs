using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace GuitarApi.handlers
{
    /// <summary>
    /// This handler will asynchronously process requests looking for 
    /// OPTIONS requests, then it will decorate a preflight response to
    /// send back to the client.
    /// </summary>
    public class CorsHandler : DelegatingHandler
    {
        private readonly CorsOptions _corsOptions;
        private const string Origin = "Origin";
        private const string AccessControlRequestMethod = "Access-Control-Request-Method";
        private const string AccessControlRequestHeaders = "Access-Control-Request-Headers";
        private const string AccessControlAllowOrigin = "Access-Control-Allow-Origin";
        private const string AccessControlAllowMethods = "Access-Control-Allow-Methods";
        private const string AccessControlAllowHeaders = "Access-Control-Allow-Headers";

        public CorsHandler(CorsOptions corsOptions)
        {
            _corsOptions = corsOptions;
        }

        /// <summary>
        /// Processes the request, sends the appropriate preflight response
        /// for CORS preflight requests. Also sets the Access-Control-Allow-Origin
        /// for other CORS requests.
        /// </summary>
        /// <param name="request">The request to process.</param>
        /// <param name="cancellationToken">A cancellation token to cancel processing the request.</param>
        /// <returns>A continuation for additional request processing.</returns>
        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            if (IsCorsRequest(request))
            {
                if (!IsAllowedOrigin(request))
                {
                    var tcs = new TaskCompletionSource<HttpResponseMessage>();
                    tcs.SetResult(new HttpResponseMessage(HttpStatusCode.OK));
                    return tcs.Task;
                }

                if (IsPreflightRequest(request))
                {
                    var tcs = new TaskCompletionSource<HttpResponseMessage>();
                    var response = CreatePreflightResponse(request);
                    tcs.SetResult(response);
                    return tcs.Task;
                }

                return base.SendAsync(request, cancellationToken)
                    .ContinueWith(t =>
                    {
                        var resp = t.Result;
                        SetAllowedOriginToRequestedOrigin(request, resp);
                        return resp;
                    });
            }

            return base.SendAsync(request, cancellationToken);
        }

        /// <summary>
        /// Checks a request to see if it's a preflight request for CORS
        /// </summary>
        /// <param name="request">The request to check</param>
        /// <returns>True if the request is a preflight</returns>
        public static bool IsPreflightRequest(HttpRequestMessage request)
        {
            return request.Method == HttpMethod.Options;
        }

        /// <summary>
        /// Checks to see if the request is a CORS request.
        /// </summary>
        /// <param name="request">The request to check</param>
        /// <returns>true if the request is a CORS request</returns>
        public static bool IsCorsRequest(HttpRequestMessage request)
        {
            return request.Headers.Contains(Origin);
        }

        /// <summary>
        /// Sets Access-Control-Allow-Origin on the Response to
        /// whatever value was passed in the Origin header on the 
        /// request.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <param name="response">The response.</param>
        public static void SetAllowedOriginToRequestedOrigin(HttpRequestMessage request, HttpResponseMessage response)
        {
            response.Headers.Add(AccessControlAllowOrigin, request.Headers.GetValues(Origin).First());
        }

        /// <summary>
        /// Creates a preflight response based on a request.
        /// </summary>
        /// <param name="request">The request to base the preflight response on.</param>
        /// <returns>A preflight response with proper headers.</returns>
        public HttpResponseMessage CreatePreflightResponse(HttpRequestMessage request)
        {
            // create a new response message.
            var response = new HttpResponseMessage(HttpStatusCode.OK);

            SetAllowedOriginToRequestedOrigin(request, response);

            SetAllowedMethodsToRequestedMethod(request, response);

            SetAllowedHeadersToRequestedHeaders(request, response);

            return response;
        }

        private bool IsAllowedOrigin(HttpRequestMessage request)
        {
            if (_corsOptions.AllowedOrigins.Contains("*"))
            {
                return true;
            }

            var origin = request.Headers.GetValues(Origin).First().ToLower();

            return _corsOptions.AllowedOrigins.Contains(origin);
        }

        /// <summary>
        /// Sets the allowed headers to whatever headers were requested.
        /// </summary>
        /// <param name="request">the request to get the headers from</param>
        /// <param name="response">the response to set the headers on.</param>
        public static void SetAllowedHeadersToRequestedHeaders(HttpRequestMessage request, HttpResponseMessage response)
        {
            var requestedHeaders = string.Join(", ", request.Headers.GetValues(AccessControlRequestHeaders));
            if (!string.IsNullOrEmpty(requestedHeaders))
            {
                response.Headers.Add(AccessControlAllowHeaders, requestedHeaders);
            }
        }

        /// <summary>
        /// Sets the allowed methods to whatever method was requested.
        /// </summary>
        public static void SetAllowedMethodsToRequestedMethod(HttpRequestMessage request, HttpResponseMessage response)
        {
            var requestedMethod = request.Headers.GetValues(AccessControlRequestMethod).FirstOrDefault();
            if (requestedMethod != null)
            {
                response.Headers.Add(AccessControlAllowMethods, requestedMethod);
            }
        }
    }
}
