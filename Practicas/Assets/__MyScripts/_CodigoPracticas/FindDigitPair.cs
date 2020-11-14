using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FindDigitPair : MonoBehaviour
{
    public static int size = 5;
    public int[] array = new int[size];


    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(countDigitPairNumbers(array) + " pairs found");
    }

    int countDigitPairNumbers(int[] numbers)
    {
        int res = 0;

        for (int i = 0; i < numbers.Length; i++)
            if (isDigitPair(numbers[i]))
                res++;

        return res;
    }

    bool isDigitPair(int number)
    {
        bool res = false;

        while (true)
        {
            if (number < 10)
                return res;

            number /= 10;
            res = !res;
        }
    }
}
