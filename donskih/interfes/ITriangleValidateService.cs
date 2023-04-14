using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace integtest.Interfaces
{

        public interface ITriangleValidateService
    {
        bool IsAllValid(); //проверка всех треугольников на правильность
        bool IsValid(int id);   //проверка треугольника на правильность по айди
    }
}


