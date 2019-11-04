namespace TestMasGlobal.Entities
{
    using System.Collections.Generic;
    public class Role
    {
        public Role(int id, string name, string description)
        {
            this.Id = id;
            this.Name = name;
            this.Description = description;
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public List<EmployeeDTO> Employees { get; set; }
    }
}
