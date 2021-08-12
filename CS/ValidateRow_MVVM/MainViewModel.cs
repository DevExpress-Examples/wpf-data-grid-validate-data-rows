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

        string IDataErrorInfo.Error => StartDate > EndDate ? "Either StartDate or EndDate should be corrected." : null;

        string IDataErrorInfo.this[string columnName] {
            get {
                switch(columnName) {
                    case nameof(StartDate):
                        if(StartDate > EndDate)
                            return "StartDate must be less than EndDate";
                        break;
                    case nameof(EndDate):
                        if(StartDate > EndDate)
                            return "EndDate must be greater than StartDate";
                        break;
                    case nameof(TaskName):
                        if(string.IsNullOrEmpty(TaskName) || string.IsNullOrWhiteSpace(TaskName))
                            return "Task name hasn't been entered";
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
                return new ValidationErrorInfo("StartDate must be less than EndDate");
            if(string.IsNullOrEmpty(task.TaskName) || string.IsNullOrWhiteSpace(task.TaskName))
                return new ValidationErrorInfo("Task name hasn't been entered");
            return null;
        }

        [Command]
        public void InvalidRow(InvalidRowExceptionArgs args) {
            args.ExceptionMode = ExceptionMode.NoAction;
        }
    }
}
