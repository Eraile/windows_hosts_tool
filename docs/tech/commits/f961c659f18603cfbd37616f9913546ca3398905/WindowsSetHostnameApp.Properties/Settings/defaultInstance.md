[Project](../../../../index.md) / [Commits](../../../index.md) / [f961c659f18603cfbd37616f9913546ca3398905](../../index.md) / [WindowsSetHostnameApp.Properties](../index.md) / [Settings](index.md) / defaultInstance

## Default Instance of Settings

This code snippet initializes a static instance of the Settings class, ensuring thread safety by synchronizing access to the instance.

```csharp
private static Settings defaultInstance = ((Settings)(global::System.Configuration.ApplicationSettingsBase.Synchronized(new Settings())));
```

### Examples
```csharp
Settings settings = defaultInstance;
```

### Notes
The Settings class is typically used to manage application settings in a .NET application. The use of Synchronized ensures that the instance is thread-safe.

# Code
```csharp
private static Settings defaultInstance = ((Settings)(global::System.Configuration.ApplicationSettingsBase.Synchronized(new Settings())));
```

