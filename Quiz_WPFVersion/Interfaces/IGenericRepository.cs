using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz_WPFVersion.Interfaces
{
    public interface IGenericRepository<T>
    {
        //Create
        bool AddData(T data);

        //Read
        T GetData(int dataId);
        IList<T> GetDataList();

        //Update
        bool UpdateData(T data);

        //Delete
        bool DeleteData(T data);
    }
}
