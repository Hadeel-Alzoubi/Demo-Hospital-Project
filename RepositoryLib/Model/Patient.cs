using System.ComponentModel.DataAnnotations;

namespace DemoProject.Data.model
{
    public class Patient
    {
        [Key]
        public int PatId { get; set; }
        public string Name { get; set; }
        public DateTime? Appointment { get; set; }
        public string? FileVisit { get; set; }

        // Navigation property for the many-to-many relationship
        public List<RelationShip> Relationships { get; set; }
    }
}
