using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BlogTracker.Models
{
    public class EmployeeModel
    {
        public string EmailId { get; set; }
        public string Name { get; set; }
        public DateTime DateOfJoining { get; set; }
        public int Passcode { get; set; }
    }
}