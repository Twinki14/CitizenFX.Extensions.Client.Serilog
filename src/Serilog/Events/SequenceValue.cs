// Copyright 2013-2015 Serilog Contributors
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
//     http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.

namespace Serilog.Events;

/// <summary>
/// A value represented as an ordered sequence of values.
/// </summary>
public class SequenceValue : LogEventPropertyValue
{
    readonly LogEventPropertyValue[] _elements;

    /// <summary>
    /// Create a <see cref="SequenceValue"/> with the provided <paramref name="elements"/>.
    /// </summary>
    /// <param name="elements">The elements of the sequence.</param>
    /// <exception cref="ArgumentNullException">When <paramref name="elements"/> is <code>null</code></exception>
    public SequenceValue(IEnumerable<LogEventPropertyValue> elements)
    {
        Guard.AgainstNull(elements);

        _elements = elements.ToArray();
    }

    /// <summary>
    /// The elements of the sequence.
    /// </summary>
    public IReadOnlyList<LogEventPropertyValue> Elements => _elements;

    /// <summary>
    /// Render the value to the output.
    /// </summary>
    /// <param name="output">The output.</param>
    /// <param name="format">A format string applied to the value, or null.</param>
    /// <param name="formatProvider">A format provider to apply to the value, or null to use the default.</param>
    /// <seealso cref="LogEventPropertyValue.ToString(string, IFormatProvider)"/>.
    /// <exception cref="ArgumentNullException">When <paramref name="output"/> is <code>null</code></exception>
    public override void Render(TextWriter output, string? format = null, IFormatProvider? formatProvider = null)
    {
        Guard.AgainstNull(output);

        output.Write('[');
        var allButLast = _elements.Length - 1;
        for (var i = 0; i < allButLast; ++i)
        {
            _elements[i].Render(output, format, formatProvider);
            output.Write(", ");
        }

        if (_elements.Length > 0)
            _elements[_elements.Length - 1].Render(output, format, formatProvider);

        output.Write(']');
    }
}
