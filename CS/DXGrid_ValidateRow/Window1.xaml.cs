using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data;
using DevExpress.Xpf.Grid;
using DevExpress.XtraEditors.DXErrorProvider;

namespace DXGrid_ValidateRow {
    public partial class Window1 : Window {
        public Window1() {
            InitializeComponent();
            grid.DataSource = TaskList.GetData();
        }

        private void TableView_ValidateRow(object sender, GridRowValidationEventArgs e) {
            DateTime startDate = ((Task)e.Row).StartDate;
            DateTime endDate = ((Task)e.Row).EndDate;
            e.IsValid = startDate < endDate;
        }

        private void TableView_InvalidRowException(object sender, InvalidRowExceptionEventArgs e) {
            e.ExceptionMode = ExceptionMode.NoAction;
        }
    }

    public class TaskList {
        public static List<Task> GetData() {
            List<Task> data = new List<Task>();
            data.Add(new Task() { TaskName = "Complete Project A",
                StartDate = new DateTime(2009, 7, 17), EndDate = new DateTime(2009, 7, 10) });
            data.Add(new Task() { TaskName = "Test Website",
                StartDate = new DateTime(2009, 7, 10), EndDate = new DateTime(2009, 7, 12) });
            data.Add(new Task() { TaskName = "Publish Docs",
                StartDate = new DateTime(2009, 7, 4), EndDate = new DateTime(2009, 7, 6) });
            return data;
        }
    }

    public class Task : IDXDataErrorInfo {
        public string TaskName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        void IDXDataErrorInfo.GetError(ErrorInfo info) {
            if (StartDate > EndDate) {
                SetErrorInfo(info,
                    "Either StartDate or EndDate should be corrected.",
                    ErrorType.Critical);
            }
        }
        void IDXDataErrorInfo.GetPropertyError(string propertyName, ErrorInfo info) {
            switch (propertyName) {
                case "StartDate":
                    if (StartDate > EndDate)
                        SetErrorInfo(info,
                            "StartDate must be less than EndDate",
                            ErrorType.Critical);
                    break;
                case "EndDate":
                    if (StartDate > EndDate)
                        SetErrorInfo(info,
                            "EndDate must be greater than StartDate",
                            ErrorType.Critical);
                    break;
                case "TaskName":
                    if (IsStringEmpty(TaskName))
                        SetErrorInfo(info,
                            "Task name hasn't been entered",
                            ErrorType.Information);
                    break;
            }
        }
        void SetErrorInfo(ErrorInfo info, string errorText, ErrorType errorType) {
            info.ErrorText = errorText;
            info.ErrorType = errorType;
        }
        bool IsStringEmpty(string str) {
            return (str != null && str.Trim().Length == 0);
        }
    }
}
