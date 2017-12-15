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

        public void MapToEntity(Patient item, PatientEntity targetItem)
        {
            if (item != null && targetItem != null)
            {
                targetItem.Id = item.Id;
                targetItem.FirstName = item.FirstName;
                targetItem.LastName = item.LastName;
                targetItem.Age = item.Age;
                if(item.Room != null)
                {
                    targetItem.RoomId = item.Room.Id;
                }                
                roomMapper.MapToEntity(item.Room, targetItem.Room);
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
                //targetItem.RoomId = item.RoomId;
                if (item.Room != null)
                {
                    if(targetItem.Room == null)
                    {
                        targetItem.Room = new Room();
                    }
                    roomMapper.MapFromEntity(item.Room, targetItem.Room);
                }
            }
        }
    }
}
