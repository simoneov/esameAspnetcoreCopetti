namespace TestWeb.Entities;

public class VacationEntity
{
    public int Id { get; set; }

    public DateTime Start { get; set; }
    public DateTime End { get; set; }
    
    public int EmployeeId { get; set; }
    public EmployeeEntity Employee { get; set; }
}
