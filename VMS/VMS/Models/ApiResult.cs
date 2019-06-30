using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VMS.Models
{
    public class ApiResult<T>
    {
        public bool IsValid { get; set; }
        public T ReturnValue { get; set; }
        public string ErrorMessage { get; set; }
    }
}
