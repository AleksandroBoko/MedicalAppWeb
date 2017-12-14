using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalApp.DataAccess.DataAccess.Implementation
{
    public class RoomRepository:IRepository<RoomEntity>
    {
        public RoomRepository()
        {
            medicalEntity = MedicalEntities.GetInstance();
        }

        private readonly MedicalEntities medicalEntity;

        public void Create(RoomEntity item)
        {
            if (item == null)
            {
                return;
            }

            medicalEntity.RoomEntities.Add(item);
        }

        public void Delete(RoomEntity item)
        {
            if (item == null)
            {
                return;
            }

            medicalEntity.RoomEntities.Remove(item);
        }

        public RoomEntity GetItemById(int id)
        {
            if (medicalEntity != null && medicalEntity.RoomEntities.Any())
            {
                return medicalEntity.RoomEntities.FirstOrDefault(x => x.Id == id);
            }
            else
            {
                return null;
            }
        }

        public IEnumerable<RoomEntity> GetList()
        {
            if (medicalEntity != null)
            {
                return medicalEntity.RoomEntities;
            }
            else
            {
                return null;
            }
        }

        public void Update(RoomEntity item)
        {
            if (item == null)
            {
                return;
            }

            if (medicalEntity != null)
            {
                medicalEntity.RoomEntities.Remove(item);
                medicalEntity.RoomEntities.Add(item);
            }
        }

        public void Save()
        {
            if (medicalEntity != null)
            {
                medicalEntity.SaveChanges();
            }
        }

    }
}
