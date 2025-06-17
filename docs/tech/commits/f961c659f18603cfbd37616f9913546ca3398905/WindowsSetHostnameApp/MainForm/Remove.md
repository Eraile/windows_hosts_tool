[Project](../../../../index.md) / [Commits](../../../index.md) / [f961c659f18603cfbd37616f9913546ca3398905](../../index.md) / [WindowsSetHostnameApp](../index.md) / [MainForm](index.md) / Remove

## DataGridViewButtonColumn Remove

Represents a button column in a DataGridView that allows users to remove items.

```csharp
private System.Windows.Forms.DataGridViewButtonColumn Remove;
```

### Examples
```csharp
dataGridView1.Columns.Add(Remove);
```

```csharp
Remove = new System.Windows.Forms.DataGridViewButtonColumn();
```

```csharp
Remove.HeaderText = 'Remove';
```

```csharp
Remove.Text = 'Delete';
```

```csharp
Remove.UseColumnTextForButtonValue = true;
```

### Notes
This column type is typically used to provide a user interface element for removing rows from a DataGridView.

# Code
```csharp
private System.Windows.Forms.DataGridViewButtonColumn Remove;
```

