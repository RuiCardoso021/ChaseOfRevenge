using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CharacterInformation : MonoBehaviour
{
	public GameObject[] characterInfo;

	private int index;

	private void Start()
	{
		index = PlayerPrefs.GetInt(Global.selectionObjects);
		characterInfo = new GameObject[transform.childCount];

		//Add GameObjects for to list
		for (int i = 0; i < transform.childCount; i++)
		{
			characterInfo[i] = transform.GetChild(i).gameObject;
		}

		//active character info
		foreach (GameObject go in characterInfo)
		{
			if (characterInfo[index] == go)
			{
				go.SetActive(true);
			}
			else
			{
				go.SetActive(false);
			}
		}
	}

	public void ToggleLeft()
	{
		characterInfo[index].SetActive(false);

		index--;

		if (index < 0)
			index = characterInfo.Length - 1;

		characterInfo[index].SetActive(true);
	}

	public void ToggleRight()
	{
		characterInfo[index].SetActive(false);

		index++;

		if (index == characterInfo.Length)
			index = 0;

		characterInfo[index].SetActive(true);
	}
}
