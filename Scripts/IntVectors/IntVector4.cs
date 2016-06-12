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
using UnityEngine;

namespace senritsu.UnityGridTools.Scripts.IntVectors
{
    public struct IntVector4 : IEquatable<IntVector4>
    {
        public static IntVector4 zero = new IntVector4(0, 0, 0, 0);
        public static IntVector4 one = new IntVector4(1, 1, 1, 0);
        public static IntVector4 right = new IntVector4(1, 0, 0, 0);
        public static IntVector4 up = new IntVector4(0, 1, 0, 0);
        public static IntVector4 forward = new IntVector4(0, 0, 1, 0);
        public static IntVector4 left = new IntVector4(-1, 0, 0, 0);
        public static IntVector4 down = new IntVector4(0, -1, 0, 0);
        public static IntVector4 back = new IntVector4(0, 0, -1, 0);
        public int x, y, z, w;

        public IntVector4(int x, int y, int z, int w)
        {
            this.x = x;
            this.y = y;
            this.z = z;
            this.w = w;
        }

        public int sqrMagnitude
        {
            get { return x * x + y * y + z * z + w * w; }
        }

        public float magnitude
        {
            get { return Mathf.Sqrt(sqrMagnitude); }
        }

        public int this[int index]
        {
            get
            {
                switch (index)
                {
                    case 0:
                        return x;
                    case 1:
                        return y;
                    case 2:
                        return z;
                    case 3:
                        return w;
                    default:
                        throw new ArgumentOutOfRangeException("index", "index has to be 0 or 1 or 2 or 3");
                }
            }
            set
            {
                switch (index)
                {
                    case 0:
                        x = value;
                        break;
                    case 1:
                        y = value;
                        break;
                    case 2:
                        z = value;
                        break;
                    case 3:
                        w = value;
                        break;
                    default:
                        throw new ArgumentOutOfRangeException("index", "index has to be 0 or 1 or 2 or 3");
                }
            }
        }

        public bool Equals(IntVector4 other)
        {
            return x == other.x && y == other.y && z == other.z && w == other.w;
        }

        public void Set(int x, int y, int z, int w)
        {
            this.x = x;
            this.y = y;
            this.z = z;
            this.w = w;
        }

        public override string ToString()
        {
            return string.Format("({0}, {1}, {2}, {3})", x, y, z, w);
        }

        public static IntVector4 Scale(IntVector4 v1, IntVector4 v2)
        {
            return new IntVector4(v1.x * v2.x, v1.y * v2.y, v1.z * v2.z, v1.w * v2.w);
        }

        public static float Distance(IntVector4 v1, IntVector4 v2)
        {
            return (v1 - v2).magnitude;
        }

        public static int Dot(IntVector4 v1, IntVector4 v2)
        {
            return v1.x * v2.x + v1.y * v2.y + v1.z * v2.z + v1.w * v2.w;
        }

        public static IntVector4 Min(IntVector4 v1, IntVector4 v2)
        {
            return new IntVector4(Mathf.Min(v1.x, v2.x), Mathf.Min(v1.y, v2.y), Mathf.Min(v1.z, v2.z), Mathf.Min(v1.w, v2.w));
        }

        public static IntVector4 Max(IntVector4 v1, IntVector4 v2)
        {
            return new IntVector4(Mathf.Max(v1.x, v2.x), Mathf.Max(v1.y, v2.y), Mathf.Max(v1.z, v2.z), Mathf.Max(v1.w, v2.w));
        }

        public static IntVector4 operator +(IntVector4 v1, IntVector4 v2)
        {
            return new IntVector4(v1.x + v2.x, v1.y + v2.y, v1.z + v2.z, v1.w + v2.w);
        }

        public static IntVector4 operator -(IntVector4 v1, IntVector4 v2)
        {
            return new IntVector4(v1.x - v2.x, v1.y - v2.y, v1.z - v2.z, v1.w - v2.w);
        }

        public static IntVector4 operator -(IntVector4 v)
        {
            return new IntVector4(-v.x, -v.y, -v.z, -v.w);
        }

        public static IntVector4 operator +(IntVector4 v)
        {
            return new IntVector4(v.x, v.y, v.z, v.w);
        }

        public static IntVector4 operator *(int i, IntVector4 v)
        {
            return v * i;
        }

        public static IntVector4 operator *(IntVector4 v, int i)
        {
            return new IntVector4(v.x * i, v.y * i, v.z * i, v.w * i);
        }

        public static IntVector4 operator /(int i, IntVector4 v)
        {
            return v / i;
        }

        public static IntVector4 operator /(IntVector4 v, int i)
        {
            return new IntVector4(v.x / i, v.y / i, v.z / i, v.w / i);
        }

        public static implicit operator IntVector4(Vector2 v)
        {
            return new IntVector4(Mathf.RoundToInt(v.x), Mathf.RoundToInt(v.y), 0, 0);
        }

        public static implicit operator Vector2(IntVector4 v)
        {
            return new Vector2(v.x, v.y);
        }

        public static implicit operator Vector3(IntVector4 v)
        {
            return new Vector3(v.x, v.y, v.z);
        }

        public static implicit operator IntVector4(Vector3 v)
        {
            return new IntVector4(Mathf.RoundToInt(v.x), Mathf.RoundToInt(v.y), Mathf.RoundToInt(v.z), 0);
        }

        public static implicit operator Vector4(IntVector4 v)
        {
            return new Vector4(v.x, v.y, v.z, v.w);
        }

        public static implicit operator IntVector4(Vector4 v)
        {
            return new IntVector4(Mathf.RoundToInt(v.x), Mathf.RoundToInt(v.y), Mathf.RoundToInt(v.z), Mathf.RoundToInt(v.w));
        }

        public static implicit operator IntVector4(IntVector3 v)
        {
            return new IntVector4(v.x, v.y, v.z, 0);
        }

        public static implicit operator IntVector3(IntVector4 v)
        {
            return new IntVector3(v.x, v.y, v.z);
        }

        public static implicit operator IntVector4(IntVector2 v)
        {
            return new IntVector4(v.x, v.y, 0, 0);
        }

        public static implicit operator IntVector2(IntVector4 v)
        {
            return new IntVector2(v.x, v.y);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            return obj is IntVector4 && Equals((IntVector4)obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = x;
                hashCode = (hashCode * 397) ^ y;
                hashCode = (hashCode * 397) ^ z;
                hashCode = (hashCode * 397) ^ w;
                return hashCode;
            }
        }

        public static bool operator ==(IntVector4 first, IntVector4 second)
        {
            return first.Equals(second);
        }

        public static bool operator !=(IntVector4 first, IntVector4 second)
        {
            return !first.Equals(second);
        }
    }
}