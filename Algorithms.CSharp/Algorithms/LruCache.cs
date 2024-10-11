using System;
using System.Buffers.Text;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Algorithms
{
    /// <summary>
    /// Design a data structure that follows the constraints of a Least Recently Used (LRU) cache.
    /// Implement the LRUCache class:
    /// LRUCache(int capacity) Initialize the LRU cache with positive size capacity.
    /// int get(int key) Return the value of the key if the key exists, otherwise return -1.
    /// void put(int key, int value) Update the value of the key if the key exists.Otherwise, add the key-value pair to the cache.If the number of keys exceeds the capacity from this operation, evict the least recently used key.
    /// The functions get and put must each run in O(1) average time complexity.
    /// 
    /// # Solution:
    /// > Intuition
    ///     The intuition behind the LRUCache implementation is to use a combination of a dictionary and a linked list to efficiently store and manage the cache items.
    ///     The dictionary provides fast access to cache items based on their keys (in O(1))
    ///     The linked list maintains the order of recently used items (for constant-time updates on most recently used and least recently used elements).
    /// > Approach:
    ///     The approach involves using a dictionary(_cacheMap) to store the cache items, where the key is the item's key and the value is a reference to the corresponding node in the linked list. The linked list (_cacheLinkedList) keeps track of the order of the items, with the most recently used item at the front of the list.
    ///     When performing a Get operation, the implementation checks if the key exists in the dictionary.If it does, the corresponding node is moved to the front of the linked list (representing the most recently used item) and its value is returned.If the key is not found, -1 is returned.
    ///     When performing a Put operation, the implementation first checks if the key already exists in the cache.If it does, the corresponding node is updated with the new value, moved to the front of the linked list, and no additional space is used.If the key is not found, the implementation checks if the cache has reached its capacity.If it has, the least recently used item (at the end of the linked list) is removed from both the dictionary and the linked list.Then, a new node is created with the given key and value, added to the front of the linked list, and added to the dictionary for future access.
    ///     
    /// > Complexity
    /// Time complexity:
    ///     The time complexity of the Get and Put operations is O(1) on average since dictionary lookups, linked list operations(addition, removal), and updating the cache map all have constant time complexity.
    /// Space complexity:
    ///     The space complexity is O(capacity) since the cache size is limited by the given capacity parameter, and both the dictionary and the linked list store the cache items.
    /// </summary>
    public class LruCache
    {
        private readonly Dictionary<int, LinkedListNode<(int Key, int Value)>> _cacheMap;
        private readonly int _capacity;
        private readonly LinkedList<(int Key, int Value)> _cacheLinkedList;

        public LruCache(int capacity)
        {
            _capacity = capacity;
            _cacheMap = new Dictionary<int, LinkedListNode<(int Key, int Value)>>(capacity);
            _cacheLinkedList = new LinkedList<(int Key, int Value)>();
        }

        public int Get(int key)
        {
            if (_cacheMap.TryGetValue(key, out var node))
            {
                // Move the accessed item to the front (most recently used)
                _cacheLinkedList.Remove(node);
                _cacheLinkedList.AddFirst(node);

                return node.Value.Value;
            }

            return -1;
        }

        public void Put(int key, int value)
        {
            if (_cacheMap.TryGetValue(key, out var node))
            {
                // Update node value and move to the front of the list
                node.Value = (key, value);
                _cacheLinkedList.Remove(node);
                _cacheLinkedList.AddFirst(node);
            }
            else
            {
                // Check eviction policy
                if (_cacheMap.Count == _capacity)
                {
                    // Evict the least recently used item (last in the list)
                    var lastNode = _cacheLinkedList.Last;
                    _cacheMap.Remove(lastNode.Value.Key);
                    _cacheLinkedList.RemoveLast();
                }

                // Add new item to the front of the list
                var newNode = new LinkedListNode<(int Key, int Value)>((key, value));
                
                
                _cacheMap.Add(key, newNode);
                _cacheLinkedList.AddFirst(newNode);
            }
        }
    }
}
