using System;
using System.Collections.Generic;

#nullable disable

namespace CS_WebApp.Models
{
    public partial class RequestLog
    {
        public int RequestId { get; set; }
        public DateTime? RequestDateTime { get; set; }
        public string ControllerName { get; set; }
        public string ActionName { get; set; }
        public string ExecutionCompletionTime { get; set; }
    }
}
