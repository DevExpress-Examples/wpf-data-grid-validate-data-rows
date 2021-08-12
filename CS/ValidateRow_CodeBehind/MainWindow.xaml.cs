using DevExpress.Xpf.Grid;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows;

namespace ValidateRow_CodeBehind {
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
    public partial class MainWindow : Window {
        public MainWindow() {
            InitializeComponent();
            grid.ItemsSource = GetData().ToList();
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

        void OnValidateRow(object sender, GridRowValidationEventArgs e) {
            var task = (Task)e.Row;
            if(task.StartDate > task.EndDate)
                e.SetError("StartDate must be less than EndDate");
            if(string.IsNullOrEmpty(task.TaskName) || string.IsNullOrWhiteSpace(task.TaskName))
                e.SetError("Task name hasn't been entered");
        }

        void OnInvalidRowException(object sender, InvalidRowExceptionEventArgs e) {
            e.ExceptionMode = ExceptionMode.NoAction;
        }
    }
}
