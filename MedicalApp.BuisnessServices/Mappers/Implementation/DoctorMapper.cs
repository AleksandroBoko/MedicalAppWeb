using MedicalApp.DataAccess;
using MedicalApp.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace MedicalApp.BuisnessServices.Mappers.Implementation
{
    public class DoctorMapper : IMapper<Doctor, DoctorEntity>
    {
        public void MapToEntity(Doctor item, DoctorEntity targetItem)
        {            
            if (item != null && targetItem != null)
            {
                targetItem.Id = item.Id;
                targetItem.FirstName = item.FirstName;
                targetItem.LastName = item.LastName;
                targetItem.Qualification = item.Qualification;
            }
        }

        public void MapFromEntity(DoctorEntity item, Doctor targetItem)
        {
            if (item != null && targetItem != null)
            {
                targetItem.Id = item.Id;
                targetItem.FirstName = item.FirstName;
                targetItem.LastName = item.LastName;
                targetItem.Qualification = item.Qualification;
            }
        }
    }
}
