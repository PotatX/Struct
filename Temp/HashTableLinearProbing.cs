public class HashTableLinearProbing<TKey, TValue>
{
    private int capacity;
    private int size;
    private TKey[] keys;
    private TValue[] values;
    private bool[] deleted;

    public HashTableLinearProbing(int capacity = 16)
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

    public void Insert(TKey key, TValue value)
    {
        if (size == capacity) Resize();

        int index = Hash(key);
        while (keys[index] != null && !keys[index].Equals(key) && !deleted[index])
        {
            index = (index + 1) % capacity;
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
        int startIndex = index;

        while (keys[index] != null)
        {
            if (keys[index].Equals(key) && !deleted[index])
            {
                value = values[index];
                return true;
            }

            index = (index + 1) % capacity;
            if (index == startIndex) break;
        }

        value = default(TValue);
        return false;
    }

    public bool Remove(TKey key)
    {
        int index = Hash(key);
        int startIndex = index;

        while (keys[index] != null)
        {
            if (keys[index].Equals(key) && !deleted[index])
            {
                deleted[index] = true;
                size--;
                return true;
            }

            index = (index + 1) % capacity;
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

    public static void CallLinearProb()
    {
        var hashTableLinear = new HashTableLinearProbing<string, int>();
        hashTableLinear.Insert("one", 1);
        hashTableLinear.Insert("two", 2);
        hashTableLinear.Insert("three", 3);

        if (hashTableLinear.TryGetValue("two", out int valueLinear))
        {
            Console.WriteLine($"Value for 'two' with linear probing: {valueLinear}");
        }

        hashTableLinear.Remove("two");
        if (!hashTableLinear.TryGetValue("two", out valueLinear))
        {
            Console.WriteLine($"'two' not found with linear probing");
        }
    }
}