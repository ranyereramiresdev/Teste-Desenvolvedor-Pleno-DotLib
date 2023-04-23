using System;

namespace TodoApi.Models
{
    public class ActivityModel
    {
        public int id { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public bool priority { get; set; }
        public bool status { get; set; }
        public DateTime dataStart { get; set; }
        public DateTime? dataEnd { get; set; }
    }
}
