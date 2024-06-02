
using System.Net; // Add this line to include the System.Net namespace
using System.Collections.Generic;

namespace server.Domain.Models
{
    public class ApiResponse{
        public ApiResponse()
        {
            // ErrorMessage = new List<string>();
        }
        public bool IsSuccess { get; set; }
        public object Result { get; set; }
        public HttpStatusCode StatusCode { get; set; }
        public string ErrorMessage { get; set; }
    }
}