using System;
using System.Collections.Generic;

namespace Quicksort
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			int dataSize = 1000;
			int dataMax = 100;
			List<int> data = new List<int> (dataSize);
			Random r = new Random ();
			for (int i = 0; i < dataSize; ++i)
				data.Add (r.Next (dataMax) + 1);
			//PrintList (data);
			QuickSort (data, 0, data.Count-1);
			Console.WriteLine ((IsSorted(data)?"Sorted":"!!UNSORTED") + " List:");
			PrintList (data);
		}

		public static void QuickSort(List<int> data, int firstIndex, int lastIndex)
		{
			//Recursive quicksort.
			if (lastIndex <= firstIndex) //nothing to sort
				return;
			else if (lastIndex - firstIndex == 1) { //exactly two items
				if (data [firstIndex] > data [lastIndex]) //out of order
					Swap (data, firstIndex, lastIndex);
				return;
			}
			else 
			{
				int key = firstIndex;
				int left = firstIndex + 1;
				int right = lastIndex;
				do
				{
					//Find first on right that is too small
					while ( right > left && (data [right] > data [key]))
						right--;
					//Find first on left that is too big
					while (left < right && (data [left] <= data [key])) //Leave matching values on left
						left++;
					//If we haven't met yet, swap em
					if (right > left ) 
						Swap(data,left,right);
				}
				while(right > left); //Keep going until we meet
				//Finished this iteration
				//Special case: If key was already in correct position, no swap
				if (right == key + 1 && data [right] >= data [key])  //Problem occurs if right ends up adjacent to key
					right--; //Reset right so that it gets sorted again
				else //Normal state, key needs to move
					Swap (data, key, right); //Move key into proper location
				//Recurse left side
				QuickSort (data, firstIndex, right - 1);
				//Recurse right side
				QuickSort (data, right + 1, lastIndex);
			}
		}

		public static void Swap(List<int> data, int index1, int index2)
		{
			int temp = data[index1];
			data [index1] = data [index2];
			data [index2] = temp;
		}

		public static void PrintList(List<int> data)
		{
			foreach (int i in data)
				Console.Write(i + " ");
			Console.WriteLine();
		}

		public static bool IsSorted(List<int> data)
		{
			//For debugging.  Predicate returns true if list is sorted
			for (int i = 0; i < data.Count - 1; ++i)
				if (data [i] > data [i + 1])
					return false;
			return true;
		}
	}
}
