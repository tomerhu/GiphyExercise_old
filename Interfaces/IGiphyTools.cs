using GiphyWebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GiphyWebApi.Interfaces
{
    public interface IGiphyTools
    {
        Task<GifResult> GifFetch(string searchTerm);
    }
}
