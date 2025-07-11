using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YoutubeApi.Application.Exceptions;

public class ExceptionModel : ErrorStatuseCode
{
    public IEnumerable<string> Errors { get; set; }
    public override string ToString()
    {
        return JsonConvert.SerializeObject(this);
    }
}

public class ErrorStatuseCode 
{
    public int StatusCode { get; set; }
}
