using Algorithms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests
{
    public class LruCacheTests
    {

        [Fact]
        public void LruCachetests()
        {
            LruCache lruCache = new LruCache(2);
            lruCache.Put(1, 1);     // cache is {1=1}
            lruCache.Put(2, 2);     // cache is {1=1, 2=2}
            
            int getResult = lruCache.Get(1);        // return 1
            Assert.Equal(1, getResult);
            
            lruCache.Put(3, 3);     // LRU key was 2, evicts key 2, cache is {1=1, 3=3}
            
            getResult = lruCache.Get(2);        // returns -1 (not found)
            Assert.Equal(-1, getResult);
            
            lruCache.Put(4, 4);     // LRU key was 1, evicts key 1, cache is {4=4, 3=3}

            getResult = lruCache.Get(1);        // return -1 (not found)
            Assert.Equal(-1, getResult);

            getResult = lruCache.Get(3);        // return 3
            Assert.Equal(3, getResult);

            getResult = lruCache.Get(4);        // return 4
            Assert.Equal(4, getResult);
        }
    }
}
