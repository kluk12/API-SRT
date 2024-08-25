using SRT.DBModels;

namespace SRT.Models
{
    public class GroupedActivity
    {
        public string Time { get; set; }
        public List<Training> Activities { get; set; }
    }
}
