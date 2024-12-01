using CodingAssessments;


public static class Program
{
    public static Dictionary<char, int> ListOcurrencesInArray(string text)
    {
        var charCounts = new Dictionary<char, int>();
        foreach (char c in text)
        {

            if (charCounts.ContainsKey(c))
                charCounts[c]++;
            else charCounts[c] = 1;
        }

        // Create a new dictionary with characters that appear only once
        var singleOccurrenceChars = new Dictionary<char, int>();

        foreach (var entry in charCounts)
        {
            if (entry.Value == 1)
            {
                singleOccurrenceChars.Add(entry.Key, entry.Value);
            }
        }
        return singleOccurrenceChars;
    }
    public static char MostOcurrencesInArray(string text)
    {
        var charCounts = new Dictionary<char, int>();
        foreach (char c in text)
        {

            if (charCounts.ContainsKey(c))
                charCounts[c]++;
            else charCounts[c] = 1;
        }
        char mostCommonChar = '\0';
        int maxCount = 0;

        foreach (var pair in charCounts)
        {
            if (pair.Value > maxCount)
            {
                maxCount = pair.Value;
                mostCommonChar = pair.Key;
            }
        }
        return mostCommonChar;
    }

    //public static char LeastOcurrencesInArray(string text)
    //{
    //    var charCounts = new Dictionary<char, int>();
    //    foreach (char c in text)
    //    {

    //        if (charCounts.ContainsKey(c))
    //            charCounts[c]++;
    //        else charCounts[c] = 1;
    //    }
    //    char mostCommonChar = '\0';
    //    int maxCount = 1;

    //    foreach (var pair in charCounts)
    //    {
    //        if (pair.Value == maxCount)
    //        {
    //            maxCount = pair.Value;
    //            mostCommonChar = pair.Key;
    //        }
    //    }
    //    return mostCommonChar;
    //}
    public static int[] RemoveNumbersGreaterOrEqualToOneInAListOfNumber(int[] numbers)
    {
        var numbersNotGreaterOrEqualToOneInAListOfNumber = numbers.Where(x => x < 1).ToArray();
        return numbersNotGreaterOrEqualToOneInAListOfNumber;
    }
    public static int[] FindNumbersGreaterOrEqualToOneInAListOfNumber(int[] numbers)
    {
        var greaterThanOrEqualToOne = numbers.Where(x => x >= 1).ToArray();

        return greaterThanOrEqualToOne;
    }
    public static int FindSmallestNumber(int[] arry)
    {
        var smallestNumber = arry[0];
        foreach (var number in arry)
        {
            if (number < smallestNumber)
            {
                smallestNumber = number;
            }
        }
        return smallestNumber;
    }
    public static int FindGreatestNumber(int[] arry)
    {
        var smallestNumber = arry[0];
        foreach (var number in arry)
        {
            if (number > smallestNumber)
            {
                smallestNumber = number;
            }
        }
        return smallestNumber;
    }
    public static void getCombination(string inputValue)
    {
        Dictionary<int, char> letterMap = new Dictionary<int, char>();
        var validCombinations = new List<string>();
        var validResult = new List<string>();
        InitializeLetterMap();

        FindCombinations(inputValue, 0, "", validCombinations);

        foreach (var combination in validCombinations)
        {
            string result = string.Empty;
            string[] stringArray = combination.Split(',');
            foreach (var letter in stringArray)
            {
                result += letterMap[int.Parse(letter)];
            }
            validResult.Add(result);
        }

        foreach (var item in validResult)
        {
            Console.WriteLine(item);
        }
        Console.Read();
        static void FindCombinations(string str, int index, string currentCombination, List<string> combinations)
        {
            if (index == str.Length)
            {
                // Remove the last comma if it exists
                if (currentCombination.EndsWith(","))
                {
                    currentCombination = currentCombination.TrimEnd(',');
                }
                combinations.Add(currentCombination);
                return;
            }

            for (int length = 1; length <= 2; length++)
            {
                if (index + length <= str.Length)
                {
                    string part = str.Substring(index, length);
                    if (int.TryParse(part, out int number) && number <= 26)
                    {
                        // Add part to the current combination
                        FindCombinations(str, index + length, currentCombination + part + ",", combinations);
                    }
                }
            }
        }

        void InitializeLetterMap()
        {
            for (int i = 1; i <= 26; i++)
            {
                letterMap[i] = (char)(i + 'a' - 1);
            }
        }
    }

    //public static List<int> ElementFrequency(int[] arry, int k)
    ////public static IEnumerable<KeyValuePair<int, int>> ElementFrequency(int[] arry, int k)
    //{
    //    // Step 1: Count the frequency of each element using a dictionary
    //    var holdFrequency = new Dictionary<int, int>();

    //    foreach (var item in arry)
    //    {
    //        if (holdFrequency.ContainsKey(item))
    //            holdFrequency[item]++;
    //        else
    //            holdFrequency[item] = 1;
    //    }

    //    // Order by frequency in descending order, then by element value in descending order
    //    var result = holdFrequency
    //        .OrderByDescending(x => x.Value)
    //        .ThenByDescending(x => x.Key)
    //        .Take(k)
    //        .Select(x => x.Key)
    //        .ToList();

    //    //var result = holdFrequency
    //    //    .OrderByDescending(x => x.Value)
    //    //    .ThenByDescending(x => x.Key)
    //    //    .Take(k);

    //    return result;


    //}

    public static List<int> ElementFrequency2()
    //public static IEnumerable<KeyValuePair<int, int>> ElementFrequency(int[] arry, int k)
    {
        // Step 1: Count the frequency of each element using a dictionary
        var holdFrequency = new Dictionary<int, int>();

        // Input values
        Console.Write("Enter the number of elements for the array: ");
        int n = int.Parse(Console.ReadLine());
        int[] nums = new int[n];

        Console.WriteLine("Enter each element of the array");
        for (int i = 0; i < n; i++)
        {
            nums[i] = int.Parse(Console.ReadLine());
        }

        Console.Write("Enter the value of the most frequent elements you want returned ");
        int k = int.Parse(Console.ReadLine());


        foreach (var item in nums)
        {
            if (holdFrequency.ContainsKey(item))
                holdFrequency[item]++;
            else
                holdFrequency[item] = 1;
        }

        // Order by frequency in descending order, then by element value in descending order
        var result = holdFrequency
            .OrderByDescending(x => x.Value)
            .ThenByDescending(x => x.Key)
            .Take(k)
            .Select(x => x.Key)
            .ToList();

        //var result = holdFrequency
        //    .OrderBy(x => x.Value)
        //    .ThenBy(x => x.Key)
        //    .Take(k)
        //    .Select(x => x.Key)
        //    .ToList();

        //var result = holdFrequency
        //    .OrderByDescending(x => x.Value)
        //    .ThenByDescending(x => x.Key)
        //    .Take(k);

        return result;


    }
    public static List<List<string>> anagram()
    {

        // Read the number of words
        int n = int.Parse(Console.ReadLine());

        // Dictionary to store sorted-word as key and the list of anagrams as values
        var anagramGroups = new Dictionary<string, List<string>>();

        // Reading the words and grouping them by their sorted characters
        for (int i = 0; i < n; i++)
        {
            string word = Console.ReadLine();
            // Sort the characters in the word to get the anagram signature
            //string sortedWord = String.Concat(word.OrderBy(c => c));
            string sortedWord = new string(word.OrderBy(c => c).ToArray());

            // If this signature is already in the dictionary, add the word to its group
            if (!anagramGroups.ContainsKey(sortedWord))
            {
                anagramGroups[sortedWord] = new List<string>();
            }
            anagramGroups[sortedWord].Add(word);
        }

        // Prepare the result: sort each group and sort the groups by the first word in each group
        var result = anagramGroups
            .Select(group => group.Value.OrderBy(w => w).ToList()) // Sort each anagram group alphabetically
            .OrderBy(group => group.First())  // Sort the groups based on the first word
            .ToList();

        return result;
    }
    public static int BinarySearch(int[] array, int target)
    {
        //{ 1, 3, 5, 9, 11, 10, 4, 7, 13, 15 }; example of an array of integer to look through to get the target
        Array.Sort(array);
        int startLeftRange = 0;
        int endRightRange = array.Length - 1;

        while (startLeftRange <= endRightRange)
        {
            int mid = startLeftRange + (endRightRange - startLeftRange) / 2;

            if (array[mid] == target)
            {
                return mid;
            }

            if (array[mid] < target)
            {
                startLeftRange = mid + 1;
            }
            else
            {
                endRightRange = mid - 1;
            }
        }

        return -1; // Target not found
    }
    public static int CountNodes(TreeNode root)
    {
        //if (root == null)
        //    return 0;

        //int leftCount = CountNodes(root.Left);
        //int rightCount = CountNodes(root.Right);

        //return 1 + leftCount + rightCount; // 1 for the current node + nodes in the left subtree + nodes in the right subtree

        if (root == null)
            return 0;

        int count = 1; // Start by counting the current node

        foreach (var child in root.Children)
        {
            count += CountNodes(child); // Recursively count all children
        }

        return count;
    }
    public static int CountNodes2(TreeNode2 root)
    {
        if (root == null)
            return 0;

        int count = 1; // Start by counting the current node

        foreach (var child in root.Children)
        {
            count += CountNodes2(child); // Recursively count all children
        }

        return count;
    }
    public static int CountPairsWithDifferenceK(int[] arr, int k)
    {
        // { 1, 5, 3, 4, 2 };
        //int k = 2;
        int modulos = 1000000007;
        //HashSet<int> numSet = new HashSet<int>(arr);
        //List<int> list = new List<int>();
        List<int> list = arr.ToList();
        //list.AddRange(arr);

        int count = 0;
        foreach (int item in arr)
        {
            if (list.Contains(item - k))
            //if (numSet.Contains(item - k))
            {
                count++;
            }
        }
        return count % modulos;
        //return count;
    }
    public static int CompareVersion(string version1, string version2)
    {
        //string version1 = "1.2.3";
        //string version2 = "1.2.4";
        string[] strings1 = version1.Split('.');
        string[] strings2 = version2.Split(".");

        int maxlength = Math.Max(strings1.Length, strings2.Length);

        for (int i = 0; i < maxlength; i++)
        {
            int string1Part = i < strings1.Length ? int.Parse(strings1[i]) : 0;
            int string2Part = i < strings2.Length ? int.Parse(strings2[i]) : 0;

            if (string1Part < string2Part)
            {
                return -1;
            }
            if (string1Part > string2Part)
            {
                return 1;
            }
        }
        return 0;
    }
    public static string[] FizzBuzz(int n)
    {
        ////create array to store the results

        //string[] answer = new string[n];
        //for (int i = 1;i <= n;i++)
        //{
        //    if(i % 3 == 0 && i % 5 == 0)
        //    {
        //        answer[i - 1] = "FizzBuzz";
        //    }
        //    else if(i % 3 == 0 )
        //    {
        //        answer[i - 1] = "Fizz";
        //    }
        //    else if (i % 5 == 0)
        //    {
        //        answer[i - 1] = "Buzz";
        //    }
        //    else
        //    {
        //        answer[i-1] = i.ToString();
        //    }
        //}

        //return answer;

        // Create a dictionary to store the conditions and their corresponding outputs
        Dictionary<int, string> fizzBuzzDict = new Dictionary<int, string>
        {
            { 3, "Fizz" },
            { 5, "Buzz" }
        };

        // Create array to store the results
        string[] answer2 = new string[n];

        for (int i = 1; i <= n; i++)
        {
            string result = "";

            // Check each condition in the dictionary
            foreach (var kvp in fizzBuzzDict)
            {
                if (i % kvp.Key == 0)
                {
                    result += kvp.Value;
                }
            }

            // If no condition matched, store the number itself
            answer2[i - 1] = string.IsNullOrEmpty(result) ? i.ToString() : result;
        }

        return answer2;
    }
    public static List<int> FibonacciSeries(int input)
    {
        int firstNumber = 0;
        int secondNumber = 1;
        int sum = 0;
        var numList = new List<int>();

        for (int i = 0; i <= input; i++)
        {
            sum = firstNumber + secondNumber;
            if (sum == 1 && firstNumber == 0)
            {
                numList.Add(sum);
                numList.Add(secondNumber);
                firstNumber = secondNumber;
                secondNumber = sum;
            }
            else if (sum == 2 && secondNumber == 1)
            {
                numList.Add(sum);
                firstNumber = secondNumber;
                secondNumber = sum;
            }
            else
            {
                firstNumber = secondNumber;
                secondNumber = sum;
                numList.Add(sum);
            }
        }
        return numList;
    }
    public static List<int> FibonacciSeries2(int n)
    {
        //if (n <= 1)
        //    return n;
        //else
        //    return FibonacciSeries2(n - 1) + FibonacciSeries2(n - 2);

        var numList = new List<int>();
        for (int i = 0; i < n; i++)
        {
            numList.Add(Fibonacci(i));
        }
        return numList;


        static int Fibonacci(int n)
        {
            if (n <= 1)
                return n;
            else
                return Fibonacci(n - 1) + Fibonacci(n - 2);
        }
    }
    public static IEnumerable<int> GenerateFibonacciSequence(int count)
    {
        int previous = 0, current = 1;

        for (int i = 0; i < count; i++)
        {
            yield return previous; // Yield the current number in the sequence

            // Move to the next number in the Fibonacci sequence
            int next = previous + current;
            previous = current;
            current = next;
        }
    }
    public static double Factorial(int number)
    {
        //if (number == 0)
        //    return 1;
        //return number * Factorial(number - 1);


        //Crude way of doing it
        if (number == 0)
            return 1;
        double factorial = 1;
        for (int i = 1; i <= number; i++)
        {
            factorial = factorial * i;
        }
        return factorial;
    }
    public static List<int> PrimeNumberList(int startInteger, int stopInteger)  //int startInteger, int stopInteger
    {
        var numberList = new List<int>();
        var primeNumbersList = new List<int>();
        numberList.AddRange(Enumerable.Range(startInteger, stopInteger));
        foreach (var number in numberList)
        {
            if (IsPrime(number))
            {
                primeNumbersList.Add(number);
            }
        }
        return primeNumbersList;


        static bool IsPrime(int n)
        {
            if (n <= 1) return false; // 0 and 1 are not prime numbers
            if (n == 2) return true;  // 2 is the only even prime number

            // Check from 2 to the square root of n
            for (int i = 2; i <= Math.Sqrt(n); i++)
            {
                if (n % i == 0) return false; // If divisible, not a prime number
            }

            return true; // If no divisors found, it's a prime number
        }
    }
    public static List<int> EvenNumberListing(int startInteger, int stopInteger)
    {
        var numberList = new List<int>();
        numberList.AddRange(Enumerable.Range(startInteger, stopInteger));

        var evenNumbers = numberList.Where(x => x % 2 == 0).ToList();
        return evenNumbers;
    }
    public static List<int> OddNumberListing(int startInteger, int stopInteger)
    {
        var numberList = new List<int>();
        numberList.AddRange(Enumerable.Range(startInteger, stopInteger));

        var oddNumbers = numberList.Where(x => x % 2 != 0).ToList();
        //var sum = numberList.Sum(x=>x);
        return oddNumbers;
    }
    public static string[] SwapStringArrayAsc(string[] array)
    {
        var limit = array.Length - 1;
        //string[] stringArray = { "Banana", "Apple", "Orange", "Mango", "Grapes" };
        for (int i = 0; i < limit; i++)
        {
            for (int j = 0; j < limit; j++)
            {
                // Compare adjacent elements and swap if they are in the wrong order
                if (string.Compare(array[j], array[j + 1]) > 0)
                {
                    //string temp = array[j];
                    //array[j] = array[j + 1];
                    //array[j + 1] = temp;
                    (array[j], array[j + 1]) = (array[j + 1], array[j]);
                }
            }
        }
        return array;
    }
    public static List<string> SwapStringArrayAsc2(string[] array)
    {
        //var list = array.ToList();
        //return list.OrderBy(x => x).ToList();
        return array.OrderBy(x => x).ToList();
    }
    public static string[] SwapStringArrayDsc(string[] array)
    {
        var limit = array.Length - 1;
        //string[] stringArray = { "Banana", "Apple", "Orange", "Mango", "Grapes" };
        for (int i = 0; i < limit; i++)
        {

            for (int j = 0; j < limit; j++)
            {
                // Compare adjacent elements and swap if they are in the wrong order
                if (string.Compare(array[j], array[j + 1]) < 0)
                {
                    //string temp = array[j];
                    //array[j] = array[j + 1];
                    //array[j + 1] = temp;
                    (array[j], array[j + 1]) = (array[j + 1], array[j]);
                }
            }
        }
        return array;
    }
    public static List<string> SwapStringArrayDsc2(string[] array)
    {
        //var list = array.ToList();
        //return list.OrderByDescending(x => x).ToList();
        return array.OrderByDescending(x => x).ToList();
    }
    public static int[] SwappArrayASC(int[] array)
    {
        //int temp;
        for (int j = 0; j < array.Length - 1; j++)
        {
            for (int i = 0; i < array.Length - 1; i++)
            {
                if (array[i] > array[i + 1])
                {
                    //string temp = array[j];
                    //array[j] = array[j + 1];
                    //array[j + 1] = temp;
                    (array[j], array[j + 1]) = (array[j + 1], array[j]);
                }
            }
        }
        return array;
    }
    public static int[] SwappArrayDSC(int[] array)
    {
        //int temp;
        for (int j = 0; j < array.Length - 1; j++)
        {
            for (int i = 0; i < array.Length - 1; i++)
            {
                if (array[i] < array[i + 1])
                {
                    //string temp = array[j];
                    //array[j] = array[j + 1];
                    //array[j + 1] = temp;
                    (array[j], array[j + 1]) = (array[j + 1], array[j]);
                }
            }
        }
        return array;
    }
    public static List<int> SwappArrayDSC2(List<int> numberToSort)
    {
        return numberToSort.OrderByDescending(x => x).ToList();
    }
    public static List<int> SwappArrayASC2(List<int> numberToSort)
    {
        return numberToSort.OrderBy(x => x).ToList();
    }
    public static List<string> ExtractAndCompare(string firstString, string secondString)
    {
        //string firstString = "I am using my hackerrank to improve my programming";
        //string secondString = "am my hackerrank to improve";
        List<string> firstStringList = firstString.Split(' ').ToList();
        List<string> secondStringList = secondString.Split(' ').ToList();
        foreach (var item in secondStringList)
        {
            if (firstStringList.Contains(item))
            {
                firstStringList.Remove(item);
            }
        }
        return firstStringList;

    }
    public static List<string> ReverseWordPositionInAString(string word)
    {
        //var stringToReverse = "I am using my hackerrank to improve my programming";
        var stringListToReverse2 = word.Split(' ').ToArray();
        List<string> reversedResult = new List<string>();
        foreach (var item in stringListToReverse2.Reverse())
        {
            if (item != null)
            {
                reversedResult.Add(item);
            }
        }
        return reversedResult;
    }
    public static List<string> ReverseWordInAString(string word)
    {
        List<string> stringListToReverse = word.Split(' ').ToList();

        var result = stringListToReverse.Select(x => new string(x.Reverse().ToArray())).ToList();

        return result;
    }
    public static List<string> ReverseWordInAString2(string word)
    {
        //var stringToReverse = "I am using my hackerrank to improve my programming";
        //List<string> stringListToReverse = word.Split(' ').ToList();
        var stringListToReverse2 = word.Split(' ').ToArray();
        List<string> reversedResult = new List<string>();
        foreach (var item in stringListToReverse2)
        {
            if (item != null)
            {
                var res2 = item.Reverse();
                reversedResult.Add(string.Concat(res2));
            }
        }
        return reversedResult;
        //var res = stringListToReverse.AsEnumerable().Reverse().ToList();
        //return res;
        //List<string> reversedResult = new List<string>();

        //for (int i = stringListToReverse.Count -1; i>=0; i--)
        //{
        //   reversedResult.Add(stringListToReverse[i]);
        //}
        //return reversedResult;
    }
    public static string ReverseAString(string word)
    {
        string result = string.Empty;
        if (word != null)
        {
            for (int i = word.Length - 1; i >= 0; i--)
            {
                result += word[i].ToString();
            }
        }
        return result;
    }
    public static List<MyStore> GetMyStoreList()
    {
        var result = new List<MyStore>();

        using (StreamReader theReader = new StreamReader(@"C:\Users\elcfr\OneDrive\Desktop\2024 Interviews\2024CodingAssessements\CodingAssessments\CodingAssessments\StoreList.txt"))
        {
            theReader.ReadLine();
            while (!theReader.EndOfStream)
            {
                string? line = theReader.ReadLine();
                if (string.IsNullOrWhiteSpace(line))
                    continue;

                string[] splitLine = line.Split('|');

                //if (splitLine.Length <3)
                //    continue;

                var Id = splitLine[0];
                var Name = splitLine[1];
                var Location = splitLine[2];
                var mst = new MyStore(Id, Name, Location);
                result.Add(mst);
            }
            return result;
        }
    }
    public static string RemoveDuplicateCharacters(string input)
    {
        //HashSet<char> seen = new HashSet<char>();
        List<char> result = new List<char>();
        List<char> seen = new List<char>();

        foreach (char c in input)
        {
            if (!seen.Contains(c))
            {
                seen.Add(c);
                result.Add(c);
            }
        }

        return new string(result.ToArray());
    }
    public static string RemoveDuplicateCharacters2(string input)
    {
        string[] words = input.Split(' ');
        string result = string.Empty;
        string cleanedString = string.Empty;
        var groupedCharacters = input.GroupBy(c => c)
                                     .Where(g => g.Count() == 1)
                                     .Select(g => g.Key);
        var res = string.Concat(groupedCharacters);

        //res = res.Equals(input) ? "No duplicate found" : res;

        //return res;

        //var groups = input.GroupBy(c => c);
        //foreach (var group in groups)
        //{
        //    Console.WriteLine($"Character: {group.Key}, Count: {group.Count()}");
        //}
        //var singleOccurrenceGroups = groups.Where(g => g.Count() == 1);
        //foreach (var group in singleOccurrenceGroups)
        //{
        //    Console.WriteLine($"Character with single occurrence: {group.Key}");
        //}
        //var groupedCharacters = singleOccurrenceGroups.Select(g => g.Key);
        //foreach (var character in groupedCharacters)
        //{
        //    Console.WriteLine($"Character with single occurrence: {character}");
        //}

        //HashSet<char> seenCharacters = new HashSet<char>();

        List<char> seenCharacters = new List<char>();
        List<char> distinctChars = new List<char>();

        foreach (char c in input)
        {
            if (!seenCharacters.Contains(c))
            {
                seenCharacters.Add(c);
                distinctChars.Add(c);
            }
            else
            {
                distinctChars.Remove(c);
            }
        }
        return string.Concat(distinctChars);
        //return new string(distinctChars.ToArray());
    }
    public static int[] MergeTwoArrays(int[] arr1, int[] arr2)
    {
        var mergedArray = arr1.Concat(arr2).ToArray();
        Array.Sort(mergedArray);
        return mergedArray;
    }

    public static void Main(string[] args)
    {
        var text = "hello world";
        //var mostCommonCharacter = MostOcurrencesInArray(text);
        //Console.WriteLine($"Most common character:{mostCommonCharacter}");

        //var leastCommonCharacter = LeastOcurrencesInArray(text);
        //Console.WriteLine($"Least common character:{leastCommonCharacter}");




        var listOcurrences = ListOcurrencesInArray(text);

        foreach (var kvp in listOcurrences)
        {
            if (!(kvp.Key == '\0' || char.IsWhiteSpace(kvp.Key)))
            {
                Console.WriteLine($"Character: {kvp.Key}, occurs: {kvp.Value}");
            }
        }

        ////=======================================================================
        int[] givenArray = { 1, 3, -5, 9, 11, 10, -4, 7, 13, -15 };

        //var res = RemoveNumbersGreaterOrEqualToOneInAListOfNumber(givenArray);
        //foreach (var item in res)
        //{
        //    Console.WriteLine(item);
        //}

        //var result = FindNumbersGreaterOrEqualToOneInAListOfNumber(givenArray);
        //foreach (var item in result)
        //{
        //    Console.WriteLine(item);
        //}

        //var smallestNumber = FindSmallestNumber(givenArray);
        //Console.WriteLine($"The smallest number is: {smallestNumber}");

        //var greatestNumber = FindGreatestNumber(givenArray);
        //Console.WriteLine($"The greatest number is: {greatestNumber}");

        ////======================================================


        //string inputData = "1123";
        //getCombination(inputData);
        //// Input values
        //Console.Write("Enter the number of elements: ");
        //int n = int.Parse(Console.ReadLine());
        //int[] nums = new int[n];

        //============================================================

        //Console.WriteLine("Enter each element");
        //for (int i = 0; i < n; i++)
        //{
        //    nums[i] = int.Parse(Console.ReadLine());
        //}

        //===================================================================

        //Console.Write("Enter the value of the most frequent elements you want returned ");
        //int k = int.Parse(Console.ReadLine());

        //// Get the top K frequent elements
        //var topFrequentElements = ElementFrequency(nums, k);
        //Console.WriteLine($"Top {k} frequent elements are:");
        ////topFrequentElements.ForEach(Console.WriteLine);

        //var topFrequentElements = ElementFrequency2();
        //foreach (var element in topFrequentElements)
        //{
        //    Console.WriteLine(element);
        //    //Console.WriteLine($"Element: {element.Key}, Frequency: {element.Value}");
        //}

        //======================================================
        //anagram solution
        //var result = anagram();
        //// Output the result
        //foreach (var group in result)
        //{
        //    Console.WriteLine(string.Join(" ", group));
        //}

        //=========================================================
        //// Create a sample binary tree
        ////TreeNode root = new TreeNode(1);
        ////root.Left = new TreeNode(2);
        ////root.Right = new TreeNode(3);
        ////root.Left.Left = new TreeNode(4);
        ////root.Left.Right = new TreeNode(5);
        ////root.Right.Left = new TreeNode(6);
        ////root.Right.Right = new TreeNode(7);
        ///
        //TreeNode root = new TreeNode(1);

        //// Add three children to the root node
        //TreeNode node2 = new TreeNode(2);
        //TreeNode node3 = new TreeNode(3);


        //root.AddChild(node2);
        //root.AddChild(node3);

        //// Add children to node 2
        //TreeNode node4 = new TreeNode(4);
        //TreeNode node5 = new TreeNode(5);
        //node2.AddChild(node4);
        //node2.AddChild(node5);

        //// Add children to node 3
        //TreeNode node6 = new TreeNode(6);
        //TreeNode node7 = new TreeNode(7);
        //node3.AddChild(node6);
        //node3.AddChild(node7);



        //int nodeCount = CountNodes(root);
        //Console.WriteLine($"Number of nodes in the binary tree: {nodeCount}");

        //// Create n-ary tree
        //// Create the root node
        //TreeNode2 root = new TreeNode2(1);

        //// Add three children to the root node
        //TreeNode2 node2 = new TreeNode2(2);
        //TreeNode2 node3 = new TreeNode2(3);
        //TreeNode2 node4 = new TreeNode2(4);

        //root.AddChild(node2);
        //root.AddChild(node3);
        //root.AddChild(node4);

        //// Add children to node 2
        //TreeNode2 node5 = new TreeNode2(5);
        //TreeNode2 node6 = new TreeNode2(6);
        //node2.AddChild(node5);
        //node2.AddChild(node6);

        //// Add children to node 3
        //TreeNode2 node7 = new TreeNode2(7);
        //node3.AddChild(node7);

        //// Add children to node 5
        //TreeNode2 node8 = new TreeNode2(8);
        //TreeNode2 node9 = new TreeNode2(9);
        //node5.AddChild(node8);
        //node5.AddChild(node9);

        //// Add children to node 6
        //TreeNode2 node10 = new TreeNode2(10);
        //TreeNode2 node11 = new TreeNode2(11);
        //node6.AddChild(node10);
        //node6.AddChild(node11);

        //// Add children to node 7
        //TreeNode2 node12 = new TreeNode2(12);
        //TreeNode2 node13 = new TreeNode2(13);
        //node7.AddChild(node12);
        //node7.AddChild(node13);

        //int nodeCount = CountNodes2(root);
        //Console.WriteLine($"Number of nodes in the n-ary tree: {nodeCount}");

        //-----------------------------------------------------
        //int[] givenArray = { 1, 3, 5, 9, 11, 10, 4, 7, 13, 15 };
        //int target = 13;

        //int index = BinarySearch(givenArray, target);

        //if (index != -1)
        //{
        //    Console.WriteLine($"Element {target} found at index {index}.");
        //}
        //else
        //{
        //    Console.WriteLine($"Element {target} not found in the array.");
        //}

        //-----------------------------------------------------

        //int[] arr1 = { 1, 5, 3, 4, 2 };
        //int[] arr2 = { 17, 51, 33, 45, 20 };

        //var mergedArray = MergeTwoArrays(arr1, arr2);
        //foreach (var item in mergedArray)
        //{
        //    Console.Write($"{item} ");
        //}
        //-----------------------------------------------------
        //int[] arr = { 1, 5, 3, 4, 2 };
        //int k = 2;
        //var result = CountPairsWithDifferenceK(arr, k);
        //Console.WriteLine(result);

        //-----------------------------------------------------
        //var primeNumbers = PrimeNumberList(1, 10);

        //Console.WriteLine("---------------Prime Numbers-------------");
        //foreach (var item in primeNumbers)
        //{
        //    Console.Write($"{item} ");
        //}

        //-----------------------------------------------------
        //string input = "remove duplicates";
        //string input2 = "remove";
        //string input3 = "duplicates";
        //var result = RemoveDuplicateCharacters2(input);
        ////Console.WriteLine(result.ToString());
        //foreach (char word in result)
        //{
        //    Console.Write($"{word} ");
        //}

        //-----------------------------------------------------

        //var myStoreCollection = GetMyStoreList();
        //foreach (var myStore in myStoreCollection)
        //{
        //    Console.Write($"Record ID: {myStore.RecordId}, ");
        //    Console.Write($"Store Name: {myStore.StoreName}, ");
        //    Console.Write($"Store Location: {myStore.StoreLocation}, ");
        //    Console.WriteLine();
        //}
        //-----------------------------------------------------

        //var factorialResult = Factorial(7);
        //Console.Write($"{factorialResult} ");
        //-----------------------------------------------------

        //var stringToReverse = "I am using my hackerrank to improve my programming";
        //var singleString = "programming";
        //var singleString2 = "remove";

        //var reversedString = ReverseWordInAString(stringToReverse);
        //foreach (string str in reversedString)
        //{
        //    Console.Write($"{str} ");
        //}
        //Console.WriteLine();
        //var reversedWord = ReverseWordInAString2(stringToReverse);
        //foreach (string str in reversedWord)
        //{
        //    Console.Write($"{str} ");
        //}

        //Console.WriteLine();
        //var reversedWordPosition = ReverseWordPositionInAString(stringToReverse);
        //foreach (string str in reversedWordPosition)
        //{
        //    Console.Write($"{str} ");
        //}

        //var reversedString = ReverseAString(singleString);

        //Console.WriteLine($"{reversedString}");

        //-----------------------------------------------------
        //string firstString = "I am using my hackerrank to improve my programming";
        //string secondString = "am my hackerrank to improve";

        //List<string> resultStringDetail = ExtractAndCompare(firstString, secondString);

        //foreach (string str in resultStringDetail)
        //{
        //    Console.Write($"{str} ");
        //}

        //-----------------------------------------------------
        //int[] numbersASC = { 10, 36, 3, 8, 21, 33, 2, 0, 1, 5, 54, 7 };
        //int[] wASC = SwappArrayASC(numbersASC);
        //foreach (int i in wASC)
        //{
        //    Console.WriteLine(i);
        //}

        //int[] numbersDSC = { 10, 36, 3, 8, 21, 33, 2, 0, 1, 5, 54, 7 };
        //int[] wDSC = SwappArrayDSC(numbersDSC);
        //foreach (int i in wDSC)
        //{
        //    Console.WriteLine(i);
        //}

        //List<int> numbersDSC = new List<int> { 10, 36, 3, 8, 21, 33, 2, 0, 1, 5, 54, 7 };
        //var sortedNumbersDSC = SwappArrayDSC2(numbersDSC);
        //foreach (int i in sortedNumbersDSC)
        //{
        //    Console.Write($"{i} " );
        //}
        //Console.WriteLine();

        //List<int> numbersASC = new List<int> { 10, 36, 3, 8, 21, 33, 2, 0, 1, 5, 54, 7 };
        //var sortedNumbersASC = SwappArrayASC2(numbersASC);
        //foreach (int i in sortedNumbersASC)
        //{
        //    Console.Write($"{i} " );
        //}

        //string[] stringArray = { "Banana", "Apple", "Orange", "Mango", "Grapes" };
        //var sortedStringASC = SwapStringArrayAsc(stringArray);
        //foreach (string item in sortedStringASC)
        //{
        //    Console.WriteLine(item);
        //}

        //string[] stringArray = { "Banana", "Apple", "Orange", "Mango", "Grapes" };
        //var sortedStringDSC = SwapStringArrayDsc2(stringArray);
        //foreach (string item in sortedStringDSC)
        //{
        //    Console.WriteLine(item);
        //}
        //-----------------------------------------------------

        //string version1 = "1.2.3";
        //string version2 = "1.2.4";

        //int result = CompareVersion(version1, version2);

        //Console.WriteLine($"Comparison result = {result}"  );
        //-----------------------------------------------------

        //int n = 15;
        //string[] FizzBuzzResult = FizzBuzz(n);

        //foreach (string item in FizzBuzzResult)
        //{
        //    Console.WriteLine($"FizzBuzz result : {item}");
        //}
        //-----------------------------------------------------

        //var fibonacciSeries = FibonacciSeries(7);

        //foreach (var item in fibonacciSeries)
        //{
        //    Console.WriteLine($" fibonacciSeries = {item}");
        //}


        //var fibonacciSeries = FibonacciSeries2(7);

        //foreach (var item in fibonacciSeries)
        //{
        //    Console.Write($"{item} ");
        //}


        //Console.WriteLine("Fibonacci Sequence:");

        //// Generate the first 10 Fibonacci numbers
        //foreach (var number in GenerateFibonacciSequence(7))
        //{
        //    Console.Write(number + " ");
        //}

        //int input = 7;
        //for (int i = 0; i <= input; i++)
        //{
        //    Console.Write($"{FibonacciSeries2(i)} ");
        //}
        //-----------------------------------------------------

        //var evenNumbers = EvenNumberListing(1, 10);

        //Console.WriteLine("---------------Even Numbers-------------");
        //foreach (var item in evenNumbers)
        //{
        //    Console.Write($"{item} ");
        //}

        //Console.WriteLine();
        //Console.WriteLine("---------------Odd Numbers-------------");
        //var oddNumbers = OddNumberListing(1, 10);

        //foreach (var item in oddNumbers)
        //{
        //    Console.Write($"{item} ");
        //}
        //-----------------------------------------------------



        Console.ReadLine();

    }
}

//Initialize the letterMap: Map numbers 1 to 26 to corresponding letters.
//Find Combinations: Generate valid combinations of indices that can represent letters.
//Convert Combinations to Letters: Convert each combination of numbers into letters and print them.


//1st question
//initialize a dictionary to hold the count of each element

//enter value to hold number of element for the array

//initialize the array with size of value entered above

//create a loop to enter value of each element for the array

//enter value for the number of most frequent numbers to output

//calculate element frequencies

// Order by frequency in descending order, then by element value in descending order


//2nd question

// Read the number of words to be entered

// Dictionary to store sorted-word as key and the list of anagrams as values

// create a loop and Read the words and grouping them by their sorted characters

// Sort the characters in the word to get the anagram signature

// check If this key is already in the dictionary, add the word to its key else intialize a new list

// sort each group and sort the groups by the first word in each group


//for (int i = 1; i <= 26; i++)
//{
//    letterMap[i] = (char)(i + 'a' - 1);
//}

//int StringLength = stringArray.Length;


//// Iterate through the string and combine digits
//for (int i = 0; i < StringLength; i++)
//{
//    for (int j = i + 1; j < StringLength; j++)
//    {
//        // Combine the two digits
//        string combination = stringArray[i].ToString() + stringArray[j].ToString();
//        if (int.TryParse(combination, out int number) && number <= 26)
//        {
//            validCombinations.Add(number);
//        }
//    }
//}

//foreach (var letter in stringArray)
//{
//    result += letterMap[int.Parse(letter)];
//}

//Console.WriteLine(result);
