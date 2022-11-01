namespace Dynamic
{
    public static class SumNumber
    {
        public static bool CanSum(int num, int[] values, Dictionary<int, bool> acc = null)
        {
            if (acc == null)
                acc = new();
            if (acc.ContainsKey(num))
                return acc[num];
            if (num == 0)
                return true;
            if (num < 0)
                return false;
            foreach (int v in values)
            {
                if (CanSum(num - v, values, acc))
                {
                    acc.Add(num, true);
                    return true;
                }
            }
            acc.Add(num, false);
            return false;
        }

        public static Stack<int> FindSolution(int num, int[] values, Dictionary<int, Stack<int>> acc = null)
        {
            if (acc is null)
                acc = new();
            if (acc.ContainsKey(num))
                return acc[num];
            if (num == 0)
                return new Stack<int>();
            if (num < 0)
                return null;
            foreach (int v in values)
            {
                var result = FindSolution(num - v, values, acc);
                if (result != null)
                {
                    result.Push(v);
                    acc.Add(num, result);
                    return result;
                }
            }
            acc.Add(num, null);
            return null;
        }

        public static Stack<int> FindBestSolution(int num, int[] values, Dictionary<int, Stack<int>> acc = null)
        {
            if (acc is null)
                acc = new();
            if (acc.ContainsKey(num))
                return acc[num] is null ? null : new Stack<int>(acc[num]);
            if (num == 0)
                return new Stack<int>();
            if (num < 0)
                return null;
            Stack<int> result = null;
            foreach (int v in values)
            {
                var best = FindBestSolution(num - v, values, acc);
                if (best is not null)
                {
                    best.Push(v);
                    if (result is null || best.Count < result.Count)
                    {
                        result = new Stack<int>(best);
                    }
                }
            }
            acc.Add(num, result is null ? null : new Stack<int>(result));
            return result;
        }
    }
}
