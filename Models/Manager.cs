namespace WebApplication57.Models
{
    public class Manager
    {

        public int Id { get; set; }
        public string Name { get; set; }


        public ICollection<Employee> employees { get; set; }
    }
}
