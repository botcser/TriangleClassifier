using System;
using System.Collections.Generic;
using static System.Math;

namespace TriangleClassifier
{
    public static class TriangleClassifier
    {
        public static void ClassifyTriangle(float length1, float length2, float length3)
        {
            if (!Validate(length1, length2, length3))
            {
                Console.WriteLine("ERROR: EINVAL\nPlease come again.");

                return;
            }
            
            if (length1.Equals(length2) && length1.Equals(length3))
            {
                Console.WriteLine("Sharp triangle");

                return;
            }

            var length1Quad = length1 * length1;
            var length2Quad = length2 * length2;
            var length3Quad = length3 * length3;

            if (IsPerpendicularTriangle(length1Quad, length2Quad, length3Quad))
            {
                Console.WriteLine("Perpendicular triangle");

                return;
            }

            if (IsDumbTriangle(length1Quad, length2Quad, length3Quad))
            {
                Console.WriteLine("Dumb triangle");

                return;
            }

            Console.WriteLine("Sharp triangle");
        }

        private static bool IsDumbTriangle(float length1Quad, float length2Quad, float length3Quad)
        {
            var maxQuad = Max(Max(length1Quad, length2Quad), length3Quad);
            var bag = new List<float>(){ length1Quad, length2Quad, length3Quad };

            bag.Remove(maxQuad);

            return bag[0] + bag[1] < maxQuad;
        }

        private static bool IsPerpendicularTriangle(float length1Quad, float length2Quad, float length3Quad)
        {
            return (length1Quad + length2Quad).Equals(length3Quad) || (length1Quad + length3Quad).Equals(length2Quad) || (length2Quad + length3Quad).Equals(length1Quad);
        }

        private static bool Validate(float length1, float length2, float length3)
        {
            if (length1 <= 0 || length2 <= 0 || length3 <= 0)
            {
                return false;
            }

            return (length1 + length2) > length3 && (length1 + length3) > length2 && (length3 + length2) > length1;
        }
    }
}
