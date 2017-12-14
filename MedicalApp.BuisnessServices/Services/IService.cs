using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalApp.BuisnessServices.Services
{
    public interface IService<T>
    {
        void Add(T item);
        void Remove(T item);
        IList<T> GetAll();
        T GetItemById(int id);
        void Save();
    }
}
