using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalApp.DataAccess.DataAccess.Implementation
{
    public class OperationRepository:IRepository<OperationEntity>
    {
        public OperationRepository()
        {
            medicalEntity = MedicalEntities.GetInstance();
        }

        private readonly MedicalEntities medicalEntity;

        public void Create(OperationEntity item)
        {
            if (item == null)
            {
                return;
            }

            medicalEntity.OperationEntities.Add(item);
        }

        public void Delete(OperationEntity item)
        {
            if (item == null)
            {
                return;
            }

            medicalEntity.OperationEntities.Remove(item);
        }

        public OperationEntity GetItemById(int id)
        {
            if (medicalEntity != null && medicalEntity.OperationEntities.Any())
            {
                return medicalEntity.OperationEntities.FirstOrDefault(x => x.Id == id);
            }
            else
            {
                return null;
            }
        }

        public IEnumerable<OperationEntity> GetList()
        {
            if (medicalEntity != null)
            {
                return medicalEntity.OperationEntities;
            }
            else
            {
                return null;
            }
        }

        public void Update(OperationEntity item)
        {
            if (item == null)
            {
                return;
            }

            if (medicalEntity != null)
            {
                medicalEntity.OperationEntities.Remove(item);
                medicalEntity.OperationEntities.Add(item);
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
