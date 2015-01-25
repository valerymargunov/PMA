using PMA.Helpers.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMA.Helpers
{
    public class ResultStatus
    {
        public int Created { get; set; }
        public int Updated { get; set; }
        public int Removed { get; set; }
        public string Message { get; set; }
        public StatusOperation Status { get; set; }
    }
}
