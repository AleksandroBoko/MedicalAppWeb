//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MedicalApp.DataAccess
{
    using System;
    using System.Collections.Generic;
    
    public partial class TreatmentEntity
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TreatmentEntity()
        {
            this.Operations = new HashSet<OperationEntity>();
            this.TreatmentReports = new HashSet<TreatmentReportEntity>();
        }
    
        public int Id { get; set; }
        public int DoctorId { get; set; }
        public int PatientId { get; set; }
        public System.DateTime StartDate { get; set; }
    
        public virtual DoctorEntity Doctor { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OperationEntity> Operations { get; set; }
        public virtual PatientEntity Patient { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TreatmentReportEntity> TreatmentReports { get; set; }
    }
}
