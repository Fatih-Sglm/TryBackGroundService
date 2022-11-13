namespace TryBackGroundService.Entities
{
    public class Department
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<Person> Persons { get; set; }
    }
}
