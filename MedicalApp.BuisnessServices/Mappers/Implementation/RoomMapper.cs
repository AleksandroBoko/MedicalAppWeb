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
        public void MapFromEntity(RoomEntity item, Room targetItem)
        {
            if (item != null && targetItem != null)
            {
                targetItem.Id = item.Id;
                targetItem.Number = item.Number;
            }
        }

        public void MapToEntity(Room item, RoomEntity targetItem)
        {
            if (item != null && targetItem != null)
            {
                targetItem.Id = item.Id;
                targetItem.Number = item.Number;
            }
        }
    }
}
