using System;
using System.Collections.Generic;
using System.Text;

namespace Core.CrossCuttingConcerns.Caching
{
    public interface ICacheManager
    {
        T Get<T>(string key);//key verip karşılığında bellekten o keyekarşılık gelen datayı alıyorum.
        object Get(string key);//generic olmayan kısım
        void Add(string key, object value, int duration);//duration=cache de ne kadar duracak?
        bool IsAdd(string key);//varlığını kontrol etme
        void Remove(string key);
        void RemoveByPattern(string pattern);
    }
}
