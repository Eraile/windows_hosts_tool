[Project](../../../../index.md) / [Commits](../../../index.md) / [f961c659f18603cfbd37616f9913546ca3398905](../../index.md) / [WindowsSetHostnameApp.Properties](../index.md) / [Resources](index.md) / ResourceManager

## ResourceManager Property

This property provides a singleton instance of the ResourceManager for accessing resources in the application.

```csharp
internal static global::System.Resources.ResourceManager ResourceManager { get; }
```

### Examples
```csharp
var resourceValue = Resources.ResourceManager.GetString("ResourceKey");
```

### Notes
This property is marked as EditorBrowsableAttribute with Advanced state, indicating it is intended for advanced users and may not be suitable for general use.

# Code
```csharp
[global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
internal static global::System.Resources.ResourceManager ResourceManager
{
    get
    {
        if ((resourceMan == null))
        {
            global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("WindowsSetHostnameApp.Properties.Resources", typeof(Resources).Assembly);
            resourceMan = temp;
        }
        return resourceMan;
    }
}
```

