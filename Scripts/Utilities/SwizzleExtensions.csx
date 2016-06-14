using System.Collections.Generic;
using System.Linq;

var skeletonStart = @"
/***************************************************************************\
The MIT License (MIT)

Copyright (c) 2016 senritsu (https://github.com/senritsu)

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the ""Software""), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/ or sell
 copies of the Software, and to permit persons to whom the Software is
 furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in
all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED ""AS IS"", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT.IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
THE SOFTWARE.
\***************************************************************************/

using System;

using UnityEngine;

using senritsu.UnityGridTools.Scripts.IntVectors;

namespace senritsu.UnityGridTools.Utilities
{
    public static class {{type}}SwizzleExtensions
    {".TrimStart();

var skeletonEnd = @"
    }
}";

var caseArray = new string[] {
@"
                case '0':
                    return 0;
                case '1':
                    return 1;
                case 'x':
                case 'r':
                    return v.x;
                case 'y':
                case 'g':
                    return v.y;
".TrimStart(),
@"
                case 'z':
                case 'b':
                    return v.z;
".TrimStart('\r','\n'),
@"
                case 'w':
                case 'a':
                    return v.w;
".TrimStart('\r','\n')};

var getComponentTemplate = @"
        private static {{componentType}} GetComponent({{type}} v, char component)
        {
            switch (component)
            {
                {{cases}}
            }
            throw new InvalidOperationException(""Invalid component: "" + component);
        }";

var extensionTemplate = @"

        public static {{targetType}} Swizzle{{targetType}}(this {{type}} v, string components)
        {
            if (components.Length != {{length}})
            {
                throw new InvalidOperationException(string.Format(""Invalid swizzle '{0}', cannot swizzle {1} components to {{targetType}}"", components, components.Length));
            }

            return new {{targetType}}(
                {{ctorComponents}}
                );
        }
".TrimEnd('\r', '\n');

var ctorComponentTemplateFloat = @"GetComponent(v, components[{0}])";
var ctorComponentTemplateInt = @"Mathf.RoundToInt(GetComponent(v, components[{0}]))";

var types = new[] { "Vector2", "Vector3", "Vector4", "IntVector2", "IntVector3", "IntVector4" };

Func<string, string> componentType = (s) => s.Contains("Int") ? "int" : "float";
Func<string, int> componentCount = (s) => int.Parse(s.Last().ToString());

foreach (var type in types)
{
    var file = Output[type + "SwizzleExtensions.cs"];
    var i = componentCount(type);

    var cases = caseArray[0];
    if (i > 2)
    {
        cases += caseArray[1];
    }
    if (i > 3)
    {
        cases += caseArray[2];
    }
    var getComponent = getComponentTemplate
        .Replace("{{type}}", type)
        .Replace("{{componentType}}", componentType(type))
        .Replace("{{cases}}", cases.TrimEnd());

    var contents = getComponent.Trim(new char[] { '\r', '\n' });

    file.Write(skeletonStart.Replace("{{type}}", type));

    file.Write(getComponent);

    foreach (var targetType in types)
    {
        var length = componentCount(targetType);

        var ctorComponentTemplate = componentType(targetType) == "int" ? 
            ctorComponentTemplateInt : 
            ctorComponentTemplateFloat;

        var ctorComponents = string.Join(",\r\n                ", Enumerable.Range(0, length).Select(
            x => string.Format(ctorComponentTemplate, x)
        )).Trim('\r', '\n');

        var extension = extensionTemplate
            .Replace("{{type}}", type)
            .Replace("{{targetType}}", targetType)
            .Replace("{{componentType}}", componentType(targetType))
            .Replace("{{length}}", length.ToString())
            .Replace("{{ctorComponents}}", ctorComponents);

        file.Write(extension);
    }

    file.Write(skeletonEnd);
}