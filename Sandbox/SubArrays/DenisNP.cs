namespace Sandbox.SubArrays
{
    public static class DenisNP
    {
        public static int GetMaxSum(int[] nums)
        {
            int left = 0;
            int right = 0;
            bool movingRight = true;
            bool isSumValid = true;
            int currentSum = 0;
            int maxSum = int.MinValue;
            Dictionary<int, int> counts = new();

            while (true)
            {
                if (movingRight)
                {
                    if (right == nums.Length)
                    {
                        return maxSum;
                    }
                    int rEl = nums[right];
                    right++;

                    currentSum += rEl;
                    if (!counts.ContainsKey(rEl))
                    {
                        counts[rEl] = 1;
                    }
                    else
                    {
                        counts[rEl]++;
                    }

                    if (counts.Count > 2)
                    {
                        isSumValid = false;
                        movingRight = false;
                    }
                }
                else
                {
                    if (left == nums.Length)
                    {
                        return maxSum;
                    }

                    int lEl = nums[left];
                    left++;

                    currentSum -= lEl;
                    if (counts.ContainsKey(lEl))
                    {
                        counts[lEl]--;
                        if (counts[lEl] == 0)
                        {
                            counts.Remove(lEl);
                        }
                    }

                    if (counts.Count <= 2)
                    {
                        isSumValid = true;
                        movingRight = true;
                    }
                }

                if (isSumValid && currentSum > maxSum)
                {
                    maxSum = currentSum;
                }
            }
        }
    }
}
