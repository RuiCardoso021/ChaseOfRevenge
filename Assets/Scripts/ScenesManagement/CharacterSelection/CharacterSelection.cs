using UnityEngine;
using UnityEngine.SceneManagement;
using Cinemachine;

public class CharacterSelection : MonoBehaviour
{
	public GameObject[] characters;
	public InteractionCharacterSelectionPanel Panel;

	private int index;

    private void Start()
    {
		index = PlayerPrefs.GetInt(Global.selectionObjects);
		characters = new GameObject[transform.childCount];
		Panel = GameObject.Find("CharacterInformation").GetComponent<InteractionCharacterSelectionPanel>();

		//Add GameObjects for to list
		for (int i = 0; i < transform.childCount; i++)
		{
			characters[i] = transform.GetChild(i).gameObject;
		}

		//active character
		foreach (GameObject go in characters){
			if (characters[index] == go)
			{
				go.SetActive(true);
			}
			else
			{
				go.SetActive(false);
			}
		}
	}

    private void Update()
    {
		if(Panel != null)
        {
			Panel.Name = characters[index].GetComponent<Character_cls>().Name;
			Panel.Health = characters[index].GetComponent<Character_cls>().Health;
			Panel.Mana = characters[index].GetComponent<Character_cls>().Mana;
			Panel.ClassType = characters[index].GetComponent<Character_cls>().ClassType;
			Panel.ImageProfile = characters[index].GetComponent<Character_cls>().ImageProfile;
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
