public class HashTableDoubleHashing<TKey, TValue>
{
    private int capacity;
    private int size;
    private TKey[] keys;
    private TValue[] values;
    private bool[] deleted;

    public HashTableDoubleHashing(int capacity = 16)
    {
        this.capacity = capacity;
        this.size = 0;
        this.keys = new TKey[capacity];
        this.values = new TValue[capacity];
        this.deleted = new bool[capacity];
    }

    private int Hash(TKey key)
    {
        return Math.Abs(key.GetHashCode()) % capacity;
    }

    private int Hash2(TKey key)
    {
        return 1 + Math.Abs(key.GetHashCode()) % (capacity - 2);
    }

    public void Insert(TKey key, TValue value)
    {
        if (size == capacity) Resize();

        int index = Hash(key);
        int stepSize = Hash2(key);
        while (keys[index] != null && !keys[index].Equals(key) && !deleted[index])
        {
            index = (index + stepSize) % capacity;
        }

        if (keys[index] == null || deleted[index])
        {
            size++;
            keys[index] = key;
            deleted[index] = false;
        }

        values[index] = value;
    }

    public bool TryGetValue(TKey key, out TValue value)
    {
        int index = Hash(key);
        int stepSize = Hash2(key);
        int startIndex = index;

        while (keys[index] != null)
        {
            if (keys[index].Equals(key) && !deleted[index])
            {
                value = values[index];
                return true;
            }

            index = (index + stepSize) % capacity;
            if (index == startIndex) break;
        }

        value = default(TValue);
        return false;
    }

    public bool Remove(TKey key)
    {
        int index = Hash(key);
        int stepSize = Hash2(key);
        int startIndex = index;

        while (keys[index] != null)
        {
            if (keys[index].Equals(key) && !deleted[index])
            {
                deleted[index] = true;
                size--;
                return true;
            }

            index = (index + stepSize) % capacity;
            if (index == startIndex) break;
        }

        return false;
    }

    private void Resize()
    {
        int newCapacity = capacity * 2;
        TKey[] oldKeys = keys;
        TValue[] oldValues = values;
        bool[] oldDeleted = deleted;

        keys = new TKey[newCapacity];
        values = new TValue[newCapacity];
        deleted = new bool[newCapacity];
        capacity = newCapacity;
        size = 0;

        for (int i = 0; i < oldKeys.Length; i++)
        {
            if (oldKeys[i] != null && !oldDeleted[i])
            {
                Insert(oldKeys[i], oldValues[i]);
            }
        }
    }

    public static void CallDoubleHashing()
    {
        var hashTableDoubleHashing = new HashTableDoubleHashing<string, int>();
        hashTableDoubleHashing.Insert("one", 1);
        hashTableDoubleHashing.Insert("two", 2);
        hashTableDoubleHashing.Insert("three", 3);

        if (hashTableDoubleHashing.TryGetValue("two", out int valueDoubleHashing))
        {
            Console.WriteLine($"Value for 'two' with double hashing: {valueDoubleHashing}");
        }

        hashTableDoubleHashing.Remove("two");
        if (!hashTableDoubleHashing.TryGetValue("two", out valueDoubleHashing))
        {
            Console.WriteLine($"'two' not found with double hashing");
        }
    }
}