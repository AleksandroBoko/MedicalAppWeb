using MedicalApp.DataAccess;
using MedicalApp.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalApp.BuisnessServices.Mappers.Implementation
{
    class TreatmentMapper : IMapper<Treatment, TreatmentEntity>
    {
        public void MapFromEntity(TreatmentEntity treatmentEntity, Treatment treatment)
        {
            if (treatmentEntity != null && treatment != null)
            {
                treatment.Id = treatmentEntity.Id;
                treatment.DoctorId = treatmentEntity.DoctorId;
                treatment.DoctorFullName = $"{treatmentEntity.Doctor.FirstName} {treatmentEntity.Doctor.LastName}";
                treatment.PatientId = treatmentEntity.PatientId;
                treatment.PatientFullName = $"{treatmentEntity.Patient.FirstName} {treatmentEntity.Patient.LastName}";
                treatment.StartDate = treatmentEntity.StartDate;
            }
        }

        public void MapToEntity(Treatment treatment, TreatmentEntity treatmentEntity)
        {
            if (treatment != null && treatmentEntity != null)
            {
                treatmentEntity.Id = treatment.Id;
                treatmentEntity.DoctorId = treatment.DoctorId;
                treatmentEntity.PatientId = treatment.PatientId;
                treatmentEntity.StartDate = treatment.StartDate;
            }
        }
    }
}
