using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Донских_4_финал.Интерфейсы
{
    public interface ITriangleValidateService
    {
        bool IsAllValid(); //проверка всех треугольников на правильность
        bool IsValid(int id);   //проверка треугольника на правильность по айди
    }
}


