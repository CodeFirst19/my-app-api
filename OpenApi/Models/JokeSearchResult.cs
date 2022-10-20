using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OpenApi.Models
{
    public class JokeSearchResult
    {
        public int Total { get; set; }
        public ICollection<Joke> Result { get; set; }
    }
}
