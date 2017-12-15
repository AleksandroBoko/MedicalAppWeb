using MedicalApp.DataAccess;
using MedicalApp.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalApp.BuisnessServices.Mappers.Implementation
{
    class PatientMapper:IMapper<Patient, PatientEntity>
    {
        public void MapToEntity(Patient item, PatientEntity targetItem)
        {
            if (item != null && targetItem != null)
            {
                targetItem.Id = item.Id;
                targetItem.FirstName = item.FirstName;
                targetItem.LastName = item.LastName;
                targetItem.Age = item.Age;
                targetItem.RoomId = item.RoomId;
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
                targetItem.RoomId = item.RoomId;
            }
        }
    }
}
