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

using System;
using System.Collections.Generic;
using senritsu.UnityGridTools.Scripts.IntVectors;
using UnityEngine;

namespace senritsu.UnityGridTools.Scripts.Utilities
{
    public class InvalidNumberOfComponentsException<T> : InvalidOperationException
    {
        public InvalidNumberOfComponentsException(string swizzleSpec) : base(string.Format("Invalid number of components, cannot swizzle '{0}' to {1}", swizzleSpec, typeof(T).Name))
        {
            
        }
    }

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

            return v[i];
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

            return v[i];
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

            return v[i];
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

            return v[i];
        }

        private static int GetComponent(IntVector4 v, char component)
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

        public static Vector2 SwizzleVector2(this Vector2 v, string components)
        {
            if (components.Length != 2)
            {
                throw new InvalidNumberOfComponentsException<Vector2>(components);
            }

            return new Vector2(
                GetComponent(v, components[0]),
                GetComponent(v, components[1])
                );
        }

        public static Vector2 SwizzleVector2(this IntVector2 v, string components)
        {
            if (components.Length != 2)
            {
                throw new InvalidNumberOfComponentsException<Vector2>(components);
            }

            return new Vector2(
                GetComponent(v, components[0]),
                GetComponent(v, components[1])
                );
        }

        public static Vector2 SwizzleVector2(this Vector3 v, string components)
        {
            if (components.Length != 2)
            {
                throw new InvalidNumberOfComponentsException<Vector2>(components);
            }

            return new Vector2(
                GetComponent(v, components[0]),
                GetComponent(v, components[1])
                );
        }

        public static Vector2 SwizzleVector2(this IntVector3 v, string components)
        {
            if (components.Length != 2)
            {
                throw new InvalidNumberOfComponentsException<Vector2>(components);
            }

            return new Vector2(
                GetComponent(v, components[0]),
                GetComponent(v, components[1])
                );
        }

        public static Vector2 SwizzleVector2(this Vector4 v, string components)
        {
            if (components.Length != 2)
            {
                throw new InvalidNumberOfComponentsException<Vector2>(components);
            }

            return new Vector2(
                GetComponent(v, components[0]),
                GetComponent(v, components[1])
                );
        }

        public static Vector2 SwizzleVector2(this IntVector4 v, string components)
        {
            if (components.Length != 2)
            {
                throw new InvalidNumberOfComponentsException<Vector2>(components);
            }

            return new Vector2(
                GetComponent(v, components[0]),
                GetComponent(v, components[1])
                );
        }

        public static IntVector2 SwizzleIntVector2(this Vector2 v, string components)
        {
            if (components.Length != 2)
            {
                throw new InvalidNumberOfComponentsException<IntVector2>(components);
            }

            return new IntVector2(
                Mathf.RoundToInt(GetComponent(v, components[0])),
                Mathf.RoundToInt(GetComponent(v, components[1]))
                );
        }

        public static IntVector2 SwizzleIntVector2(this IntVector2 v, string components)
        {
            if (components.Length != 2)
            {
                throw new InvalidNumberOfComponentsException<IntVector2>(components);
            }

            return new IntVector2(
                GetComponent(v, components[0]),
                GetComponent(v, components[1])
                );
        }

        public static IntVector2 SwizzleIntVector2(this Vector3 v, string components)
        {
            if (components.Length != 2)
            {
                throw new InvalidNumberOfComponentsException<IntVector2>(components);
            }

            return new IntVector2(
                Mathf.RoundToInt(GetComponent(v, components[0])),
                Mathf.RoundToInt(GetComponent(v, components[1]))
                );
        }

        public static IntVector2 SwizzleIntVector2(this IntVector3 v, string components)
        {
            if (components.Length != 2)
            {
                throw new InvalidNumberOfComponentsException<IntVector2>(components);
            }

            return new IntVector2(
                GetComponent(v, components[0]),
                GetComponent(v, components[1])
                );
        }

        public static IntVector2 SwizzleIntVector2(this Vector4 v, string components)
        {
            if (components.Length != 2)
            {
                throw new InvalidNumberOfComponentsException<IntVector2>(components);
            }

            return new IntVector2(
                Mathf.RoundToInt(GetComponent(v, components[0])),
                Mathf.RoundToInt(GetComponent(v, components[1]))
                );
        }

        public static IntVector2 SwizzleIntVector2(this IntVector4 v, string components)
        {
            if (components.Length != 2)
            {
                throw new InvalidNumberOfComponentsException<IntVector2>(components);
            }

            return new IntVector2(
                Mathf.RoundToInt(GetComponent(v, components[0])),
                Mathf.RoundToInt(GetComponent(v, components[1]))
                );
        }

        public static Vector3 SwizzleVector3(this Vector2 v, string components)
        {
            if (components.Length != 3)
            {
                throw new InvalidNumberOfComponentsException<Vector3>(components);
            }

            return new Vector3(
                GetComponent(v, components[0]),
                GetComponent(v, components[1]),
                GetComponent(v, components[2])
                );
        }

        public static Vector3 SwizzleVector3(this IntVector2 v, string components)
        {
            if (components.Length != 3)
            {
                throw new InvalidNumberOfComponentsException<Vector3>(components);
            }

            return new Vector3(
                GetComponent(v, components[0]),
                GetComponent(v, components[1]),
                GetComponent(v, components[2])
                );
        }

        public static Vector3 SwizzleVector3(this Vector3 v, string components)
        {
            if (components.Length != 3)
            {
                throw new InvalidNumberOfComponentsException<Vector3>(components);
            }

            return new Vector3(
                GetComponent(v, components[0]),
                GetComponent(v, components[1]),
                GetComponent(v, components[2])
                );
        }

        public static Vector3 SwizzleVector3(this IntVector3 v, string components)
        {
            if (components.Length != 3)
            {
                throw new InvalidNumberOfComponentsException<Vector3>(components);
            }

            return new Vector3(
                GetComponent(v, components[0]),
                GetComponent(v, components[1]),
                GetComponent(v, components[2])
                );
        }

        public static Vector3 SwizzleVector3(this Vector4 v, string components)
        {
            if (components.Length != 3)
            {
                throw new InvalidNumberOfComponentsException<Vector3>(components);
            }

            return new Vector3(
                GetComponent(v, components[0]),
                GetComponent(v, components[1]),
                GetComponent(v, components[2])
                );
        }

        public static Vector3 SwizzleVector3(this IntVector4 v, string components)
        {
            if (components.Length != 3)
            {
                throw new InvalidNumberOfComponentsException<Vector3>(components);
            }

            return new Vector3(
                GetComponent(v, components[0]),
                GetComponent(v, components[1]),
                GetComponent(v, components[2])
                );
        }

        public static IntVector3 SwizzleIntVector3(this Vector2 v, string components)
        {
            if (components.Length != 3)
            {
                throw new InvalidNumberOfComponentsException<IntVector3>(components);
            }

            return new IntVector3(
                Mathf.RoundToInt(GetComponent(v, components[0])),
                Mathf.RoundToInt(GetComponent(v, components[1])),
                Mathf.RoundToInt(GetComponent(v, components[2]))
                );
        }

        public static IntVector3 SwizzleIntVector3(this IntVector2 v, string components)
        {
            if (components.Length != 3)
            {
                throw new InvalidNumberOfComponentsException<IntVector3>(components);
            }

            return new IntVector3(
                GetComponent(v, components[0]),
                GetComponent(v, components[1]),
                GetComponent(v, components[2])
                );
        }

        public static IntVector3 SwizzleIntVector3(this Vector3 v, string components)
        {
            if (components.Length != 3)
            {
                throw new InvalidNumberOfComponentsException<IntVector3>(components);
            }

            return new IntVector3(
                Mathf.RoundToInt(GetComponent(v, components[0])),
                Mathf.RoundToInt(GetComponent(v, components[1])),
                Mathf.RoundToInt(GetComponent(v, components[2]))
                );
        }

        public static IntVector3 SwizzleIntVector3(this IntVector3 v, string components)
        {
            if (components.Length != 3)
            {
                throw new InvalidNumberOfComponentsException<IntVector3>(components);
            }

            return new IntVector3(
                GetComponent(v, components[0]),
                GetComponent(v, components[1]),
                GetComponent(v, components[2])
                );
        }

        public static IntVector3 SwizzleIntVector3(this Vector4 v, string components)
        {
            if (components.Length != 3)
            {
                throw new InvalidNumberOfComponentsException<IntVector3>(components);
            }

            return new IntVector3(
                Mathf.RoundToInt(GetComponent(v, components[0])),
                Mathf.RoundToInt(GetComponent(v, components[1])),
                Mathf.RoundToInt(GetComponent(v, components[2]))
                );
        }

        public static IntVector3 SwizzleIntVector3(this IntVector4 v, string components)
        {
            if (components.Length != 3)
            {
                throw new InvalidNumberOfComponentsException<IntVector3>(components);
            }

            return new IntVector3(
                Mathf.RoundToInt(GetComponent(v, components[0])),
                Mathf.RoundToInt(GetComponent(v, components[1])),
                Mathf.RoundToInt(GetComponent(v, components[2]))
                );
        }

        public static Vector4 SwizzleVector4(this Vector2 v, string components)
        {
            if (components.Length != 4)
            {
                throw new InvalidNumberOfComponentsException<Vector4>(components);
            }

            return new Vector4(
                GetComponent(v, components[0]),
                GetComponent(v, components[1]),
                GetComponent(v, components[2]),
                GetComponent(v, components[3])
                );
        }

        public static Vector4 SwizzleVector4(this IntVector2 v, string components)
        {
            if (components.Length != 4)
            {
                throw new InvalidNumberOfComponentsException<Vector4>(components);
            }

            return new Vector4(
                GetComponent(v, components[0]),
                GetComponent(v, components[1]),
                GetComponent(v, components[2]),
                GetComponent(v, components[3])
                );
        }

        public static Vector4 SwizzleVector4(this Vector3 v, string components)
        {
            if (components.Length != 4)
            {
                throw new InvalidNumberOfComponentsException<Vector4>(components);
            }

            return new Vector4(
                GetComponent(v, components[0]),
                GetComponent(v, components[1]),
                GetComponent(v, components[2]),
                GetComponent(v, components[3])
                );
        }

        public static Vector4 SwizzleVector4(this IntVector3 v, string components)
        {
            if (components.Length != 4)
            {
                throw new InvalidNumberOfComponentsException<Vector4>(components);
            }

            return new Vector4(
                GetComponent(v, components[0]),
                GetComponent(v, components[1]),
                GetComponent(v, components[2]),
                GetComponent(v, components[3])
                );
        }

        public static Vector4 SwizzleVector4(this Vector4 v, string components)
        {
            if (components.Length != 4)
            {
                throw new InvalidNumberOfComponentsException<Vector4>(components);
            }

            return new Vector4(
                GetComponent(v, components[0]),
                GetComponent(v, components[1]),
                GetComponent(v, components[2]),
                GetComponent(v, components[3])
                );
        }

        public static Vector4 SwizzleVector4(this IntVector4 v, string components)
        {
            if (components.Length != 4)
            {
                throw new InvalidNumberOfComponentsException<Vector4>(components);
            }

            return new Vector4(
                GetComponent(v, components[0]),
                GetComponent(v, components[1]),
                GetComponent(v, components[2]),
                GetComponent(v, components[3])
                );
        }

        public static Vector4 SwizzleIntVector4(this Vector2 v, string components)
        {
            if (components.Length != 2)
            {
                throw new InvalidNumberOfComponentsException<Vector4>(components);
            }

            return new IntVector4(
                Mathf.RoundToInt(GetComponent(v, components[0])),
                Mathf.RoundToInt(GetComponent(v, components[1])),
                Mathf.RoundToInt(GetComponent(v, components[2])),
                Mathf.RoundToInt(GetComponent(v, components[3]))
                );
        }

        public static Vector4 SwizzleIntVector4(this IntVector2 v, string components)
        {
            if (components.Length != 2)
            {
                throw new InvalidNumberOfComponentsException<Vector4>(components);
            }

            return new IntVector4(
                GetComponent(v, components[0]),
                GetComponent(v, components[1]),
                GetComponent(v, components[2]),
                GetComponent(v, components[3])
                );
        }

        public static Vector4 SwizzleIntVector4(this Vector3 v, string components)
        {
            if (components.Length != 2)
            {
                throw new InvalidNumberOfComponentsException<Vector4>(components);
            }

            return new IntVector4(
                Mathf.RoundToInt(GetComponent(v, components[0])),
                Mathf.RoundToInt(GetComponent(v, components[1])),
                Mathf.RoundToInt(GetComponent(v, components[2])),
                Mathf.RoundToInt(GetComponent(v, components[3]))
                );
        }

        public static Vector4 SwizzleIntVector4(this IntVector3 v, string components)
        {
            if (components.Length != 2)
            {
                throw new InvalidNumberOfComponentsException<Vector4>(components);
            }

            return new IntVector4(
                GetComponent(v, components[0]),
                GetComponent(v, components[1]),
                GetComponent(v, components[2]),
                GetComponent(v, components[3])
                );
        }

        public static Vector4 SwizzleIntVector4(this Vector4 v, string components)
        {
            if (components.Length != 2)
            {
                throw new InvalidNumberOfComponentsException<Vector4>(components);
            }

            return new IntVector4(
                Mathf.RoundToInt(GetComponent(v, components[0])),
                Mathf.RoundToInt(GetComponent(v, components[1])),
                Mathf.RoundToInt(GetComponent(v, components[2])),
                Mathf.RoundToInt(GetComponent(v, components[3]))
                );
        }

        public static Vector4 SwizzleIntVector4(this IntVector4 v, string components)
        {
            if (components.Length != 2)
            {
                throw new InvalidNumberOfComponentsException<Vector4>(components);
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
