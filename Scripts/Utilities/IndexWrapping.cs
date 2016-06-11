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
using senritsu.UnityGridTools.Scripts.IntVectors;

namespace Assets.UnityGridTools.Scripts.Utilities
{
    public static class IndexWrapping
    {
        private static int PositiveMod(int a, int b)
        {
            return a < 0
                ? a % b + b
                : a % b;
        }

        private static int WrapCoordinate(int coordinate, int min, int max)
        {
            return PositiveMod(coordinate - min, max - min + 1) + min;
        }

        public static Func<IntVector3, IntVector3> WrapX(int min, int max)
        {
            return i => new IntVector3(
                    WrapCoordinate(i.x, min, max),
                    i.y,
                    i.z);
        }

        public static Func<IntVector3, IntVector3> WrapY(int min, int max)
        {
            return i => new IntVector3(
                    i.x,
                    WrapCoordinate(i.y, min, max),
                    i.z);
        }

        public static Func<IntVector3, IntVector3> WrapZ(int min, int max)
        {
            return i => new IntVector3(
                    i.x,
                    i.y,
                    WrapCoordinate(i.z, min, max));
        }

        public static Func<IntVector2, IntVector2> WrapAll(IntVector2 min, IntVector2 max)
        {
            return i => new IntVector2(
                WrapCoordinate(i.x, min.x, max.x),
                WrapCoordinate(i.y, min.y, max.y));
        }

        public static Func<IntVector3, IntVector3> WrapAll(IntVector3 min, IntVector3 max)
        {
            return i => new IntVector3(
                WrapCoordinate(i.x, min.x, max.x),
                WrapCoordinate(i.y, min.y, max.y),
                WrapCoordinate(i.z, min.z, max.z));
        }
    }
}