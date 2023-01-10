// See https://aka.ms/new-console-template for more information

{
	int[] numberArray = { 3, 5, 7, 8, 11, 12, 14, 18, 20, 21, 23 };
	Console.WriteLine("Array elements are : ");
	foreach (int number in numberArray)
	{
		Console.Write(number + " ");
	}

	int key = 18;
	Console.WriteLine("\nkey to be searched =" + key);
	int first = 0;
	int last =numberArray.Length - 1;
	int mid = (first + last) / 2;

	while (first <= mid)
	{
		if (numberArray[mid] < key)
		{
			first = mid + 1;
		}
		else if (numberArray[mid] == key)
		{
			Console.WriteLine("Element found at index: " + mid);
			Console.ReadLine();
		}
		else 
		{
			last = mid - 1;
		}
		mid = (first + last) / 2;
	}
	if (first > last)
	{ 
		Console.WriteLine("Element is not found in the array");
		Console.ReadLine();
	}

}

