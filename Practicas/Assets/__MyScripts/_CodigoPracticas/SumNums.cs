using System.Collections.Generic;
using UnityEngine;

public class SumNums : MonoBehaviour
{
    public int search = 9;

    // Start is called before the first frame update
    void Start()
    {
        int[] input = { 2, 7, 11, 15 };
        int[] output = sumaDos(input, search);


        Debug.Log(string.Join(",", input));
        Debug.Log(string.Join(",", output));
    }

    public int[] sumaDos(int[] nums, int target)
    {
        Dictionary<int, int> dictionary = new Dictionary<int, int>();
        int key;

        for (int i = 0; i < nums.Length; i++) 
        {
            key = target - nums[i];

            if (dictionary.ContainsKey(key))
                return new int[] { dictionary[key], i };
            
            dictionary.Add(nums[i], i);
        }
        return null;
    }
}
