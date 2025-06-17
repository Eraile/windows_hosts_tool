[Project](../../../../index.md) / [Commits](../../../index.md) / [f961c659f18603cfbd37616f9913546ca3398905](../../index.md) / [WindowsSetHostnameApp](../index.md) / [MainForm](index.md) / addBtn

## addBtn

A button control used to trigger the addition of items or actions in a Windows Forms application.

```csharp
private System.Windows.Forms.Button addBtn;
```

### Examples
```csharp
addBtn = new System.Windows.Forms.Button();
```

```csharp
addBtn.Text = "Add";
```

```csharp
addBtn.Click += new System.EventHandler(this.AddButton_Click);
```

### Notes
This button should be initialized and configured in the form's constructor or Load event. Ensure to handle the Click event to define the action performed when the button is clicked.

# Code
```csharp
private System.Windows.Forms.Button addBtn;
```

