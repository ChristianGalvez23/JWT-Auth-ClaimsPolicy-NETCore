using System;
using System.Net;

namespace business.Models {
    public class HttpMessageModel {
        public string Message { get; set; }
        public MessageStatusCode Code { get; set; }
        public BaseModel Model { get; set; }
    }

    public enum MessageStatusCode {
        OK = 1,
        NotFound = 2,
        Removed = 3,
        Modified = 4,
        NotExist = 5,
        NullValue = 6,
        Error
    }
}