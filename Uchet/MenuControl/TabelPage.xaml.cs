using System;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Data.Entity.SqlServer;
using System.Data.SqlClient;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using Uchet.DataFiles;

namespace Uchet.MenuControl
{
    public partial class TabelPage : Page
    {
        public TabelPage()
        {
            InitializeComponent();

            GridTabel.ItemsSource = OdbConnectHelper.odbEnt.WorkSchedule.ToList();

            Loaded += TabelPage_Loaded;
        }
        private void TabelPage_Loaded(object sender, RoutedEventArgs e)
        {
            CalculateSalary();
        }
        private void CalculateSalary()
        {
            int currentMonth = DateTime.Now.Month;

            var result = from schedule in OdbConnectHelper.odbEnt.WorkSchedule
                         where schedule.StartTime.HasValue && schedule.StartTime.Value.Month == currentMonth
                         group schedule by schedule.EmployeeID into g
                         select new
                         {
                             EmployeeID = g.Key ?? 0,
                             TotalHours = g.Sum(s => SqlFunctions.DateDiff("hour", s.StartTime.Value, s.EndTime.Value)) ?? 0
                         };

            foreach (var item in result)
            {
                string lastName = GetLastName(item.EmployeeID);
                decimal hourlyRate = GetHourlyRate(item.EmployeeID);
                decimal salary = item.TotalHours * hourlyRate;

                //DateTime startTime = OdbConnectHelper.odbEnt.WorkSchedule
                //    .Where(s => s.EmployeeID == item.EmployeeID && s.StartTime.Value.Month == currentMonth)
                //    .Min(s => s.StartTime.Value);
                //DateTime endTime = OdbConnectHelper.odbEnt.WorkSchedule
                //    .Where(s => s.EmployeeID == item.EmployeeID && s.StartTime.Value.Month == currentMonth)
                //    .Max(s => s.EndTime.Value);

                txtTotal.Text = $"Фамилия: {lastName}, Получка: {salary}";
            }
        }
        private string GetLastName(int employeeID)
        {
            var employee = OdbConnectHelper.odbEnt.Employees.FirstOrDefault(e => e.EmployeeID == employeeID);
            return employee != null ? employee.LastName : "Unknown";
        }
        private decimal GetHourlyRate(int employeeID)
        {
            var hourlyRate = (from rate in OdbConnectHelper.odbEnt.HourlyRates
                              where rate.EmployeeID == employeeID
                              select rate.HourlyRate).FirstOrDefault();

            return hourlyRate ?? 0;
        }
    }
}
