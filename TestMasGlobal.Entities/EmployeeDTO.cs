namespace TestMasGlobal.Entities
{
    public class EmployeeDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ContractTypeName { get; set; }
        public Role Role { get; set; }
        public decimal Salary { get; set; }
    }
}
