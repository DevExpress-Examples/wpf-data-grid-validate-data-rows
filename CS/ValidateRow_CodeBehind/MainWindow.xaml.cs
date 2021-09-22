using DevExpress.Xpf.Grid;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows;

namespace ValidateRow_CodeBehind {
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
                        if(string.IsNullOrEmpty(TaskName))
                            return "Enter a task name";
                        break;
                }
                return null;
            }
        }
    }
    public partial class MainWindow : Window {
        public MainWindow() {
            InitializeComponent();
            grid.ItemsSource = new List<Task> {
                new Task() {
                    TaskName = "Complete Project A",
                    StartDate = new DateTime(2009, 7, 17),
                    EndDate = new DateTime(2009, 7, 10)
                },
                new Task() {
                    TaskName = "Test Website",
                    StartDate = new DateTime(2009, 7, 10),
                    EndDate = new DateTime(2009, 7, 12)
                },
                new Task() {
                    TaskName = string.Empty,
                    StartDate = new DateTime(2009, 7, 4),
                    EndDate = new DateTime(2009, 7, 6)
                }
            };
        }

        void OnValidateRow(object sender, GridRowValidationEventArgs e) {
            var task = (Task)e.Row;
            if(task.StartDate > task.EndDate)
                e.SetError("Start Date must be less than End Date");
            if(string.IsNullOrEmpty(task.TaskName))
                e.SetError("Enter a task name");
        }

        void OnInvalidRowException(object sender, InvalidRowExceptionEventArgs e) {
            e.ExceptionMode = ExceptionMode.NoAction;
        }
    }
}
