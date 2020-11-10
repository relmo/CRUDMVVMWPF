using CRUDMVVMWPF.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUDMVVMWPF.ViewModels
{
    public class MainViewModel :BaseViewModel
    {
        #region Collection
        private ObservableCollection<Student> _students;
        public ObservableCollection<Student> Students
        {
            get { return _students; }
            set { _students = value; OnPropertyChanged(nameof(Students)); }
        }

        #endregion

        public MainViewModel()
        {
            Students = new ObservableCollection<Student>(GetDataStudent());
        }

        public List<Student> GetDataStudent()
        {
            List<Student> studentList = new List<Student>();
            for (int i = 0; i < 10; i++)
            {
                studentList.Add(new Student {
                    Id = Guid.NewGuid().ToString(),
                    LastName = "Teacher Tree",
                    FullName = "Susan Smith",
                    BirthDay = DateTime.Now.Year.ToString()
                });
            }
            return studentList;
        }
    }
}
