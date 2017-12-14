using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalApp.DataAccess.DataAccess.Implementation
{
    public class TypeOperationRepository:IRepository<TypeOperationEntity>
    {
        public TypeOperationRepository()
        {
            medicalEntity = MedicalEntities.GetInstance();
        }

        private readonly MedicalEntities medicalEntity;

        public void Create(TypeOperationEntity item)
        {
            if (item == null)
            {
                return;
            }

            medicalEntity.TypeOperationEntities.Add(item);
        }

        public void Delete(TypeOperationEntity item)
        {
            if (item == null)
            {
                return;
            }

            medicalEntity.TypeOperationEntities.Remove(item);
        }

        public TypeOperationEntity GetItemById(int id)
        {
            if (medicalEntity != null && medicalEntity.TypeOperationEntities.Any())
            {
                return medicalEntity.TypeOperationEntities.FirstOrDefault(x => x.Id == id);
            }
            else
            {
                return null;
            }
        }

        public IEnumerable<TypeOperationEntity> GetList()
        {
            if (medicalEntity != null)
            {
                return medicalEntity.TypeOperationEntities;
            }
            else
            {
                return null;
            }
        }

        public void Update(TypeOperationEntity item)
        {
            if (item == null)
            {
                return;
            }

            if (medicalEntity != null)
            {
                medicalEntity.TypeOperationEntities.Remove(item);
                medicalEntity.TypeOperationEntities.Add(item);
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
