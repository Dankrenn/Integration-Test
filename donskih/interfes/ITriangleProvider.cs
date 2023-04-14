using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace integtest.Interfaces
{
    public interface ITriangleProvider
    {
        Triangle GetById(int id); //ВЫТЯГИВАЕТ ТРЕУГОЛНИК ИЗ БАЗЫ ПО АЙДИ
        List<Triangle> GettAll(); //ВЫТЯГИВАЕТ ВСЕ ТРЕУГОЛНИКИ ИЗ БАЗЫ 
        void Save(Triangle triangle);  //СОХРАНЯЕТ ТРЕУГОЛЬНИК В БАЗУ
        void Update(Triangle triangle); //ОБНОВЛЯЕТ ТРЕУГОЛЬНИК В БАЗЕ 
    }
}
