[Project](../../../../index.md) / [Commits](../../../index.md) / [f961c659f18603cfbd37616f9913546ca3398905](../../index.md) / [WindowsSetHostnameApp](../index.md) / MainForm

# Class MainForm

## Functions
- [MainForm_Load](./MainForm_Load.md)
- [buttonApply_Click](./buttonApply_Click.md)
- [addBtn_Click](./addBtn_Click.md)
- [dataGridView_CellContentClick](./dataGridView_CellContentClick.md)

## MainForm

A Windows Form application for managing hostnames and their corresponding IP addresses.

```csharp
partial class MainForm : Form
```

### Examples
```csharp
MainForm form = new MainForm(); form.Show();
```

### Notes
This form allows users to add, edit, and remove hostname and IP address pairs, and applies changes to the system's hosts file.

