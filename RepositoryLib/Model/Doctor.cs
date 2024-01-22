using System.ComponentModel.DataAnnotations;

namespace DemoProject.Data.model
{
    public class Doctor
    {
        [Key]
        public int DocId { get; set; }
        public string Name { get; set; }
        public DateTime Appointment { get; set; }

        // Navigation property for the many-to-many relationship
        public List<RelationShip> Relationships { get; set; }
    }
}
