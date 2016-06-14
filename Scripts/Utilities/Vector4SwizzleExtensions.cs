/***************************************************************************\
The MIT License (MIT)

Copyright (c) 2016 senritsu (https://github.com/senritsu)

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/ or sell
 copies of the Software, and to permit persons to whom the Software is
 furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in
all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
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
    public static class Vector4SwizzleExtensions
    {
        private static float GetComponent(Vector4 v, char component)
        {
            switch (component)
            {
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
                case 'z':
                case 'b':
                    return v.z;
                case 'w':
                case 'a':
                    return v.w;
            }
            throw new InvalidOperationException("Invalid component: " + component);
        }

        public static Vector2 SwizzleVector2(this Vector4 v, string components)
        {
            if (components.Length != 2)
            {
                throw new InvalidOperationException(string.Format("Invalid swizzle '{0}', cannot swizzle {1} components to Vector2", components, components.Length));
            }

            return new Vector2(
                GetComponent(v, components[0]),
                GetComponent(v, components[1])
                );
        }

        public static Vector3 SwizzleVector3(this Vector4 v, string components)
        {
            if (components.Length != 3)
            {
                throw new InvalidOperationException(string.Format("Invalid swizzle '{0}', cannot swizzle {1} components to Vector3", components, components.Length));
            }

            return new Vector3(
                GetComponent(v, components[0]),
                GetComponent(v, components[1]),
                GetComponent(v, components[2])
                );
        }

        public static Vector4 SwizzleVector4(this Vector4 v, string components)
        {
            if (components.Length != 4)
            {
                throw new InvalidOperationException(string.Format("Invalid swizzle '{0}', cannot swizzle {1} components to Vector4", components, components.Length));
            }

            return new Vector4(
                GetComponent(v, components[0]),
                GetComponent(v, components[1]),
                GetComponent(v, components[2]),
                GetComponent(v, components[3])
                );
        }

        public static IntVector2 SwizzleIntVector2(this Vector4 v, string components)
        {
            if (components.Length != 2)
            {
                throw new InvalidOperationException(string.Format("Invalid swizzle '{0}', cannot swizzle {1} components to IntVector2", components, components.Length));
            }

            return new IntVector2(
                Mathf.RoundToInt(GetComponent(v, components[0])),
                Mathf.RoundToInt(GetComponent(v, components[1]))
                );
        }

        public static IntVector3 SwizzleIntVector3(this Vector4 v, string components)
        {
            if (components.Length != 3)
            {
                throw new InvalidOperationException(string.Format("Invalid swizzle '{0}', cannot swizzle {1} components to IntVector3", components, components.Length));
            }

            return new IntVector3(
                Mathf.RoundToInt(GetComponent(v, components[0])),
                Mathf.RoundToInt(GetComponent(v, components[1])),
                Mathf.RoundToInt(GetComponent(v, components[2]))
                );
        }

        public static IntVector4 SwizzleIntVector4(this Vector4 v, string components)
        {
            if (components.Length != 4)
            {
                throw new InvalidOperationException(string.Format("Invalid swizzle '{0}', cannot swizzle {1} components to IntVector4", components, components.Length));
            }

            return new IntVector4(
                Mathf.RoundToInt(GetComponent(v, components[0])),
                Mathf.RoundToInt(GetComponent(v, components[1])),
                Mathf.RoundToInt(GetComponent(v, components[2])),
                Mathf.RoundToInt(GetComponent(v, components[3]))
                );
        }
    }
}