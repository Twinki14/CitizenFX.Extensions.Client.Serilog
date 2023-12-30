# CitizenFX.Extensions.Client.Serilog
[![Downloads](https://img.shields.io/nuget/dt/CitizenFX.Extensions.Client.Serilog?style=flat-square)](https://www.nuget.org/packages/CitizenFX.Extensions.Client.Serilog)
[![GitHub release](https://img.shields.io/github/v/release/Twinki14/CitizenFX.Extensions.Client.Serilog?style=flat-square)](https://github.com/Twinki14/CitizenFX.Extensions.Client.Serilog/releases)
[![Nuget](https://img.shields.io/nuget/v/CitizenFX.Extensions.Client.Serilog?style=flat-square)](https://www.nuget.org/packages/CitizenFX.Extensions.Client.Serilog)
[![GitHub Workflow Status](https://img.shields.io/github/actions/workflow/status/Twinki14/CitizenFX.Extensions.Client.Serilog/build-publish.yaml?style=flat-square)](https://github.com/Twinki14/CitizenFX.Extensions.Client.Serilog/actions/workflows/build-publish.yaml)

A fork of the [logging library known as Serilog](https://serilog.net/), based off [v2.12.0](https://github.com/serilog/serilog/tree/v2.12.0) for compatability with [.NET client-side FiveM](https://fivem.net/)


## Example
```csharp
public class Script : BaseScript
{
    public Script()
    {
        Log.Logger = new LoggerConfiguration()
            .MinimumLevel.Debug()
            .WriteTo.FiveM()
            .CreateLogger();
    }
    
    [Command("client")]
    public void Command()
    {
        try
        {
            Log.Logger.Debug("Hello from the FiveM Client!");
            
            Log.Logger.Information("Player is located at {Position}", Game.Player.Character.Position.ToString());
        }
        catch (Exception e)
        {
            Log.Logger.Error(e, "Exception hit!");
        }
    }
}
```

## Changes from [v2.12.0 of Serilog](https://github.com/serilog/serilog/tree/v2.12.0)
### v2.12.0-cfx
- [#1](https://github.com/Twinki14/CitizenFX.Extensions.Client.Serilog/pull/1) - Trim files, remove assembly signing, only target net452
- [#2](https://github.com/Twinki14/CitizenFX.Extensions.Client.Serilog/pull/2) - Add CI/CD proceeded by fix [in #4](https://github.com/Twinki14/CitizenFX.Extensions.Client.Serilog/pull/4)
- [#3](https://github.com/Twinki14/CitizenFX.Extensions.Client.Serilog/pull/3) - Remove extra performance tests & results, this just bloated things for the purpose of this fork
- [#5](https://github.com/Twinki14/CitizenFX.Extensions.Client.Serilog/pull/5) - Un-yield `yield return` and `yield break` uses
- [#6](https://github.com/Twinki14/CitizenFX.Extensions.Client.Serilog/pull/6) - Add `get` `set` to PropertyToken._position
- [#7](https://github.com/Twinki14/CitizenFX.Extensions.Client.Serilog/pull/7) - Add FiveM Client Console Sink

## Notes
- This fork is in **NO WAY** affiliated with the [Serilog Organization](https://github.com/serilog) or the [Serilog project](https://serilog.net/), it's purely a fork to provide compatability with FiveM's client-resource shipped mono
- This fork **ONLY PROVIDES** support for incompatibilities with .NET client-side FiveM, if there's an incompatibility [report it here](https://github.com/Twinki14/CitizenFX.Extensions.Client.Serilog/issues/new/choose)
