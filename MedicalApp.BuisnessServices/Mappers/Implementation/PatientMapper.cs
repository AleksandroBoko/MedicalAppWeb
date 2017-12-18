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

        public void MapFromEntity(PatientEntity item, Patient targetItem)
        {
            if (item != null && targetItem != null)
            {
                targetItem.Id = item.Id;
                targetItem.FirstName = item.FirstName;
                targetItem.LastName = item.LastName;
                targetItem.Age = item.Age;
                if (item.Room != null)
                {
                    targetItem.CurrentRoom = targetItem.CurrentRoom ?? new Room();
                    roomMapper.MapFromEntity(item.Room, targetItem.CurrentRoom);
                }
            }
        }
    }
}
