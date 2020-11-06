using System;

namespace Utils
{
    public class Project
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public DateTime CreationDate { get; set; }
        
        // TODO: Enable in second exercise...
        // public Uri? Uri { get; set; }
    }
}