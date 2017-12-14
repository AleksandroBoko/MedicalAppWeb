using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalApp.DataAccess.DataAccess.Implementation
{
    public class PatientRepository:IRepository<PatientEntity>
    {
        public PatientRepository()
        {
            medicalEntity = MedicalEntities.GetInstance();
        }

        private readonly MedicalEntities medicalEntity;

        public void Create(PatientEntity item)
        {
            if (item == null)
            {
                return;
            }

            medicalEntity.PatientEntities.Add(item);
        }

        public void Delete(PatientEntity item)
        {
            if (item == null)
            {
                return;
            }

            medicalEntity.PatientEntities.Remove(item);
        }

        public PatientEntity GetItemById(int id)
        {
            if (medicalEntity != null && medicalEntity.PatientEntities.Any())
            {
                return medicalEntity.PatientEntities.FirstOrDefault(x => x.Id == id);
            }
            else
            {
                return null;
            }
        }

        public IEnumerable<PatientEntity> GetList()
        {
            if (medicalEntity != null)
            {
                return medicalEntity.PatientEntities;
            }
            else
            {
                return null;
            }
        }

        public void Update(PatientEntity item)
        {
            if (item == null)
            {
                return;
            }

            if (medicalEntity != null)
            {
                medicalEntity.PatientEntities.Remove(item);
                medicalEntity.PatientEntities.Add(item);
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
