<!-- default badges list -->
![](https://img.shields.io/endpoint?url=https://codecentral.devexpress.com/api/v1/VersionRange/128653826/11.1.4%2B)
[![](https://img.shields.io/badge/Open_in_DevExpress_Support_Center-FF7200?style=flat-square&logo=DevExpress&logoColor=white)](https://supportcenter.devexpress.com/ticket/details/E1593)
[![](https://img.shields.io/badge/📖_How_to_use_DevExpress_Examples-e9f6fc?style=flat-square)](https://docs.devexpress.com/GeneralInformation/403183)
<!-- default badges end -->

# WPF Data Grid - How to Validate Data Rows

This example shows how to check if a user enters valid data into a row. Handle the [ValidateRow](https://docs.devexpress.com/WPF/DevExpress.Xpf.Grid.GridViewBase.ValidateRow) and [InvalidRowException](https://docs.devexpress.com/WPF/DevExpress.Xpf.Grid.GridViewBase.InvalidRowException) events to validate the focused row's data. If the data is invalid, do not allow the user to move focus to another row until the invalid values are corrected.

The **Task** class implements the [IDXDataErrorInfo](https://docs.devexpress.com/WPF/6157/controls-and-libraries/data-grid/data-editing-and-validation/input-validation/interface-based-validation#idxdataerrorinfo) interface and allows you to get error descriptions for the entire row and individual cells (data source fields). Error icons appear in cells that contain invalid values. Hover the mouse pointer over an error icon to display a tooltip with an error description.

![](https://docs.devexpress.com/WPF/images/GridViewBase_InvalidRowExceptionCommand.png?v=21.2&f=InvalidRowException)

<!-- default file list -->

## Files to Look At

- [Window1.xaml](./CS/DXGrid_ValidateRow/Window1.xaml) ([Window1.xaml](./VB/DXGrid_ValidateRow/Window1.xaml))
- [Window1.xaml.cs](./CS/DXGrid_ValidateRow/Window1.xaml.cs#L25-L33) ([Window1.xaml.vb](./VB/DXGrid_ValidateRow/Window1.xaml.vb#L26-L36))

<!-- default file list end -->

## Documentation

- [Data Editing and Validation](https://docs.devexpress.com/WPF/6108/controls-and-libraries/data-grid/data-editing-and-validation)
- [Row Validation](https://docs.devexpress.com/WPF/6114/controls-and-libraries/data-grid/data-editing-and-validation/input-validation/row-validation)
- [ValidateRow](https://docs.devexpress.com/WPF/DevExpress.Xpf.Grid.GridViewBase.ValidateRow)
- [InvalidRowException](https://docs.devexpress.com/WPF/DevExpress.Xpf.Grid.GridViewBase.InvalidRowException)

## More Examples

- [How to Validate Cell Editors](https://github.com/DevExpress-Examples/validate-cell-editors)
- [How to Implement Attributes-Based Validation](https://github.com/DevExpress-Examples/how-to-implement-attributes-based-validation-e3191)
- [How to Initialize the New Item Row with Default Values](https://github.com/DevExpress-Examples/how-to-initialize-the-new-item-row-with-default-values-e1569)
