using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MedicalApp.Domain.Models;
using MedicalApp.DataAccess.DataAccess.Implementation;
using MedicalApp.BuisnessServices.Mappers.Implementation;
using MedicalApp.DataAccess;
using MedicalApp.DataAccess.DataAccess;
using MedicalApp.BuisnessServices.Mappers;

namespace MedicalApp.BuisnessServices.Services.Implementation
{
    public class PatientService : IPatientService
    {
        public PatientService()
        {
            repository = PatientRepository.GetInstance();
            mapper = new PatientMapper();
        }

        private readonly IRepository<PatientEntity> repository;
        private readonly IMapper<Patient, PatientEntity> mapper;

        public void Add(Patient item)
        {
            PatientEntity entity = new PatientEntity();
            mapper.MapToEntity(item, entity);
            repository.Create(entity);
        }

        public IList<Patient> GetAll()
        {
            var entities = repository.GetList();
            var patients = new List<Patient>();

            if(entities.Any())
            {
                foreach(var entity in entities)
                {
                    Patient patient = new Patient();
                    mapper.MapFromEntity(entity, patient);
                    patients.Add(patient);
                }
            }

            return patients;
        }

        public Patient GetItemById(int id)
        {
            var entity = repository.GetItemById(id);
            if (entity != null)
            {
                Patient patient = new Patient();
                mapper.MapFromEntity(entity, patient);
                return patient;
            }
            else
            {
                return null;
            }
        }

        public void Remove(Patient item)
        {
            PatientEntity entity = new PatientEntity();
            mapper.MapToEntity(item, entity);
            repository.Delete(entity);
        }

        public void Save()
        {
            repository.Save();
        }
    }
}
