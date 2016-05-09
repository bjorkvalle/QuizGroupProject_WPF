using System.Collections.Generic;

namespace Quiz_StudentApp.Interfaces
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
