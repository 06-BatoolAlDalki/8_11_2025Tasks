namespace WebApplication57.Models
{
    public class Order // table 2
    {

        // الطلب تابع  من1  مستخدم 
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }


        public int CustomerId { get; set; }
        public Customer Customer { get; set; }


    }
}
