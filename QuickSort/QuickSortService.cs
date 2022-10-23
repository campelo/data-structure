
namespace QuickSort;

public static class QuickSortService
{
    public static void Sort(int[] items, int startIndex, int endIndex)
    {
        if (startIndex >= endIndex)
            return;
        var i = startIndex;
        var j = endIndex;
        var pivot = items[startIndex];

        while (i <= j)
        {
            while (items[i] < pivot)
                i++;
            while (items[j] > pivot)
                j--;
            if (i <= j)
            {
                if (i < j)
                {
                    int temp = items[i];
                    items[i] = items[j];
                    items[j] = temp;
                }
                i++;
                j--;
            }
        }

        if (j > startIndex)
            Sort(items, startIndex, j);
        if (i < endIndex)
            Sort(items, i, endIndex);
    }
}