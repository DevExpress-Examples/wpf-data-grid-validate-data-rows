<!-- default badges list -->
![](https://img.shields.io/endpoint?url=https://codecentral.devexpress.com/api/v1/VersionRange/128653826/21.2.2%2B)
[![](https://img.shields.io/badge/Open_in_DevExpress_Support_Center-FF7200?style=flat-square&logo=DevExpress&logoColor=white)](https://supportcenter.devexpress.com/ticket/details/E1593)
[![](https://img.shields.io/badge/📖_How_to_use_DevExpress_Examples-e9f6fc?style=flat-square)](https://docs.devexpress.com/GeneralInformation/403183)
<!-- default badges end -->

# WPF Data Grid - How to Validate Data Rows

This example shows how to check if a user enters valid data into a row. Handle the [ValidateRow](https://docs.devexpress.com/WPF/DevExpress.Xpf.Grid.GridViewBase.ValidateRow) and [InvalidRowException](https://docs.devexpress.com/WPF/DevExpress.Xpf.Grid.GridViewBase.InvalidRowException) events to validate the focused row's data. If the data is invalid, do not allow the user to move focus to another row until the invalid values are corrected.

The **Task** class implements the [IDataErrorInfo](https://docs.microsoft.com/en-us/dotnet/api/system.componentmodel.idataerrorinfo) interface and allows you to get error descriptions for the entire row and individual cells (data source fields). Error icons appear in cells that contain invalid values. Hover the mouse pointer over an error icon to display a tooltip with an error description.

![](https://docs.devexpress.com/WPF/images/GridViewBase_InvalidRowExceptionCommand.png?v=21.2&f=InvalidRowException)

