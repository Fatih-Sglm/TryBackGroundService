namespace TryBackGroundService.Entities
{
    //Person Entity si
    public class Person
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public Department Department { get; set; }

        public int DepartmentId { get; set; }
    }
}
