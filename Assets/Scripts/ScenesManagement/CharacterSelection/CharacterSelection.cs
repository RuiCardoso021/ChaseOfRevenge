﻿using UnityEngine;
using UnityEngine.SceneManagement;
using Cinemachine;

public class CharacterSelection : MonoBehaviour
{
	public GameObject[] characters;

	private int index;


    private void Start()
    {
		index = PlayerPrefs.GetInt(Global.selectionObjects);
		characters = new GameObject[transform.childCount];
		
		//Add GameObjects for to list
		for (int i = 0; i < transform.childCount; i++)
			characters[i] = transform.GetChild(i).gameObject;
        
		//active character
		foreach (GameObject go in characters){
			if (characters[index] == go) go.SetActive(true);
			else go.SetActive(false);
		}

	}

	public void ToggleLeft()
    {
		characters[index].SetActive(false);
		
		index--;

		if (index < 0)
			index = characters.Length - 1;

		characters[index].SetActive(true);
	}

	public void ToggleRight()
	{
		characters[index].SetActive(false);

		index++;

		if (index == characters.Length)
			index = 0;

		characters[index].SetActive(true);
	}

	public void ChangeScene()
    {
        characters[index].name = Global.findPlayer;
		TransferGameObject.Instance.LoadedCharacter.Add(characters[index]);
		TransferGameObject.Instance.LoadNextScene();
    }
}
