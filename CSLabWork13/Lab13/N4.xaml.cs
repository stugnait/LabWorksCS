using System.Windows;

namespace Lab13;

public partial class N4 : Window
{
    public N4()
    {
        InitializeComponent();
    }

    public (string employee, double salary_vacation) get_salary(string employee, (int, int, int, int, int, int) salary_monthly,int bonus)
    {
        double salary = (salary_monthly.Item1 + salary_monthly.Item2 + salary_monthly.Item3 + salary_monthly.Item4 +
                         salary_monthly.Item5 + salary_monthly.Item6);

        salary = salary * 0.85 + 0.95 * bonus;
        
        return (employee, salary);
    }
}