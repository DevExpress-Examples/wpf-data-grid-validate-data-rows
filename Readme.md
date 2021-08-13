# How to Validate Data Rows


<p>This example shows how to check the validity of data entered by end-users into a data row. The ValidateRow and InvalidRowException events are handled to validate the focused row's data, and if it is invalid, prevent the row focus from being moved to another row until invalid values are corrected.</p><p>Since the Task class doesn't support error notifications, it implements the IDXDataErrorInfo interface, providing two members to get error descriptions for the entire row and for individual cells (data source fields). This displays error icons within cells with invalid values. Pointing to such an error icon displays a tooltip with an error description.</p>

<br/>


