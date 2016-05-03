using Quiz_StudentApp.Models;
using Quiz_WPFVersion.Data;
using System.Collections.Generic;

namespace Quiz_StudentApp.ViewModels
{
    class HomeViewModel
    {
        public User ActiveUser { get; set; }

        public IList<T> DisplayListData<T>()
        {
            return Repository<T>.GetInstance().GetDataList() as List<T>;
        }
    }
}
