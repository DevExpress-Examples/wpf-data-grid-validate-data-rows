<!-- default badges list -->
![](https://img.shields.io/endpoint?url=https://codecentral.devexpress.com/api/v1/VersionRange/128653826/21.2.2%2B)
[![](https://img.shields.io/badge/Open_in_DevExpress_Support_Center-FF7200?style=flat-square&logo=DevExpress&logoColor=white)](https://supportcenter.devexpress.com/ticket/details/E1593)
[![](https://img.shields.io/badge/📖_How_to_use_DevExpress_Examples-e9f6fc?style=flat-square)](https://docs.devexpress.com/GeneralInformation/403183)
<!-- default badges end -->
# How to Validate Data Rows


<p>This example shows how to check the validity of data entered by end-users into a data row. The ValidateRow and InvalidRowException events are handled to validate the focused row's data, and if it is invalid, prevent the row focus from being moved to another row until invalid values are corrected.</p><p>Since the Task class doesn't support error notifications, it implements the IDXDataErrorInfo interface, providing two members to get error descriptions for the entire row and for individual cells (data source fields). This displays error icons within cells with invalid values. Pointing to such an error icon displays a tooltip with an error description.</p>

<br/>


