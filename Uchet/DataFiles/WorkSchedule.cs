//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Uchet.DataFiles
{
    using System;
    using System.Collections.Generic;
    
    public partial class WorkSchedule
    {
        public int ScheduleID { get; set; }
        public Nullable<int> EmployeeID { get; set; }
        public Nullable<System.DateTime> StartTime { get; set; }
        public Nullable<System.DateTime> EndTime { get; set; }
        public string ShiftType { get; set; }
        public Nullable<int> FullTime { get; set; }
    
        public virtual Employees Employees { get; set; }
    }
}
