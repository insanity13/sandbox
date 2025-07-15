namespace Sandbox.SubArrays
{
    public static class MySolution
    {
        public static int GetMaxSum(int[] initialArray)
        {
            if (initialArray.Length <= 2)
                return initialArray.Sum();

            int maxSum = 0;
            Span<int> numberTypes = stackalloc int[2];

            for (int startIndex = 0; startIndex < initialArray.Length - 1; startIndex++)
            {
                numberTypes[0] = initialArray[startIndex];
                int subSum = initialArray[startIndex];
                int endIndex = startIndex + 1;
                bool isSecondFound = false;
                
                while (endIndex < initialArray.Length && (!isSecondFound || numberTypes.Contains(initialArray[endIndex])))
                {
                    if (!isSecondFound && numberTypes[0] != initialArray[endIndex])
                    {
                        numberTypes[1] = initialArray[endIndex];
                        isSecondFound = true;
                    }

                    subSum += initialArray[endIndex];
                    endIndex++;
                }

                if (subSum > maxSum)
                    maxSum = subSum;

                if (endIndex >= initialArray.Length)
                    break;
            }

            return maxSum;
        }

        public static int[] GetMaxArray(int[] initialArray)
        {
            if (initialArray.Length <= 2)
                return initialArray;

            int maxSum = 0;
            int resultStartIndex = 0;
            int resultEndIndex = 0;
            int[] numberTypes = new int[2];

            for (int startIndex = 0; startIndex < initialArray.Length - 1; startIndex++)
            {
                numberTypes[0] = initialArray[startIndex];
                int subSum = initialArray[startIndex];
                int endIndex = startIndex + 1;
                bool isSecondFound = false;

                while (endIndex < initialArray.Length && (!isSecondFound || numberTypes.Contains(initialArray[endIndex])))
                {
                    if (!isSecondFound && numberTypes[0] != initialArray[endIndex])
                    {
                        numberTypes[1] = initialArray[endIndex];
                        isSecondFound = true;
                    }

                    subSum += initialArray[endIndex];
                    endIndex++;
                }

                if (subSum > maxSum)
                {
                    resultStartIndex = startIndex;
                    resultEndIndex = endIndex;
                    maxSum = subSum;
                }

                if (endIndex >= initialArray.Length)
                    break;
            }

            if (resultStartIndex == 0 && resultEndIndex == initialArray.Length - 1)
                return initialArray;

            return initialArray.AsSpan().Slice(resultStartIndex, (resultEndIndex - resultStartIndex) + 1).ToArray();
        }
    }
}
