[Project](../../../../index.md) / [Commits](../../../index.md) / [f961c659f18603cfbd37616f9913546ca3398905](../../index.md) / [Files](../index.md) / [WindowsSetHostnameApp](./index.md) / Program.cs

# File `Program.cs`

## Members

- **Class** [Program](../../WindowsSetHostnameApp/Program/index.md)
- **Namespace** [WindowsSetHostnameApp](../../WindowsSetHostnameApp/index.md)
## Program.cs

Contains the main entry point for the Windows Set Hostname application.

### Notes
The Main method is marked with [STAThread] attribute, indicating that the COM threading model for the application is single-threaded apartment.


## File Content
```csharp
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace WindowsSetHostnameApp
{
    static class Program
    {
        /// <summary>
        /// Point d'entrée principal de l'application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }
    }
}

```
