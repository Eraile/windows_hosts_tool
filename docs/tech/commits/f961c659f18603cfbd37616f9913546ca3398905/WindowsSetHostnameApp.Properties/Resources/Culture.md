[Project](../../../../index.md) / [Commits](../../../index.md) / [f961c659f18603cfbd37616f9913546ca3398905](../../index.md) / [WindowsSetHostnameApp.Properties](../index.md) / [Resources](index.md) / Culture

## Culture Property

Gets or sets the CultureInfo object that represents the culture used by the resource manager.

```csharp
internal static global::System.Globalization.CultureInfo Culture { get; set; }
```

### Examples
```csharp
Culture = new System.Globalization.CultureInfo("en-US");
```

```csharp
var currentCulture = Culture;
```

### Notes
This property is used to manage the culture-specific resources in applications, allowing for localization and internationalization.

# Code
```csharp
[global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
internal static global::System.Globalization.CultureInfo Culture
{
    get
    {
        return resourceCulture;
    }
    set
    {
        resourceCulture = value;
    }
}
```

