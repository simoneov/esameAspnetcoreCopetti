namespace TestWeb.Entities;

public class EmployeeEntity
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }

    public List<VacationEntity> Vacations { get; set; }
}
