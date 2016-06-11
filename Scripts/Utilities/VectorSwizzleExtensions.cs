/***************************************************************************\
The MIT License (MIT)

Copyright (c) 2016 senritsu (https://github.com/senritsu)

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in
all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
THE SOFTWARE.
\***************************************************************************/

using System.Collections.Generic;
using senritsu.UnityGridTools.Scripts.IntVectors;
using UnityEngine;

namespace senritsu.UnityGridTools.Scripts.Utilities
{
    public static class VectorSwizzleExtensions
    {
        private static readonly Dictionary<char, int> ComponentMapping = new Dictionary<char, int>
        {
            {'x', 0}, {'y', 1}, {'z', 2}, {'w', 3}, 
            {'r', 0}, {'g', 1}, {'b', 2}, {'a', 3}, 
        };

        private static float GetComponent(Vector2 v, char component)
        {
            switch (component)
            {
                case '0':
                    return 0;
                case '1':
                    return 1;
            }

            var i = ComponentMapping[component];

            return i >= 2 ? 0 : v[i];
        }

        private static float GetComponent(Vector3 v, char component)
        {
            switch (component)
            {
                case '0':
                    return 0;
                case '1':
                    return 1;
            }

            var i = ComponentMapping[component];

            return i >= 3 ? 0 : v[i];
        }

        private static float GetComponent(Vector4 v, char component)
        {
            switch (component)
            {
                case '0':
                    return 0;
                case '1':
                    return 1;
            }

            var i = ComponentMapping[component];

            return v[i];
        }

        private static int GetComponent(IntVector2 v, char component)
        {
            switch (component)
            {
                case '0':
                    return 0;
                case '1':
                    return 1;
            }

            var i = ComponentMapping[component];

            return i >= 2 ? 0 : v[i];
        }

        private static int GetComponent(IntVector3 v, char component)
        {
            switch (component)
            {
                case '0':
                    return 0;
                case '1':
                    return 1;
            }

            var i = ComponentMapping[component];

            return i >= 3 ? 0 : v[i];
        }

        public static Vector2 Swizzle(this Vector2 v, string components)
        {
            return new Vector2(
                components.Length > 0 ? GetComponent(v, components[0]) : 0,
                components.Length > 1 ? GetComponent(v, components[1]) : 0
                );
        }

        public static Vector3 Swizzle(this Vector3 v, string components)
        {
            return new Vector3(
                components.Length > 0 ? GetComponent(v, components[0]) : 0,
                components.Length > 1 ? GetComponent(v, components[1]) : 0,
                components.Length > 2 ? GetComponent(v, components[2]) : 0
                );
        }

        public static Vector4 Swizzle(this Vector4 v, string components)
        {
            return new Vector4(
                components.Length > 0 ? GetComponent(v, components[0]) : 0,
                components.Length > 1 ? GetComponent(v, components[1]) : 0,
                components.Length > 2 ? GetComponent(v, components[2]) : 0,
                components.Length > 3 ? GetComponent(v, components[3]) : 0
                );
        }

        public static IntVector2 Swizzle(this IntVector2 v, string components)
        {
            return new IntVector2(
                components.Length > 0 ? GetComponent(v, components[0]) : 0,
                components.Length > 1 ? GetComponent(v, components[1]) : 0
                );
        }

        public static IntVector3 Swizzle(this IntVector3 v, string components)
        {
            return new IntVector3(
                components.Length > 0 ? GetComponent(v, components[0]) : 0,
                components.Length > 1 ? GetComponent(v, components[1]) : 0,
                components.Length > 2 ? GetComponent(v, components[2]) : 0
                );
        }
    }
}
