using Core.Utilities.IoC;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Core.CrossCuttingConcerns.Caching.Microsoft
{
    public class MemoryCacheManager : ICacheManager
    {




        IMemoryCache _memoryCache;               // Bu _memoryCache i kullanarak işlemlerimizi yapıyor olacağız.

        public MemoryCacheManager()                 // Biz aslında CoreModule daki serviceCollection.AddMemoryCache kodu ile memoryCache instance oluşuyor. Biz o instance ı enjecte edicez.
        {
            _memoryCache = ServiceTool.ServiceProvider.GetService<IMemoryCache>();
        }


        public void Add(string key, object value, int duration)
        {
            _memoryCache.Set(key, value, TimeSpan.FromMinutes(10));                   // Set ile cache değer ekleyebiliyoruz. Bize uyan ikinci overload ı. key anahtarını, value yu, ve durationu veriyor olmalıyız.
        }                                                  // duration ı veriyor olmalıyız. Ama burda ne zaman expire olacak.Expire olmak demek bellekten ne zaman uçurulacak. TimeSpan türünde istiyor. TimeSpan zaman aralığı demek.  

        public T Get<T>(string key)
        {
            return _memoryCache.Get<T>(key);
        }

        public object Get(string key)
        {
            return _memoryCache.Get(key);
        }


        public bool IsAdd(string key)
        {
            return _memoryCache.TryGetValue(key, out _);
        }

        public void Remove(string key)
        {
            _memoryCache.Remove(key);
        }

        public void RemoveByPattern(string pattern)        // Ona verdiğimiz bir pattern e göre silme işlemini yapıcak. Çalışma anında bellekten silmeye yarıyor.
        {
            var cacheEntriesCollectionDefinition = typeof(MemoryCache).GetProperty("EntriesCollection", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
            var cacheEntriesCollection = cacheEntriesCollectionDefinition.GetValue(_memoryCache) as dynamic;
            List<ICacheEntry> cacheCollectionValues = new List<ICacheEntry>();

            foreach (var cacheItem in cacheEntriesCollection)
            {
                ICacheEntry cacheItemValue = cacheItem.GetType().GetProperty("Value").GetValue(cacheItem, null);
                cacheCollectionValues.Add(cacheItemValue);
            }

            var regex = new Regex(pattern, RegexOptions.Singleline | RegexOptions.Compiled | RegexOptions.IgnoreCase);
            var keysToRemove = cacheCollectionValues.Where(d => regex.IsMatch(d.Key.ToString())).Select(d => d.Key).ToList();

            foreach (var key in keysToRemove)
            {
                _memoryCache.Remove(key);
            }
        }

    }
}
