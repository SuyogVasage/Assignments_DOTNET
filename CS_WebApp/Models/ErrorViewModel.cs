using System;

namespace CS_WebApp.Models
{
    public class ErrorViewModel
    {
        public string RequestId { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);

        // Modify the Model By adding the fllowing properties
        // COntroller NAme where the Exception is thrown
        public string ControllerName { get; set; }
        // Action NAme that thros exception
        public string ActionName { get; set; }
        // The Error MEssage Thrown
        public string ErrorMessage { get; set; }

        public string ErrorType { get; set; }
    }
}
