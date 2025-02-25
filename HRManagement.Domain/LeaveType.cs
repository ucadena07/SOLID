using HRManagement.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRManagement.Domain;

public class LeaveType : BaseEntity
{
    public string Days { get; set; }
    public int DefaultDays { get; set; }
    public string Name { get; set; }
}
