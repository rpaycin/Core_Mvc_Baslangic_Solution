using System;
using System.Collections.Generic;

namespace WebApplication6.Models
{
    public class ErrorViewModel
    {
        public string RequestId { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);

        public List<string> Errors { get; set; } = new List<string>();

        public string ErrorMessage { get; set; }
    }
}
