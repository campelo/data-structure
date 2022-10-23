namespace Huffman;

public class HuffmanService
{
    private Node Root;
    private string text;

    public HuffmanService(string text)
    {
        this.text = text;
        FillRoot();
    }

    public string Encode()
    {
        string result = string.Empty;
        foreach(char c in text)
            result += Root.FindCode(c, Root);

        return result;
    }

    public string Decode(string encodedText)
    {
        string result = String.Empty;
        int i = 0;
        while(i < encodedText.Length)
        {
            result += Root.FindChar(encodedText, ref i, Root);
            i++;
        }
        return result;
    }

    private void FillRoot()
    {
        Dictionary<char, int> chars = new();
        foreach (char c in text)
        {
            if (!chars.ContainsKey(c))
                chars.Add(c, 0);
            chars[c]++;
        }
        Stack<Node> nodes = new(chars
            .OrderByDescending(x => x.Value)
            .Select(x => new Node() { Char = x.Key, Frequency = x.Value }));
        while (nodes.Count > 1)
        {
            var left = nodes.Pop();
            var right = nodes.Pop();
            Node node = new Node()
            {
                Char = '*',
                Frequency = left.Frequency + right.Frequency,
                Left = left,
                Right = right
            };
            nodes.Push(node);
        }
        Root = nodes.FirstOrDefault();
    }
}

public class Node
{
    public char Char { get; set; }
    public int Frequency { get; set; }
    public Node Left { get; set; }
    public Node Right { get; set; }

    public string FindCode(char value, Node node)
    {
        string result = string.Empty;
        if(node.Right == null && node.Left == null)
            return result;
        if (node.Right.Char == value)
            return "1";
        if (node.Left.Char == value)
            return "0";
        result += "0";
        result += FindCode(value, node.Left);
        return result;
    }

    public char FindChar(string value, ref int index, Node node)
    {
        if (node.Left == null)
            return node.Char;
        if (value[index] == '1')
            return node.Right.Char;
        index++;
        return FindChar(value, ref index, node.Left);
    }
}
