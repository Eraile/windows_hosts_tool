[Project](../../../../index.md) / [Commits](../../../index.md) / [f961c659f18603cfbd37616f9913546ca3398905](../../index.md) / [WindowsSetHostnameApp](../index.md) / [MainForm](index.md) / MainForm_Load

## MainForm_Load

Event handler for the Load event of the MainForm. This method copies the hosts file from the Windows directory to the local directory and processes its content to populate a data grid view.

```csharp
private void MainForm_Load(object sender, EventArgs e)
```

### Parameters
| Name | Type | Description |
| ---- | ---- | ----------- |
| sender | object | The source of the event. |
| e | EventArgs | The event data. |

### Examples
```csharp
MainForm_Load(this
 EventArgs.Empty);
```

### Notes
This method reads the hosts file, filters out comments and empty lines, and adds valid hostname and IP pairs to a data grid view.

# Code
```csharp
private void MainForm_Load(object sender, EventArgs e)
{
    // File paths
    string windowsHostFile = "C:/Windows/System32/drivers/etc/hosts";
    string localHostFile = Directory.GetCurrentDirectory() + "/hosts";

    // Copy hosts file
    File.Copy(windowsHostFile, localHostFile, true);

    // Fix lines, fix content
    string[] allLines = File.ReadAllLines(localHostFile);
    if (allLines != null)
    {
        for (int i = 0; i < allLines.Length; i++)
        {
            if (allLines[i].StartsWith("#") == false)
            {
                List<string> hostLine = new List<string>(allLines[i].Split(new char[0]));
                if (hostLine != null && hostLine.Count > 0)
                {
                    hostLine.RemoveAll(x => string.IsNullOrWhiteSpace(x));
                    if (hostLine.Count >= 2)
                    {
                        int rowLine = this.dataGridView.Rows.Add();
                        // Hostname
                        this.dataGridView.Rows[rowLine].Cells[0].Value = hostLine[1];
                        // IP
                        this.dataGridView.Rows[rowLine].Cells[1].Value = hostLine[0];
                    }
                }
            }
        }
    }
}
```

