namespace NetMasteryLab.Concepts.IEnumerableVsIQueryable.Examples;

/// <summary>
/// Modelo de ejemplo para demostrar IEnumerable vs IQueryable
/// </summary>
public class Employee
{
    public int EmpID { get; set; }
    public string EmpName { get; set; } = string.Empty;
    public decimal Salary { get; set; }
    public int Age { get; set; }
    public string Department { get; set; } = string.Empty;
}

