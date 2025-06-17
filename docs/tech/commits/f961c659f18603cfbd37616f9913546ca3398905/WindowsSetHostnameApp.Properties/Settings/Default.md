[Project](../../../../index.md) / [Commits](../../../index.md) / [f961c659f18603cfbd37616f9913546ca3398905](../../index.md) / [WindowsSetHostnameApp.Properties](../index.md) / [Settings](index.md) / Default

## Default Property of Settings Class

Gets the default instance of the Settings class.

```csharp
public static Settings Default { get; }
```

### Examples
```csharp
var defaultSettings = Settings.Default;
```

### Notes
This property provides a singleton instance of the Settings class, ensuring that there is a single point of access to the default settings throughout the application.

# Code
```csharp
public static Settings Default
{
    get
    {
        return defaultInstance;
    }
}
```

