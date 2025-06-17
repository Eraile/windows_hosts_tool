[Project](../../../../index.md) / [Commits](../../../index.md) / [f961c659f18603cfbd37616f9913546ca3398905](../../index.md) / [WindowsSetHostnameApp.Properties](../index.md) / [Resources](index.md) / resourceMan

## ResourceManager Field

A static field that holds an instance of ResourceManager, which is used for retrieving resources from a resource file.

```csharp
private static global::System.Resources.ResourceManager resourceMan;
```

### Examples
```csharp
resourceMan = new ResourceManager("MyNamespace.MyResources"
 typeof(MyClass).Assembly);
```

### Notes
This field is typically used in applications that require localization or resource management. It allows for efficient access to resources such as strings, images, and other data stored in resource files.

# Code
```csharp
private static global::System.Resources.ResourceManager resourceMan;
```

