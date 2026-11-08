namespace WebApplication57.Models
{
    public class OfferNew
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public int SupplyNewId { get; set; }

    public SupplyNew SupplyNew { get; set; }

}
}
