[Project](../../../../index.md) / [Commits](../../../index.md) / [f961c659f18603cfbd37616f9913546ca3398905](../../index.md) / [WindowsSetHostnameApp](../index.md) / [HostnameInfos](index.md) / HostnameInfos

## HostnameInfos

A class that holds information about a hostname and its associated IP address.

```csharp
public class HostnameInfos
```

### Parameters
| Name | Type | Description |
| ---- | ---- | ----------- |
| Ip | string | The IP address associated with the hostname. |
| Hostname | string | The hostname corresponding to the IP address. |

### Examples
```csharp
HostnameInfos info = new HostnameInfos { Ip = "192.168.1.1"
 Hostname = "example.com" };
```

### Notes
This class is used to represent the relationship between an IP address and its hostname.

