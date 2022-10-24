using UnityEngine;
using UnityEngine.SceneManagement;
using Cinemachine;

public class CharacterSelection : MonoBehaviour
{
	public GameObject[] characters;

	private int index;

    private void Start()
    {
		index = PlayerPrefs.GetInt("CharacterSelected");
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
		PlayerPrefs.SetInt("CharacterSelected", index);
		Character_cls player = new Character_cls(characters[index]);
		player.Obj.GetComponent<PlayerMovement>().SetActivePlayerMoviment(true);
		player.Obj.transform.position = Vector3.zero;
		player.Obj.name = "Character_Player";
		GameObjectTransfer.Instance.LoadedCharacter.Add(player);
		GameObjectTransfer.Instance.LoadNextScene();
    }
}
