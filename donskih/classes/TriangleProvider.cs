using integtest.Interfaces;
using System.Collections.Generic;
using System.Linq;



namespace integtest.Classes
{

    public class TriangleProvider : ITriangleProvider
    {
        public List<Triangle> GettAll()
        {
            List<Triangle> list;
            using (var context = new ApplicationContext())
            {
                list = context.triangle.ToList();
            }
            return list;
        }
        public Triangle GetById(int id)
        {
            Triangle triangle;
            using (var context = new ApplicationContext())
            {
                triangle = context.triangle.Find(id);
            }
            return triangle;
        }
        public void Save(Triangle triangle)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                db.triangle.Add(triangle);
                db.SaveChanges();
            }
        }
        public void Update(Triangle triangle)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                db.triangle.Update(triangle);
                db.SaveChanges();
            }
        }
    }
}

