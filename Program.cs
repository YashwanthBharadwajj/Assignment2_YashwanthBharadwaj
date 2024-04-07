/* 
 
YOU ARE NOT ALLOWED TO MODIFY ANY FUNCTION DEFINIDTION's PROVIDED.
WRITE YOUR CODE IN THE RESPECTIVE QUESTION FUNCTION BLOCK


*/



using System.Text;



namespace ISM6225_Spring_2024_Assignment_2
{
    class Program
    {
        static void Main(string[] args)
        {
            //Question 1:
            Console.WriteLine("Question 1:");
            int[] nums1 = { 0, 0, 1, 1, 1, 2, 2, 3, 3, 4 };
            int numberOfUniqueNumbers = RemoveDuplicates(nums1);
            Console.WriteLine(numberOfUniqueNumbers);

            //Question 2:
            Console.WriteLine("Question 2:");
            int[] nums2 = { 0, 1, 0, 3, 12 };
            IList<int> resultAfterMovingZero = MoveZeroes(nums2);
            string combinationsString = ConvertIListToArray(resultAfterMovingZero);
            Console.WriteLine(combinationsString);

            //Question 3:
            Console.WriteLine("Question 3:");
            int[] nums3 = { -1, 0, 1, 2, -1, -4 };
            IList<IList<int>> triplets = ThreeSum(nums3);
            string tripletResult = ConvertIListToNestedList(triplets);
            Console.WriteLine(tripletResult);

            //Question 4:
            Console.WriteLine("Question 4:");
            int[] nums4 = { 1, 1, 0, 1, 1, 1 };
            int maxOnes = FindMaxConsecutiveOnes(nums4);
            Console.WriteLine(maxOnes);

            //Question 5:
            Console.WriteLine("Question 5:");
            int binaryInput = 101010;
            int decimalResult = BinaryToDecimal(binaryInput);
            Console.WriteLine(decimalResult);

            //Question 6:
            Console.WriteLine("Question 6:");
            int[] nums5 = { 3, 6, 9, 1 };
            int maxGap = MaximumGap(nums5);
            Console.WriteLine(maxGap);

            //Question 7:
            Console.WriteLine("Question 7:");
            int[] nums6 = { 2, 1, 2 };
            int largestPerimeterResult = LargestPerimeter(nums6);
            Console.WriteLine(largestPerimeterResult);

            //Question 8:
            Console.WriteLine("Question 8:");
            string result = RemoveOccurrences("daabcbaabcbc", "abc");
            Console.WriteLine(result);
        }

        /*
        
        Question 1:
        Given an integer array nums sorted in non-decreasing order, remove the duplicates in-place such that each unique element appears only once. The relative order of the elements should be kept the same. Then return the number of unique elements in nums.

        Consider the number of unique elements of nums to be k, to get accepted, you need to do the following things:

        Change the array nums such that the first k elements of nums contain the unique elements in the order they were present in nums initially. The remaining elements of nums are not important as well as the size of nums.
        Return k.

        Example 1:

        Input: nums = [1,1,2]
        Output: 2, nums = [1,2,_]
        Explanation: Your function should return k = 2, with the first two elements of nums being 1 and 2 respectively.
        It does not matter what you leave beyond the returned k (hence they are underscores).
        Example 2:

        Input: nums = [0,0,1,1,1,2,2,3,3,4]
        Output: 5, nums = [0,1,2,3,4,_,_,_,_,_]
        Explanation: Your function should return k = 5, with the first five elements of nums being 0, 1, 2, 3, and 4 respectively.
        It does not matter what you leave beyond the returned k (hence they are underscores).
 

        Constraints:

        1 <= nums.length <= 3 * 104
        -100 <= nums[i] <= 100
        nums is sorted in non-decreasing order.
        */

        public static int RemoveDuplicates(int[] nums)
        {
            try
            {
                if (nums.Length == 0) return 0; // to check if array is empty or not
                int unique_num = 1; //  As the first element should be unique , starting with one
                for (int i = 1; i < nums.Length; i++)
                {
                    if (nums[i] != nums[i - 1])
                    {
                        nums[unique_num] = nums[i];
                        unique_num++; // incrementing it for the next unique element
                    }
                }
               

                return unique_num; // return unique number
            }
            catch (Exception)
            {
                throw;
            }
        }

        /*
        
        Question 2:
        Given an integer array nums, move all 0's to the end of it while maintaining the relative order of the non-zero elements.

        Note that you must do this in-place without making a copy of the array.

        Example 1:

        Input: nums = [0,1,0,3,12]
        Output: [1,3,12,0,0]
        Example 2:

        Input: nums = [0]
        Output: [0]
 
        Constraints:

        1 <= nums.length <= 104
        -231 <= nums[i] <= 231 - 1
        */

        public static IList<int> MoveZeroes(int[] nums)
        {
            try
            {
                int last_num = 0; // Tracks the index of the last non-zero number found.
                for (int i = 0; i < nums.Length; i++)
                {
                    if (nums[i] != 0)
                    {
                        int temp = nums[last_num]; // here the non zero number is moved to its new position and zero to present position
                        nums[last_num] = nums[i];
                        nums[i] = temp;
                        last_num++; // incrementing it for next non-zero element
                    }

                }
                return nums.ToList();  // Convert the modified array back to a list and return it.
            }
            catch (Exception)
            {
                throw;
            }
        }

        /*

        Question 3:
        Given an integer array nums, return all the triplets [nums[i], nums[j], nums[k]] such that i != j, i != k, and j != k, and nums[i] + nums[j] + nums[k] == 0.

        Notice that the solution set must not contain duplicate triplets.

 

        Example 1:

        Input: nums = [-1,0,1,2,-1,-4]
        Output: [[-1,-1,2],[-1,0,1]]
        Explanation: 
        nums[0] + nums[1] + nums[2] = (-1) + 0 + 1 = 0.
        nums[1] + nums[2] + nums[4] = 0 + 1 + (-1) = 0.
        nums[0] + nums[3] + nums[4] = (-1) + 2 + (-1) = 0.
        The distinct triplets are [-1,0,1] and [-1,-1,2].
        Notice that the order of the output and the order of the triplets does not matter.
        Example 2:

        Input: nums = [0,1,1]
        Output: []
        Explanation: The only possible triplet does not sum up to 0.
        Example 3:

        Input: nums = [0,0,0]
        Output: [[0,0,0]]
        Explanation: The only possible triplet sums up to 0.
 

        Constraints:

        3 <= nums.length <= 3000
        -105 <= nums[i] <= 105

        */

        public static IList<IList<int>> ThreeSum(int[] nums)
        {
            try
            {
                IList<IList<int>> triplet = new List<IList<int>>(); // initialize the list to hold triplet
                Array.Sort(nums); // Sorting the array to make sure its easy to find triplet
                for (int ci = 0; ci < nums.Length - 2; ci++)
                {
                    if (ci > 0 && nums[ci] == nums[ci - 1]) // to avoid duplication of triplets skip the same element
                    {
                        continue;
                    }
                    int lp = ci + 1, rp = nums.Length - 1; // setting up 2 pointers for present element
                    while (lp < rp) // to continue searching when left pointer is to the left of right pointer
                    {
                        int cs = nums[ci] + nums[lp] + nums[rp]; //calculating current sum 
                        if (cs == 0) // to check if sum of triplet is 0
                        {
                            triplet.Add(new List<int> { nums[ci], nums[lp], nums[rp] });
                            while (lp < rp && nums[lp] == nums[lp + 1]) lp++; // Skipping duplicate values for the 2nd number in the triplet.
                            while (lp < rp && nums[rp] == nums[rp - 1]) rp--; // Skipping duplicate values for the 3rd number in the triplet.
                            lp++;
                            rp--; // Moving both pointers for the next search to the center
                        }
                        else if (cs < 0) // if sum is less than zero moving left pointer to increase sum 
                        {
                            lp++;
                        }
                        else // if sum is more than zero moving right pointer to increase sum
                        {
                            rp--;
                        }
                    }


                }

                return triplet; // return list of triplets found.
            }
            catch (Exception)
            {
                throw;
            }
        }

        /*

        Question 4:
        Given a binary array nums, return the maximum number of consecutive 1's in the array.

        Example 1:

        Input: nums = [1,1,0,1,1,1]
        Output: 3
        Explanation: The first two digits or the last three digits are consecutive 1s. The maximum number of consecutive 1s is 3.
        Example 2:

        Input: nums = [1,0,1,1,0,1]
        Output: 2
 
        Constraints:

        1 <= nums.length <= 105
        nums[i] is either 0 or 1.

        */

        public static int FindMaxConsecutiveOnes(int[] nums)
        {
            try
            {
                int ls = 0; // initializing longest sequence
                int cus = 0; // initializing current sequence
                foreach (int n in nums)
                {
                    if (n == 1)
                    {
                        cus++; // incrementing cus
                        ls = Math.Max(ls, cus); // updating longest sequence to be max of itself and cus , making sure ls always has the longest sequence found so far
                    }
                    else //  // Resetting `cus` to zero as the current number is not 1, breaking any current sequence of consecutive longest sequence.
                    {
                        cus = 0;
                    }


                }
                return ls; // return length of longest sequence
            }
            catch (Exception)
            {
                throw;
            }
        }

        /*

        Question 5:
        You are tasked with writing a program that converts a binary number to its equivalent decimal representation without using bitwise operators or the `Math.Pow` function. You will implement a function called `BinaryToDecimal` which takes an integer representing a binary number as input and returns its decimal equivalent. 

        Requirements:
        1. Your program should prompt the user to input a binary number as an integer. 
        2. Implement the `BinaryToDecimal` function, which takes the binary number as input and returns its decimal equivalent. 
        3. Avoid using bitwise operators (`<<`, `>>`, `&`, `|`, `^`) and the `Math.Pow` function for any calculations. 
        4. Use only basic arithmetic operations such as addition, subtraction, multiplication, and division. 
        5. Ensure the program displays the input binary number and its corresponding decimal value.

        Example 1:
        Input: num = 101010
        Output: 42


        Constraints:

        1 <= num <= 10^9

        */

        public static int BinaryToDecimal(int binary)
        {
            try
            {
                int dr = 0; // intializing decimal result
                int ptwo = 1; // initializing power of two

                while (binary > 0) // continuing it till there are digits left in binary number
                {
                    int curdigit = binary % 10; // Taking the right most diigit of binary
                    binary /= 10; // removing that digit

                    dr += curdigit * ptwo; // multiplying the current digit by its power of two and adding it to dr
                    ptwo *= 2; // moving to next power of two
                }

                return dr; // return the decimal representation
            }
            catch (Exception)
            {
                throw;
            }
        }

        /*

        Question:6
        Given an integer array nums, return the maximum difference between two successive elements in its sorted form. If the array contains less than two elements, return 0.
        You must write an algorithm that runs in linear time and uses linear extra space.

        Example 1:

        Input: nums = [3,6,9,1]
        Output: 3
        Explanation: The sorted form of the array is [1,3,6,9], either (3,6) or (6,9) has the maximum difference 3.
        Example 2:

        Input: nums = [10]
        Output: 0
        Explanation: The array contains less than 2 elements, therefore return 0.
 

        Constraints:

        1 <= nums.length <= 105
        0 <= nums[i] <= 109

        */

        public static int MaximumGap(int[] nums)
        {
            try
            {
                if (nums.Length < 2) return 0; // If the array has fewer than 2 elements, the maximum gap is automatically 0.
                int min_num = nums.Min(); // Finding both minimum and maximum values
                int max_num = nums.Max();
                int tot_num = nums.Length; // Total number of elements

                int opt_siz = Math.Max(1, (max_num - min_num) / (tot_num - 1)); // Calculate the optimal size of each bucket to minimize the number of buckets
                int count_tot = (max_num - min_num) / opt_siz + 1; // total number of buckets

                int?[] min_b_val = new int?[count_tot]; // initializing arrays for minimum and maximum values in each bucket and using nullable integers as initiallt buckets can be empty
                int?[] max_b_val = new int?[count_tot];


                foreach (int n in nums) // Distribute each number into a bucket based on its value.
                {
                    int ind_buc = (n - min_num) / opt_siz; // Calculate the bucket index for n.
                    min_b_val[ind_buc] = min_b_val[ind_buc] == null ? n : Math.Min(min_b_val[ind_buc].Value, n); // Updating the buckets maximum and minimum value with n 
                    max_b_val[ind_buc] = max_b_val[ind_buc] == null ? n : Math.Max(max_b_val[ind_buc].Value, n);

                }

                int gap_max = 0; // Initializing variables to check max gap and max value of the previous non empty bucket
                int old_max = min_num;
                for (int i = 0; i < count_tot; i++)
                {
                    if (!min_b_val[i].HasValue) continue; // to skip empty buckets
                    gap_max = Math.Max(gap_max, min_b_val[i].Value - old_max); //The gap is the difference between the current bucket's min and the previous bucket's max.
                    old_max = max_b_val[i].Value; // Update old_max to the current bucket's max for the next iteration.
                }

                return gap_max; // return maximum gap found
            }
            catch (Exception)
            {
                throw;
            }
        }

        /*

        Question:7
        Given an integer array nums, return the largest perimeter of a triangle with a non-zero area, formed from three of these lengths. If it is impossible to form any triangle of a non-zero area, return 0.

        Example 1:

        Input: nums = [2,1,2]
        Output: 5
        Explanation: You can form a triangle with three side lengths: 1, 2, and 2.
        Example 2:

        Input: nums = [1,2,1,10]
        Output: 0
        Explanation: 
        You cannot use the side lengths 1, 1, and 2 to form a triangle.
        You cannot use the side lengths 1, 1, and 10 to form a triangle.
        You cannot use the side lengths 1, 2, and 10 to form a triangle.
        As we cannot use any three side lengths to form a triangle of non-zero area, we return 0.

        Constraints:

        3 <= nums.length <= 104
        1 <= nums[i] <= 106

        */

        public static int LargestPerimeter(int[] nums)
        {
            try
            {
                Array.Sort(nums); //  Sort the array of numbers in non-decreasing order.
                Array.Reverse(nums);   // Reverse the sorted array to get the numbers in non-increasing order.
                for (int i = 0; i < nums.Length - 2; i++) // Iterating through the array to check if every triplet is starting from the largest numbers.
                {
                    if (nums[i] < nums[i + 1] + nums[i + 2]) // Check if three sides can make a triangle by seeing if the biggest side is shorter than the total of the other two sides.
                    {
                        return nums[i] + nums[i + 1] + nums[i + 2]; // If the condition is true, a valid triangle can be formed with these sides,and we return the perimeter of this triangle.

                    }

                }
                return 0; // if there is no valid triangle then return 0 
            }
            catch (Exception)
            {
                throw;
            }
        }

        /*

        Question:8

        Given two strings s and part, perform the following operation on s until all occurrences of the substring part are removed:

        Find the leftmost occurrence of the substring part and remove it from s.
        Return s after removing all occurrences of part.

        A substring is a contiguous sequence of characters in a string.

 

        Example 1:

        Input: s = "daabcbaabcbc", part = "abc"
        Output: "dab"
        Explanation: The following operations are done:
        - s = "daabcbaabcbc", remove "abc" starting at index 2, so s = "dabaabcbc".
        - s = "dabaabcbc", remove "abc" starting at index 4, so s = "dababc".
        - s = "dababc", remove "abc" starting at index 3, so s = "dab".
        Now s has no occurrences of "abc".
        Example 2:

        Input: s = "axxxxyyyyb", part = "xy"
        Output: "ab"
        Explanation: The following operations are done:
        - s = "axxxxyyyyb", remove "xy" starting at index 4 so s = "axxxyyyb".
        - s = "axxxyyyb", remove "xy" starting at index 3 so s = "axxyyb".
        - s = "axxyyb", remove "xy" starting at index 2 so s = "axyb".
        - s = "axyb", remove "xy" starting at index 1 so s = "ab".
        Now s has no occurrences of "xy".

        Constraints:

        1 <= s.length <= 1000
        1 <= part.length <= 1000
        s​​​​​​ and part consists of lowercase English letters.

        */

        public static string RemoveOccurrences(string s, string part)
        {
            try
            {
                int ind_par = s.IndexOf(part); // finding the occurence of part in s for the first time

                while (ind_par != -1) // continue to loop as long as part is within s
                {
                    s = s.Remove(ind_par, part.Length); // remove the occurrence of part from s
                    ind_par = s.IndexOf(part); // look for next occurence of part in updated string s
                }
                return s; // return modified string after all the presence of part is removed
            }
            catch (Exception)
            {
                throw;
            }
        }

        /* Inbuilt Functions - Don't Change the below functions */
        static string ConvertIListToNestedList(IList<IList<int>> input)
        {
            StringBuilder sb = new StringBuilder();

            sb.Append("["); // Add the opening square bracket for the outer list

            for (int i = 0; i < input.Count; i++)
            {
                IList<int> innerList = input[i];
                sb.Append("[" + string.Join(",", innerList) + "]");

                // Add a comma unless it's the last inner list
                if (i < input.Count - 1)
                {
                    sb.Append(",");
                }
            }

            sb.Append("]"); // Add the closing square bracket for the outer list

            return sb.ToString();
        }


        static string ConvertIListToArray(IList<int> input)
        {
            // Create an array to hold the strings in input
            string[] strArray = new string[input.Count];

            for (int i = 0; i < input.Count; i++)
            {
                strArray[i] = "" + input[i] + ""; // Enclose each string in double quotes
            }

            // Join the strings in strArray with commas and enclose them in square brackets
            string result = "[" + string.Join(",", strArray) + "]";

            return result;
        }
    }
}