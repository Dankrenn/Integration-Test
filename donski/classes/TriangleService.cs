using integtest.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Triangle;

namespace integtest.Classes
{
    public class TriangleService : ITriangleService
    {
        public bool IsValidTriangle(int a, int b, int c)
        {
            if ((a > 0 && b > 0 && c > 0) && ((a + b >= c && a + c >= b && b + c >= a)))
            {
                return true;
            }
            else
                return false;

        }


        public TriangleType GetType(int a, int b, int c)
        {
            TriangleType triangleType;
            double r = (Math.Pow(a, 2) + Math.Pow(c, 2) - Math.Pow(b, 2)) / (2 * a * c);
            double z = (Math.Pow(a, 2) + Math.Pow(b, 2) - Math.Pow(c, 2)) / (2 * a * b);
            double y = (Math.Pow(b, 2) + Math.Pow(c, 2) - Math.Pow(a, 2)) / (2 * c * b);

            if ((a * a + b * b == c * c) || (a * a + c * c == b * b) || (c * c + b * b == a * a))
            {
                if ((a == b) || (a == c) || (b == c))
                {
                    triangleType = TriangleType.Isosceles | TriangleType.Rectangular;// прямоугольный,равнобедренный
                    return triangleType;
                }
                else
                {
                    triangleType = TriangleType.Scalene | TriangleType.Rectangular;// прямоугольный,неравносторонний
                    return triangleType;
                }

            }
            if ((a == b) || (a == c) || (b == c))
            {
                if ((a == b) && (a == c) && (b == c))
                {
                    triangleType = TriangleType.Equilateral | TriangleType.Oxygon; // равносторонний,остроугольный.
                    return triangleType;

                }
                else
                {
                    if (1 > r && r > 0 && 1 > z && z > 0 && 1 > y && y > 0)
                    {
                        triangleType = TriangleType.Isosceles | TriangleType.Oxygon; //равнобедренный,остроугольный.
                        return triangleType;

                    }
                    else
                    {
                        triangleType = TriangleType.Isosceles | TriangleType.Obtuse; //равнобедренный,тупоугольный.
                        return triangleType;
                    }
                }
            }
            else
            {
                if (1 > r && r > 0 && 1 > z && z > 0 && 1 > y && y > 0)
                {
                    triangleType = TriangleType.Scalene | TriangleType.Oxygon; //неравносторонний,остроугольный.
                    return triangleType;
                }
                else
                {
                    triangleType = TriangleType.Scalene | TriangleType.Obtuse; //неравносторонний,тупоугольный.
                    return triangleType;
                }

            }

        }
        public double GetArea(double a, double b, double c)
        {
            double P = (a + b + c) / 2;
            double area = Math.Sqrt(P * (P - a) * (P - b) * (P - c));
            return area;
        }

    }
}