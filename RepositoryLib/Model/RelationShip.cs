namespace DemoProject.Data.model
{
    public class RelationShip
    {
        public int PatId { get; set; }
        public int DocId { get; set; }
        public Patient patient { get; set; }
        public Doctor doctor { get; set; }
    }
}
