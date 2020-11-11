using CRUDMVVMWPF.BaseCommand;
using CRUDMVVMWPF.Models;
using CRUDMVVMWPF.UserControls;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Input;

namespace CRUDMVVMWPF.ViewModels
{
    public class MainViewModel :BaseViewModel
    {
        #region [Variable]
        private string _id;
        private string _lastName;
        private string _fullName;
        private string _birthDay;
        private string _image;
        private string _imageAddStudent;
        private bool _isShowDialog;
        private object _dialogUc;

        public string Id
        {
            get { return _id; }
            set { _id = value; OnPropertyChanged(nameof(Id)); }
        }
        public string LastName
        {
            get { return _lastName; }
            set { _lastName = value; OnPropertyChanged(nameof(LastName)); }
        }
        public string FullName
        {
            get { return _fullName; }
            set { _fullName = value; OnPropertyChanged(nameof(FullName)); }
        }
        public string BirthDay
        {
            get { return _birthDay; }
            set { _birthDay = value; OnPropertyChanged(nameof(BirthDay)); }
        }
        public string Image { get { return _image; } set { _image = value; OnPropertyChanged(nameof(Image)); } }
        public string ImageAddStudent { get { return _imageAddStudent; } set { _imageAddStudent = value; OnPropertyChanged(nameof(ImageAddStudent)); } }
        public bool IsShowDialog
        {
            get { return _isShowDialog; }
            set { _isShowDialog = value; OnPropertyChanged("IsShowDialog"); }
        }
        public object DialogUc
        {
            get { return _dialogUc; }
            set { _dialogUc = value; OnPropertyChanged("DialogUc"); }
        }

        #endregion

        #region Collection
        private ObservableCollection<Student> _students;
        public ObservableCollection<Student> Students
        {
            get { return _students; }
            set { _students = value; OnPropertyChanged(nameof(Students)); }
        }

        #endregion

        #region [Command]
        public ICommand ShowDialogAddStudentCMD { get; set; }
        public ICommand CancelAddStudentCMD { get; set; }
        public ICommand OpenDialogFileCMD { get; set; }
        public ICommand SaveStudentCMD { get; set; }
        public ICommand DeleteStudentCMD { get; set; }

        #endregion
        public MainViewModel()
        {
            Students = new ObservableCollection<Student>(GetDataStudent());
            ShowDialogAddStudentCMD = new RelayCommand(ShowDialogAddStudent);
            CancelAddStudentCMD = new RelayCommand(CancelAddStudent);
            OpenDialogFileCMD = new RelayCommand(OpenDialogFile);
            SaveStudentCMD = new RelayCommand(SaveStudent);
            DeleteStudentCMD = new RelayCommand(DeleteStudent);
        }
        public void DeleteStudent()
        {
            if (SelectedStudent != null)
            {
                Students.Remove(SelectedStudent);
                LastName = string.Empty;
                FullName = string.Empty;
                BirthDay = string.Empty;
                Image = string.Empty;
            }
        }
        public void SaveStudent()
        {
            if (!string.IsNullOrWhiteSpace(LastName) && !string.IsNullOrWhiteSpace(FullName) && !string.IsNullOrWhiteSpace(BirthDay))
            {
                Student student = new Student
                {
                    LastName = LastName,
                    FullName = FullName,
                    BirthDay = BirthDay,
                    Image = ImageAddStudent
                };
                Students.Add(student);
                //Students.Add(
                //    new Student { 
                //        LastName = LastName,
                //        FullName = FullName,
                //        BirthDay = BirthDay,
                //        Image = ImageAddStudent
                //    });
                LastName = string.Empty;
                FullName = string.Empty;
                BirthDay = string.Empty;
                ImageAddStudent = string.Empty;
                IsShowDialog = false;
            }
        }
        public void OpenDialogFile()
        {
            OpenFileDialog openFile = new OpenFileDialog();
            if (openFile.ShowDialog() == DialogResult.OK)
            {
                ImageAddStudent = openFile.FileName;
            }
        }

        public void CancelAddStudent()
        {
            IsShowDialog = false;
        }
        public void ShowDialogAddStudent()
        {
            IsShowDialog = true;
            DialogUc = new AddStudentUC();

        }
        
        public List<Student> GetDataStudent()
        {
            List<Student> studentList = new List<Student>();
            for (int i = 0; i < 10; i++)
            {
                studentList.Add(new Student {
                    Id = (i +1).ToString(),
                    LastName = "Teacher Tree " + i,
                    FullName = "Susan Smith",
                    BirthDay = DateTime.Now.Year.ToString()
                });
            }
            return studentList;
        }

        private Student _selectedStudent;

        public Student SelectedStudent
        {
            get { return _selectedStudent; }
            set 
            {
                _selectedStudent = value;
                OnPropertyChanged(nameof(SelectedStudent));
                if (_selectedStudent != null)
                {
                    LastName = _selectedStudent.LastName;
                    FullName = _selectedStudent.FullName;
                    BirthDay = _selectedStudent.BirthDay;
                    Image = _selectedStudent.Image;
                }
            }
        }

    }
}
