[Project](../../../../index.md) / [Commits](../../../index.md) / [f961c659f18603cfbd37616f9913546ca3398905](../../index.md) / [WindowsSetHostnameApp](../index.md) / [MainForm](index.md) / buttonApply_Click

## buttonApply_Click

Handles the click event for the Apply button, processes hostname and IP address entries from a DataGridView, modifies the hosts file, and writes the changes back to the system hosts file.

```csharp
private void buttonApply_Click(object sender, EventArgs e)
```

### Parameters
| Name | Type | Description |
| ---- | ---- | ----------- |
| sender | object | The source of the event, typically the button that was clicked. |
| e | EventArgs | The event data associated with the click event. |

### Examples
```csharp
buttonApply_Click(this
 new EventArgs())
```

### Notes
This method modifies the system hosts file, which may require administrative privileges. Ensure to handle potential exceptions when accessing file paths.

# Code
```csharp
private void buttonApply_Click(object sender, EventArgs e)
{
    // Get hostname infos
    List<HostnameInfos> hostnameInfos = new List<HostnameInfos>();
    foreach (DataGridViewRow row in this.dataGridView.Rows)
    {
        if (string.IsNullOrWhiteSpace((string)row.Cells[0].Value) == false
            && string.IsNullOrWhiteSpace((string)row.Cells[1].Value) == false)
        {
            hostnameInfos.Add(new HostnameInfos() { Hostname = (string)row.Cells[0].Value, Ip = (string)row.Cells[1].Value });
        }
    }

    // File paths
    string windowsHostFile = "C:/Windows/System32/drivers/etc/hosts";
    string localHostFile = Directory.GetCurrentDirectory() + "/hosts";

    // Copy hosts file
    File.Copy(windowsHostFile, localHostFile, true);

    // End content
    string fileContent = string.Empty;

    // Fix lines, fix content
    string[] allLines = File.ReadAllLines(localHostFile);
    if (allLines != null)
    {
        for (int i=0; i<allLines.Length; i++)
        {
            if (allLines[i].StartsWith("#") == true)
            {
                fileContent += (allLines[i] + System.Environment.NewLine);
            }
        }
    }
    
    // Add Hosts content
    if (hostnameInfos != null && hostnameInfos.Count > 0)
    {
        if (string.IsNullOrWhiteSpace(fileContent) == false)
            fileContent += System.Environment.NewLine;

        for (int i=0; i<hostnameInfos.Count; i++)
        {
            fileContent += (hostnameInfos[i].Ip + "\t\t" + hostnameInfos[i].Hostname + System.Environment.NewLine);
        }
    }
    
    // Write
    File.WriteAllLines(localHostFile, new string[] { fileContent });

    // Copy back
    File.Copy(localHostFile, windowsHostFile, true);
}
```

