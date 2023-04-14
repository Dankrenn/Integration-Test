using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Triangle;

namespace integtest.Interfaces
{
    public interface ITriangleService
    {
        bool IsValidTriangle(int a, int b, int c); //ОПРЕДЕЛЯЕТ ВОЗМОЖЕН ЛИ ТРЕУГОЛЬНИК С ДАННЫМИ ТРЕМЯ СТОРОНАМИ
        TriangleType GetType(int a, int b, int c); //ОПРЕДЕЛЯЕТ ТИП ТРЕУГОЛЬНИКА
        double GetArea(double a, double b, double c); //ОПРЕДЕЛЯЕТ ПЛОЩАДЬ
    }
}
