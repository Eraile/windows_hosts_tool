[Project](../../../../index.md) / [Commits](../../../index.md) / [f961c659f18603cfbd37616f9913546ca3398905](../../index.md) / [WindowsSetHostnameApp](../index.md) / [MainForm](index.md) / Dispose

## Dispose Method

Cleans up resources used by the component. This method is called when the component is being disposed.

```csharp
protected override void Dispose(bool disposing)
```

### Parameters
| Name | Type | Description |
| ---- | ---- | ----------- |
| disposing | bool | A boolean value indicating whether the method was called directly or indirectly by a user's code. If true, the method has been called directly by the user code, and managed resources can be disposed. |

### Examples
```csharp
myComponent.Dispose(true);
```

### Notes
This method should be overridden in derived classes to release any resources that the component is holding.

# Code
```csharp
protected override void Dispose(bool disposing)
{
    if (disposing && (components != null))
    {
        components.Dispose();
    }
    base.Dispose(disposing);
}
```

