using MedicalApp.Domain.Models;
using MedicalApp.DataAccess.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MedicalApp.DataAccess.DataAccess.Implementation;
using MedicalApp.DataAccess;
using MedicalApp.BuisnessServices.Mappers;
using MedicalApp.BuisnessServices.Mappers.Implementation;

namespace MedicalApp.BuisnessServices.Services.Implementation
{
    public class DoctorService : IDoctorService
    {
        public DoctorService()
        {
            repository = DoctorRepository.GetInstance();
            doctorMapper = new DoctorMapper();
        }

        private readonly IRepository<DoctorEntity> repository;
        private readonly IMapper<Doctor, DoctorEntity> doctorMapper;

        public void Add(Doctor item)
        {
            DoctorEntity entity = new DoctorEntity();
            doctorMapper.MapToEntity(item, entity);
            repository.Create(entity);            
        }

        public IList<Doctor> GetAll()
        {
            var entities = repository.GetList();
            if(entities.Any())
            {
                var doctors = new List<Doctor>();
                foreach(var entity in entities)
                {
                    Doctor doctor = new Doctor();
                    doctorMapper.MapFromEntity(entity, doctor);
                    doctors.Add(doctor);
                }

                return doctors; 
            }
            else
            {
                return null;
            }
        }

        public Doctor GetItemById(int id)
        {
            var entity = repository.GetItemById(id);
            if(entity != null)
            {
                Doctor doc = new Doctor();
                doctorMapper.MapFromEntity(entity, doc);
                return doc;
            }
            else
            {
                return null;
            }
        }

        public void Remove(Doctor item)
        {
            DoctorEntity entity = new DoctorEntity();
            doctorMapper.MapToEntity(item, entity);
            repository.Delete(entity);
        }

        public void Save()
        {
            repository.Save();
        }
    }
}
