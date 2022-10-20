using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OpenApi.Models
{
    public class Joke
    {
        public string Id { get; set; }
        public ICollection<string> Categories { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public string IconUrl { get; set; }
        public string Url { get; set; }
        public string Value { get; set; }
    }
}
