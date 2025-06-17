[Project](../../../../index.md) / [Commits](../../../index.md) / [f961c659f18603cfbd37616f9913546ca3398905](../../index.md) / [WindowsSetHostnameApp](../index.md) / [MainForm](index.md) / IP

## IP DataGridViewTextBoxColumn

Represents a column in a DataGridView that displays text values, specifically for IP addresses.

```csharp
private System.Windows.Forms.DataGridViewTextBoxColumn IP;
```

### Examples
```csharp
DataGridViewTextBoxColumn ipColumn = new DataGridViewTextBoxColumn();
```

```csharp
ipColumn.Name = 'IP';
```

```csharp
ipColumn.HeaderText = 'IP Address';
```

```csharp
dataGridView.Columns.Add(ipColumn);
```

### Notes
This column is intended to hold string representations of IP addresses. Ensure proper validation is implemented when adding data to this column.

# Code
```csharp
private System.Windows.Forms.DataGridViewTextBoxColumn IP;
```

