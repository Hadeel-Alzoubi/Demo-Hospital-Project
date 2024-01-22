using System.ComponentModel.DataAnnotations;

namespace DemoProject.ModelDTO
{
    // To Fix Json Cycle Prplem (M:N)
    public class PatientDTO
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime? Appointament { get; set; }
        

    }
}
