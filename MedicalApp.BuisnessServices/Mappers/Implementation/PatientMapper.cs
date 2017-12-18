using MedicalApp.DataAccess;
using MedicalApp.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalApp.BuisnessServices.Mappers.Implementation
{
    class PatientMapper : IMapper<Patient, PatientEntity>
    {
        public PatientMapper()
        {
            roomMapper = new RoomMapper();
        }

        private readonly RoomMapper roomMapper;

        public void MapToEntity(Patient patient, PatientEntity patientEntity)
        {
            if (patient != null && patientEntity != null)
            {
                patientEntity.Id = patient.Id;
                patientEntity.FirstName = patient.FirstName;
                patientEntity.LastName = patient.LastName;
                patientEntity.Age = patient.Age;
                if(patient.CurrentRoom != null)
                {
                    patientEntity.RoomId = patient.CurrentRoom.Id;
                }                
                roomMapper.MapToEntity(patient.CurrentRoom, patientEntity.Room);
            }
        }

        public void MapFromEntity(PatientEntity patientEntity, Patient patient)
        {
            if (patientEntity != null && patient != null)
            {
                patient.Id = patientEntity.Id;
                patient.FirstName = patientEntity.FirstName;
                patient.LastName = patientEntity.LastName;
                patient.Age = patientEntity.Age;
                if (patientEntity.Room != null)
                {
                    patient.CurrentRoom = patient.CurrentRoom ?? new Room();
                    roomMapper.MapFromEntity(patientEntity.Room, patient.CurrentRoom);
                }
            }
        }
    }
}
