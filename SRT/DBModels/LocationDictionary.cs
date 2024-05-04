using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;

namespace SRT.DBModels
{
    public class LocationDictionary
    {
      
        public int Id { get; set; }
        public string Name { get; set; } =string.Empty;
        public string? LocationIframe { get; set; }
        public string? LocationLinq { get; set; }
    }
}
