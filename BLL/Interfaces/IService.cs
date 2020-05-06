using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IService<TModel> where TModel: class
    {
        void Add(TModel model);
        void Remove(int id);
        void Update(TModel model);
        TModel GetById(int id);
        IEnumerable<TModel> GetAll();
    }
}
