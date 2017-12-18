using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalApp.Domain.Models
{
    public class Treatment
    {
        public int Id { get; set; }
        public int DoctorId { get; set; }
        public string DoctorFullName { get; set; }
        public int PatientId { get; set; }
        public string PatientFullName { get; set; }
        public System.DateTime StartDate { get; set; }
    }
}
