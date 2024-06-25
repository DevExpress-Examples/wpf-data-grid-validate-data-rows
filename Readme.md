<!-- default badges list -->
![](https://img.shields.io/endpoint?url=https://codecentral.devexpress.com/api/v1/VersionRange/128653826/10.1.4%2B)
[![](https://img.shields.io/badge/Open_in_DevExpress_Support_Center-FF7200?style=flat-square&logo=DevExpress&logoColor=white)](https://supportcenter.devexpress.com/ticket/details/E1593)
[![](https://img.shields.io/badge/📖_How_to_use_DevExpress_Examples-e9f6fc?style=flat-square)](https://docs.devexpress.com/GeneralInformation/403183)
[![](https://img.shields.io/badge/💬_Leave_Feedback-feecdd?style=flat-square)](#does-this-example-address-your-development-requirementsobjectives)
<!-- default badges end -->
<!-- default file list -->
*Files to look at*:

* [Window1.xaml](./CS/DXGrid_ValidateRow/Window1.xaml) (VB: [Window1.xaml](./VB/DXGrid_ValidateRow/Window1.xaml))
* [Window1.xaml.cs](./CS/DXGrid_ValidateRow/Window1.xaml.cs) (VB: [Window1.xaml.vb](./VB/DXGrid_ValidateRow/Window1.xaml.vb))
<!-- default file list end -->
# How to Validate Data Rows


<p>This example shows how to check the validity of data entered by end-users into a data row. The ValidateRow and InvalidRowException events are handled to validate the focused row's data, and if it is invalid, prevent the row focus from being moved to another row until invalid values are corrected.</p><p>Since the Task class doesn't support error notifications, it implements the IDXDataErrorInfo interface, providing two members to get error descriptions for the entire row and for individual cells (data source fields). This displays error icons within cells with invalid values. Pointing to such an error icon displays a tooltip with an error description.</p>

<br/>


<!-- feedback -->
## Does this example address your development requirements/objectives?

[<img src="https://www.devexpress.com/support/examples/i/yes-button.svg"/>](https://www.devexpress.com/support/examples/survey.xml?utm_source=github&utm_campaign=wpf-data-grid-validate-data-rows&~~~was_helpful=yes) [<img src="https://www.devexpress.com/support/examples/i/no-button.svg"/>](https://www.devexpress.com/support/examples/survey.xml?utm_source=github&utm_campaign=wpf-data-grid-validate-data-rows&~~~was_helpful=no)

(you will be redirected to DevExpress.com to submit your response)
<!-- feedback end -->
