namespace Heap;

public class MinHeap
{
    private long[] _items = new long[100000];
    private int _length = 0;
    public int Length => _length;
    public bool IsEmpty => _length == 0;

    public void Add(int value)
    {
        _items[Length] = value;
        _length++;
        RecursiveAddingSwap(Length);
    }

    public long Minimum => IsEmpty ? 0 : _items[0];

    private void RecursiveAddingSwap(int elementPosition)
    {
        int elementIndex = elementPosition - 1;
        if (elementIndex <= 0)
            return;
        int parentIndex = (elementPosition / 2) - 1;
        if (_items[parentIndex] > _items[elementIndex])
        {
            Swap(elementIndex, parentIndex);
            RecursiveAddingSwap(parentIndex + 1);
        }
    }

    private void Swap(int firstIndex, int secondIndex)
    {
        long temp = _items[secondIndex];
        _items[secondIndex] = _items[firstIndex];
        _items[firstIndex] = temp;
    }

    public long[] Array => _items.ToArray();

    public void Pop()
    {
        Remove(Minimum);
    }

    public void Remove(long value)
    {
        if (IsEmpty)
            return;
        int index = 0;
        for(int i = 0; i < _length; i++)
        {
            if (_items[i] == value)
            {
                index = i;
                break;
            }
        }
        _length--;
        Swap(index, _length);
        RecursiveRemovingSwap(index + 1);
    }

    private void RecursiveRemovingSwap(int elementPosition)
    {
        int elementIndex = elementPosition - 1;
        int firstChildIndex = (2 * elementPosition) - 1;
        int secondChildIndex = firstChildIndex + 1;
        int lessIndex = elementIndex;
        if (secondChildIndex < _length)
            lessIndex = _items[secondChildIndex] < _items[firstChildIndex] ? secondChildIndex : firstChildIndex;
        else if (firstChildIndex < _length)
            lessIndex = _items[firstChildIndex] < _items[elementIndex] ? firstChildIndex : elementIndex;
        if (lessIndex < _length && lessIndex != elementIndex)
        {
            Swap(elementIndex, lessIndex);
            RecursiveRemovingSwap(lessIndex + 1);
        }
    }
}