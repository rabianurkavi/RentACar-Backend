using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Core.DataAccess
{
    public interface IEntityRepository<T> where T : class, IEntity, new()
    {
        List<T> GetAll(Expression<Func<T, bool>> filter = null);//filtre=null demek filtre vermeyede bilirsin demek --burası p=>p.ProductId==2 gibi filtereler koymamıza yarıyor.
        T Get(Expression<Func<T, bool>> filter);//Tyi döndüren bir operasyon bu ve yukarısındaki ifadeye öyle bir şey tasarlamak istiyorum ki linq ile yapacağız
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);

        // List<T> GetAllByCategory(int categoryId);//ürünleri kategoriye göre filtrele (Expression<Func<T,bool>> filter) yazdıktan sonra bu koda ihtiyacımız kalmadı
    }
}
