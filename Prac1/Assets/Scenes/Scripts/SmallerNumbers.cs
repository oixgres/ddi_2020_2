using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmallerNumbers : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        int[] array = { 8, 1, 2, 2, 3 };  /* {5, 8, 245, 3, 2, 45 }; Prueba*/

        Debug.Log("Input: " + string.Join(", ",array));
        
        array = smallerNumbers(array);

        Debug.Log("Output: " + string.Join(", ", array));
    }

    // Update is called once per frame
    int[] smallerNumbers(int[] array)
    {
        int[] res = new int[array.Length];


        for (int i = 0; i < array.Length; i++)
            for (int j = 0; j < array.Length; j++)
                if (array[i] > array[j])
                    res[i]++;

        return res;
    }
}
