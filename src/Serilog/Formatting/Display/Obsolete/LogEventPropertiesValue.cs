﻿// Copyright 2017 Serilog Contributors
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

namespace Serilog.Formatting.Display.Obsolete;

[Obsolete("Not used by the current output formatting implementation.")]
class LogEventPropertiesValue : LogEventPropertyValue
{
    readonly MessageTemplate _template;
    readonly IReadOnlyDictionary<string, LogEventPropertyValue> _properties;
    readonly MessageTemplate _outputTemplate;

    public LogEventPropertiesValue(MessageTemplate template, IReadOnlyDictionary<string, LogEventPropertyValue> properties, MessageTemplate outputTemplate)
    {
        _template = template;
        _properties = properties;
        _outputTemplate = outputTemplate;
    }

    public override void Render(TextWriter output, string? format = null, IFormatProvider? formatProvider = null)
    {
        PropertiesOutputFormat.Render(_template, _properties, _outputTemplate, output, format, formatProvider);
    }
}
