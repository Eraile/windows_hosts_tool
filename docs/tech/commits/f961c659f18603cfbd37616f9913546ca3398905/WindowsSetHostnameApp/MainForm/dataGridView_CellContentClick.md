[Project](../../../../index.md) / [Commits](../../../index.md) / [f961c659f18603cfbd37616f9913546ca3398905](../../index.md) / [WindowsSetHostnameApp](../index.md) / [MainForm](index.md) / dataGridView_CellContentClick

## dataGridView_CellContentClick

Handles the CellContentClick event of a DataGridView, allowing for the removal of rows when a button cell is clicked.

```csharp
private void dataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
```

### Parameters
| Name | Type | Description |
| ---- | ---- | ----------- |
| sender | object | The source of the event, typically the DataGridView that raised the event. |
| e | DataGridViewCellEventArgs | An object that contains the event data, including the row and column index of the clicked cell. |

### Examples
```csharp
dataGridView_CellContentClick(this
 new DataGridViewCellEventArgs(columnIndex
 rowIndex));
```

### Notes
This method checks if the clicked cell is a button column and if the row is not the last one before removing it.

# Code
```csharp
private void dataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
{
    var senderGrid = (DataGridView)sender;
    if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex >= 0)
    {
        if (e.RowIndex != (this.dataGridView.RowCount - 1))
            this.dataGridView.Rows.RemoveAt(e.RowIndex);
    }
}
```

