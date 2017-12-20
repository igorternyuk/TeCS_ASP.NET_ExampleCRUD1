using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace db_contacts.Model
{
    public interface ICrud<T>
    {
        void Create(T obj);
        List<T> ReadAll();
        T ReadById(Object id);
        List<T> Search(Object filter);
        void Update(T obj);
        void Delete(Object id);

    }
}
