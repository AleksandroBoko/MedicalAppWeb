using MedicalApp.DataAccess;
using MedicalApp.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalApp.BuisnessServices.Mappers.Implementation
{
    class RoomMapper : IMapper<Room, RoomEntity>
    {
        public void MapFromEntity(RoomEntity roomEntity, Room room)
        {
            if (roomEntity != null && room != null)
            {
                room.Id = roomEntity.Id;
                room.Number = roomEntity.Number;
            }
        }

        public void MapToEntity(Room room, RoomEntity roomEntity)
        {
            if (room != null && roomEntity != null)
            {
                roomEntity.Id = room.Id;
                roomEntity.Number = room.Number;
            }
        }
    }
}
