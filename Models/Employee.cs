namespace WebApplication57.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }


        public int ManagerId { get; set; }
        public Manager Manager { get; set; }

    }
}
