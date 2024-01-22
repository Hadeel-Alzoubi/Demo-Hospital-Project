using System.ComponentModel.DataAnnotations;

namespace DemoProject.ModelDTO
{
    // To Fix Json Cycle Prplem (M:N)
    public class DoctorDTO
    {
        [Key]
        public int ID { get; set; }
        public string Name { get; set; }
        public DateTime? appoitment { get; set; }

    }
}