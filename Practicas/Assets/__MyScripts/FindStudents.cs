using System;
using UnityEngine;

public class FindStudents : MonoBehaviour
{
    // Update is called once per frame
    void Start()
	{
		bool res;
		string[] list = { "Guillermina", "Guillermo", "Luis", "Omar", "Sergio" };
		string student = "Luis";

		res = findStudent(list, student);

		if (res)
			Debug.Log(student + " esta en la lista");
		else
			Debug.Log(student + " no esta en la lista");
	}

	static bool findStudent(string[] list, string student)
	{
		int min = 0, max = list.Length, middle = (min + max) / 2, key;

		while (min <= max)
		{

			key = String.Compare(student, list[middle]);

			if (key == 0)
				return true;
			else
				if (key > 0)
			{
				min = middle + 1;
				middle = (max + middle) / 2;
			}
			else
			{
				max = middle - 1;
				middle = (middle + min) / 2;
			}
		}
		return false;
	}
}
