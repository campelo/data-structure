namespace HashTable;

public class HashTableService
{
    int _capacity;
    Node[] _items;
    
    public HashTableService(int max)
    {
        _capacity = max;
        _items = new Node[max];
    }

    public void AddWordsFromText(string text)
    {
        AddInArray(text, _items);
    }

    private void AddInArray(string text, Node[] items)
    {
        string[] words = text.Split(' ');
        AddRange(words, items);
    }

    public void AddRange(IEnumerable<string> values)
    {
        AddRange(values, _items);
    }

    private void AddRange(IEnumerable<string> values, Node[] items)
    {
        foreach (string word in values)
        {
            int hash = CalculateHash(word);
            AddInArray(hash, word, items);
        }
    }

    public bool HasAllWords(string text)
    {
        return HasAllWords(text.Split(' '));
    }

    public bool HasAllWords(IEnumerable<string> values)
    {
        Node[] temp = new Node[_capacity];
        AddRange(values, temp);
        for(int i = 0; i < temp.Length; i++)
        {
            if(!HasEnoughItems(temp[i], i))
                return false;
        }
        return true;
    }

    private bool HasEnoughItems(Node item, int hash)
    {
        if (item == null)
            return true;
        Node ori = FindInArray(_items[hash], item.Value);
        if (ori == null)
            return false;
        if (ori.Count < item.Count)
            return false;
        if (item.Next == null)
            return true;
        return HasEnoughItems(item.Next, hash);
    }

    private void AddInArray(int indexPosition, string word, Node[] items)
    {
        Node newNode = new (word);
        if (items[indexPosition] == null)
        {
            items[indexPosition] = newNode;
            return;
        }
        AddToLinkedList(items[indexPosition], newNode);        
    }

    private void AddToLinkedList(Node current, Node newNode)
    {
        if (current.Value == newNode.Value)
        {
            current.Count++;
            return;
        }
        if (current.Next == null)
        {
            current.Next = newNode;
            return;
        }
        AddToLinkedList(current.Next, newNode);
    }

    private Node Find(string word)
    {
        int hash = CalculateHash(word);
        return FindInArray(_items[hash], word);
    }

    private Node FindInArray(Node node, string word)
    {
        if (node == null)
            return null;
        if (node.Value == word)
            return node;
        return FindInArray(node.Next, word);
    }

    private int CalculateHash(string word)
    {
        int calculated = 0;
        foreach(char c in word)
            calculated += c;
        return calculated % _capacity;
    }
}

public class Node
{
    public Node(string value)
    {
        Value = value;
        Count = 1;
    }
    public string Value { get; set; }
    public int Count { get; set; }
    public Node Next;
    public Node Prev;
}