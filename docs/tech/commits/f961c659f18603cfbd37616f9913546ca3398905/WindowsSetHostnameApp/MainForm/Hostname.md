[Project](../../../../index.md) / [Commits](../../../index.md) / [f961c659f18603cfbd37616f9913546ca3398905](../../index.md) / [WindowsSetHostnameApp](../index.md) / [MainForm](index.md) / Hostname

## Hostname DataGridViewTextBoxColumn

Represents a column in a DataGridView that displays text data for hostnames.

```csharp
private System.Windows.Forms.DataGridViewTextBoxColumn Hostname;
```

### Examples
```csharp
DataGridViewTextBoxColumn hostnameColumn = new DataGridViewTextBoxColumn();
hostnameColumn.Name = "Hostname";
hostnameColumn.HeaderText = "Host Name";
dgv.Columns.Add(hostnameColumn);
```

### Notes
This column is specifically designed to hold and display string values representing hostnames in a DataGridView control.

# Code
```csharp
private System.Windows.Forms.DataGridViewTextBoxColumn Hostname;
```

