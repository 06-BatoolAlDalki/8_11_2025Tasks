namespace WebApplication57.Models
{
    public class SupplyNew
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }


        public int CategoryNewId { get; set; } 
        public CategoryNew CategoryNew { get; set; }
    }
}
