public class HashTableChaining<TKey, TValue>
{
    private int capacity;
    private List<KeyValuePair<TKey, TValue>>[] table;

    public HashTableChaining(int capacity = 16)
    {
        this.capacity = capacity;
        this.table = new List<KeyValuePair<TKey, TValue>>[capacity];
        for (int i = 0; i < capacity; i++)
        {
            table[i] = new List<KeyValuePair<TKey, TValue>>();
        }
    }

    private int Hash(TKey key)
    {
        return Math.Abs(key.GetHashCode()) % capacity;
    }

    public void Insert(TKey key, TValue value)
    {
        int index = Hash(key);
        for (int i = 0; i < table[index].Count; i++)
        {
            if (table[index][i].Key.Equals(key))
            {
                table[index][i] = new KeyValuePair<TKey, TValue>(key, value); // Update value
                return;
            }
        }

        table[index].Add(new KeyValuePair<TKey, TValue>(key, value)); // Insert new key-value pair
    }

    public bool TryGetValue(TKey key, out TValue value)
    {
        int index = Hash(key);
        foreach (var pair in table[index])
        {
            if (pair.Key.Equals(key))
            {
                value = pair.Value;
                return true;
            }
        }

        value = default(TValue);
        return false;
    }

    public bool Remove(TKey key)
    {
        int index = Hash(key);
        for (int i = 0; i < table[index].Count; i++)
        {
            if (table[index][i].Key.Equals(key))
            {
                table[index].RemoveAt(i);
                return true;
            }
        }

        return false;
    }

    public static void CallHashTableChaining()
    {
        var hashTableChaining = new HashTableChaining<string, int>();
        hashTableChaining.Insert("one", 1);
        hashTableChaining.Insert("two", 2);
        hashTableChaining.Insert("three", 3);

        if (hashTableChaining.TryGetValue("two", out int value))
        {
            Console.WriteLine($"Value for 'two': {value}");
        }

        hashTableChaining.Remove("two");
        if (!hashTableChaining.TryGetValue("two", out value))
        {
            Console.WriteLine($"'two' not found");
        }
    }
}