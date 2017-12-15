using MedicalApp.BuisnessServices.Mappers;
using MedicalApp.BuisnessServices.Mappers.Implementation;
using MedicalApp.DataAccess;
using MedicalApp.DataAccess.DataAccess;
using MedicalApp.DataAccess.DataAccess.Implementation;
using MedicalApp.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalApp.BuisnessServices.Services.Implementation
{
    public class RoomService:IRoomService
    {
        public RoomService()
        {
            repository = RoomRepository.GetInstance();
            mapper = new RoomMapper();
        }

        private readonly IRepository<RoomEntity> repository;
        private readonly IMapper<Room, RoomEntity> mapper;

        public void Add(Room item)
        {
            var entity = new RoomEntity();
            mapper.MapToEntity(item, entity);
            repository.Create(entity);
        }

        public IList<Room> GetAll()
        {
            var entities = repository.GetList();
            if (entities.Any())
            {
                var rooms = new List<Room>();
                foreach (var entity in entities)
                {
                    var room = new Room();
                    mapper.MapFromEntity(entity, room);
                    rooms.Add(room);
                }

                return rooms;
            }
            else
            {
                return null;
            }
        }

        public Room GetItemById(int id)
        {
            var entity = repository.GetItemById(id);
            if (entity != null)
            {
                var room = new Room();
                mapper.MapFromEntity(entity, room);
                return room;
            }
            else
            {
                return null;
            }
        }

        public void Remove(Room item)
        {
            var entity = new RoomEntity();
            mapper.MapToEntity(item, entity);
            repository.Delete(entity);
        }

        public void Save()
        {
            repository.Save();
        }
    }
}
