[Project](../../../../index.md) / [Commits](../../../index.md) / [f961c659f18603cfbd37616f9913546ca3398905](../../index.md) / [WindowsSetHostnameApp](../index.md) / [Program](index.md) / Main

## Main Method

The entry point for the application that initializes the visual styles and runs the main form.

```csharp
static void Main()
```

### Examples
```csharp
Application.Run(new MainForm());
```

### Notes
This method is marked with [STAThread] attribute, which indicates that the COM threading model for the application is single-threaded apartment.

# Code
```csharp
[STAThread]
static void Main()
{
    Application.EnableVisualStyles();
    Application.SetCompatibleTextRenderingDefault(false);
    Application.Run(new MainForm());
}
```

