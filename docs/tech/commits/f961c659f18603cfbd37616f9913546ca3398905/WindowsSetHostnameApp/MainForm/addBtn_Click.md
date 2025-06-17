[Project](../../../../index.md) / [Commits](../../../index.md) / [f961c659f18603cfbd37616f9913546ca3398905](../../index.md) / [WindowsSetHostnameApp](../index.md) / [MainForm](index.md) / addBtn_Click

## addBtn_Click

Event handler for the add button click event that adds a new row to the data grid view.

```csharp
private void addBtn_Click(object sender, EventArgs e)
```

### Parameters
| Name | Type | Description |
| ---- | ---- | ----------- |
| sender | object | The source of the event, typically the button that was clicked. |
| e | EventArgs | Contains the event data. |

### Examples
```csharp
this.addBtn.Click += new EventHandler(this.addBtn_Click);
```

### Notes
This method is typically used in a Windows Forms application to handle user interactions with the UI.

# Code
```csharp
private void addBtn_Click(object sender, EventArgs e)
{
    this.dataGridView.Rows.Add();
}
```

