using GiphyWebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GiphyWebApi.Interfaces
{
    internal interface IWebTools
    {
        Task<WebResult> GetData(Uri uri);
    }
}
