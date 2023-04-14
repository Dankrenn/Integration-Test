using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Triangle
{
    [Flags] //ПОЗВОЛЯЕТ ИСПОЛЬЗОВАТЬ НЕСКОЛЬКО ЭНАМОВ
    public enum TriangleType
    {

        Oxygon = 1, //Остроугольный

        Obtuse = 2, //Тупоугольный

        Rectangular = 4, //Прямоугольный

        Scalene = 8, //Неравносторонний

        Isosceles = 16, //Равнобедренный

        Equilateral = 32 //Равносторонний
    }

    public int id { get; set; }
    public int a { get; set; }
    public int b { get; set; }
    public int c { get; set; }
    public double area { get; set; }
    public TriangleType type { get; set; }
    public bool isvalid { get; set; }

    public Triangle()
    {

    }
    public Triangle(int id, int a, int b, int c, double area, TriangleType type, bool isvalid)
    {
        this.a = a;
        this.b = b;
        this.c = c;
        this.type = type;
        this.area = area;
        this.isvalid = isvalid;
    }
}