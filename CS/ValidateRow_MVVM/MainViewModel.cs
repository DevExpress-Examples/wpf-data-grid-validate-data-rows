using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using DevExpress.Mvvm;
using DevExpress.Mvvm.DataAnnotations;
using DevExpress.Mvvm.Xpf;

namespace ValidateRow_MVVM {
    public class Task : IDataErrorInfo {
        public string TaskName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        string IDataErrorInfo.Error => StartDate > EndDate ? "Either Start Date or End Date should be corrected." : null;

        string IDataErrorInfo.this[string columnName] {
            get {
                switch(columnName) {
                    case nameof(StartDate):
                        if(StartDate > EndDate)
                            return "Start Date must be less than End Date";
                        break;
                    case nameof(EndDate):
                        if(StartDate > EndDate)
                            return "End Date must be greater than Start Date";
                        break;
                    case nameof(TaskName):
                        if(string.IsNullOrEmpty(TaskName) || string.IsNullOrWhiteSpace(TaskName))
                            return "Enter a task name";
                        break;
                }
                return null;
            }
        }
    }

    public class MainViewModel : ViewModelBase {
        public ObservableCollection<Task> TaskList { get; }
        public MainViewModel() {
            TaskList = new ObservableCollection<Task>(GetData());
        }
        static IEnumerable<Task> GetData() {
            yield return new Task() {
                TaskName = "Complete Project A",
                StartDate = new DateTime(2009, 7, 17), EndDate = new DateTime(2009, 7, 10)
            };
            yield return new Task() {
                TaskName = "Test Website",
                StartDate = new DateTime(2009, 7, 10), EndDate = new DateTime(2009, 7, 12)
            };
            yield return new Task() {
                TaskName = "",
                StartDate = new DateTime(2009, 7, 4), EndDate = new DateTime(2009, 7, 6)
            };
        }

        [Command]
        public void ValidateRow(RowValidationArgs args) {
            args.Result = GetValidationErrorInfo((Task)args.Item);
        }
        static ValidationErrorInfo GetValidationErrorInfo(Task task) {
            if(task.StartDate > task.EndDate)
                return new ValidationErrorInfo("Start Date must be less than End Date");
            if(string.IsNullOrEmpty(task.TaskName) || string.IsNullOrWhiteSpace(task.TaskName))
                return new ValidationErrorInfo("Enter a task name");
            return null;
        }

        [Command]
        public void InvalidRow(InvalidRowExceptionArgs args) {
            args.ExceptionMode = ExceptionMode.NoAction;
        }
    }
}
