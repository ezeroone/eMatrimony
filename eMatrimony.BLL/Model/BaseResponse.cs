using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eMatrimony.BLL.Model
{
    public class BaseResponse
    {

        public BaseResponse(bool status)
        {
            this.Status = status;
            this.Message = string.Empty;
        }

        public BaseResponse(bool status, string message)
        {
            this.Status = status;
            this.Message = message;
        }

        public bool Status { get; set; }
        public string Message { get; set; }
    }
}
