using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace getbiz_custom_app.Models
{
    public class Response
    {
        public string Message { get; set; }
        public bool Status { get; set; }
        public object Data { get; set; }
    }

    public class Response2
    {
        public string Message { get; set; }
        public bool Status { get; set; }
        public object FilterData { get; set; }
    }

    public class ParentData
    {
        public string Category_Name { get; set; }
        public object filterData { get; set; }
    }

    public class FilterData
    {
        public object Data { get; set; }
    }
}
