namespace WebApplication57.Models
{
    public class CategoryNew
    {
        public int Id { get; set; }

        public string Category { get; set; }

        public ICollection<SupplyNew> Supplies { get; set; }

    }
}
