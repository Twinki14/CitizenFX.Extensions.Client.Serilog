using CitizenFX.Core;
using Serilog.Formatting;

namespace Serilog.Sinks;

class FiveMSink : ILogEventSink
{
    readonly ITextFormatter _textFormatter;

    public FiveMSink(ITextFormatter textFormatter)
    {
        _textFormatter = textFormatter ?? throw new ArgumentNullException(nameof(textFormatter));
    }

    public void Emit(LogEvent logEvent)
    {
        if (logEvent == null) throw new ArgumentNullException(nameof(logEvent));
        var renderSpace = new StringWriter();
        _textFormatter.Format(logEvent, renderSpace);

        Debug.Write(renderSpace.ToString());
    }
}
