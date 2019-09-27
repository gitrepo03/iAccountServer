using iHotel.Entity.Admin;
using System;
using System.Collections.Generic;
using System.Text;

namespace iHotel.Entity.Common
{
    public class ChangeLog
    {
        public int Id { get; set; }
        public int Organization { get; set; }
        public string TableName { get; set; }
        public string ColumnName { get; set; }
        public int RowId { get; set; }
        public DateTime? LogDateAD { get; set; }
        public string LogDateBS { get; set; }
        public TimeSpan? LogTime { get; set; }
        public string OldValue { get; set; }
        public string NewValue { get; set; }
        public string ChangedBy { get; set; }

        public virtual Organization OrganizationNavigation { get; set; }
    }
}
