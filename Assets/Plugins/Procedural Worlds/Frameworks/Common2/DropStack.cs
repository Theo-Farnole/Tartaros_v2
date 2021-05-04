using UnityEngine;
using System;
using System.Collections.Generic;

namespace PWCommon2
{
    /// <summary>
    /// A limited size stack where the oldest items start "falling out at the bottom"
    /// when more items are added after the <see cref="Capacity"/> was reached.
    /// DO make sure that the content is serializable by unity if you want the stack to be serialized.
    /// </summary>
    [Serializable]
    public class DropStack<T> : System.Object, ISerializationCallbackReceiver
    {
        [NonSerialized] protected T[] m_items;
        [SerializeField] protected int m_topIndex = 0;
        [SerializeField] protected int m_count = 0;

        // Used only by serialisation
        [SerializeField] protected bool _nullableType = false;
        [SerializeField] private int _capacity = 0;
        [SerializeField] private T[] _activeItems;

        /// <summary>
        /// The max capacity of the stack.
        /// </summary>
        public int Capacity { get { return m_items.Length; } }

        /// <summary>
        /// The count of the items currently stored in the stack.
        /// </summary>
        public int Count { get { return m_count; } }

        /// <summary>
        /// Only used internally for all constructions.
        /// </summary>
        private DropStack()
        {
            if (default(T) == null)
            {
                _nullableType = true;
            }
        }

        /// <summary>
        /// Create a new drop stack.
        /// DO make sure that the content is serializable by unity if you want the stack to be serialized.
        /// </summary>
        /// <param name="capacity">Max capacity of the stack.</param>
        public DropStack(int capacity) : this()
        {
            m_items = new T[capacity];
            m_count = 0;
        }

        /// <summary>
        /// Create a new drop stack and fill it with items from a List (in reverse order).
        /// DO make sure that the content is serializable by unity if you want the stack to be serialized.
        /// </summary>
        /// <param name="capacity">Max capacity of the stack.</param>
        public DropStack(int capacity, List<T> items) : this()
        {
            m_items = new T[capacity];
            m_count = Mathf.Clamp(items.Count, 0, capacity);

			for (int i = m_count - 1; i >= 0; i--)
			{
				m_items[m_topIndex] = items[i];
				m_topIndex = (m_topIndex + 1) % m_items.Length;
			}
        }

        /// <summary>
        /// Create a new drop stack and fill it with items from an Array (in reverse order).
        /// DO make sure that the content is serializable by unity if you want the stack to be serialized.
        /// </summary>
        /// <param name="capacity">Max capacity of the stack.</param>
        public DropStack(int capacity, T[] items) : this()
        {
            m_items = new T[capacity];
			m_count = Mathf.Clamp(items.Length, 0, capacity);

			for (int i = m_count - 1; i >= 0; i--)
			{
				m_items[m_topIndex] = items[i];
				m_topIndex = (m_topIndex + 1) % m_items.Length;
			}
		}

        /// <summary>
        /// Push an <paramref name="item"/> to the stack.
        /// DO make sure that the <paramref name="item"/> is serializable by unity if you want the stack to be serialized.
        /// </summary>
        public void Push(T item)
        {
            m_items[m_topIndex] = item;
            m_topIndex = (m_topIndex + 1) % m_items.Length;
            m_count = m_count >= m_items.Length ? m_items.Length : m_count + 1;
        }

        /// <summary>
        /// Push a bunch of <paramref name="items"/> to the stack.
        /// They will be pushed in a forward order, same as stepping through an array.
        /// DO make sure that the <paramref name="items"/> are serializable by unity if you want the stack to be serialized.
        /// </summary>
        public void Push(IEnumerable<T> items)
        {
            foreach (T item in items)
            {
                Push(item);
            }
        }

        /// <summary>
        /// Pops an item from the stack and returns it.
        /// </summary>
        public T Pop()
        {
            m_topIndex = (m_items.Length + m_topIndex - 1) % m_items.Length;
            m_count = m_count < 2 ? 0 : m_count - 1;
            // Clean up - could be particularly important on nullable types
            T item = m_items[m_topIndex];
            m_items[m_topIndex] = default(T);
            return item;
        }

        /// <summary>
        /// Peeks the top item without popping it from the stack and returns it.
        /// </summary>
        public T Peek()
        {
            return m_items[(m_items.Length + m_topIndex - 1) % m_items.Length];
        }

		/// <summary>
		/// Converts the Stack to a List.
		/// </summary>
		public List<T> ToList()
		{
			List<T> list = new List<T>();
			int i = m_topIndex;
			int count = m_count;

			while(count > 0)
			{
				i = (m_items.Length + i - 1) % m_items.Length;
				count = count < 2 ? 0 : count - 1;
				list.Add(m_items[i]);
			}

			return list;
		}

		/// <summary>
		/// Converts the Stack to an Array.
		/// </summary>
		public T[] ToArray()
		{
			T[] array = new T[m_count];
			int topIndex = m_topIndex;

			for (int i = 0; i < m_count; i++)
			{
				topIndex = (m_items.Length + topIndex - 1) % m_items.Length;
				array[i] = m_items[topIndex];
			}

			return array;
        }

        #region Custom Serialization

        /// <summary>
        /// OnBeforeSerialize
        /// </summary>
        public void OnBeforeSerialize()
        {
            // Only need to do this with nullable types
            if (!_nullableType)
            {
                _activeItems = m_items;
                return;
            }

            _capacity = Capacity;
            _activeItems = ToArray();
        }

        /// <summary>
        /// OnAfterDeserialize
        /// </summary>
        public void OnAfterDeserialize()
        {
            // Only need to do this with nullable types
            if (!_nullableType)
            {
                m_items = _activeItems;
                return;
            }

            m_items = new T[_capacity];
            for (int i = 0; i < m_count; i++)
            {
                m_items[i] = _activeItems[i];
            }
            m_topIndex = m_count;
        }

        #endregion
    }
}