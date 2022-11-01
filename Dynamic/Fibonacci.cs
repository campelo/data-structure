namespace Dynamic
{
    public static class Fibonacci
    {
        public static long GetFibNum(int numPosition, Dictionary<int, long> acc = null)
        {
            if (acc is null)
                acc = new();
            if (acc.ContainsKey(numPosition))
                return acc[numPosition];
            if (numPosition == 1 || numPosition == 2)
                return 1;
            if (numPosition == 0)
                return 0;
            long resultat = GetFibNum(numPosition - 1, acc) + GetFibNum(numPosition - 2, acc);
            acc.Add(numPosition, resultat);
            return resultat;
        }
    }
}