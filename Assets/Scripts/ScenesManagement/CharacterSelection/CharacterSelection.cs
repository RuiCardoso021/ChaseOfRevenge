using UnityEngine;
using UnityEngine.SceneManagement;
using Cinemachine;

public class CharacterSelection : MonoBehaviour
{
	public GameObject[] characters;
	public GameObject InventoryCanvas;
	private InventoryManager inventoryManager;
	[SerializeField] private GameObject CharacterInformation;

	private int index;

    private void Start()
    {
		index = PlayerPrefs.GetInt(Global.selectionObjects);
		characters = new GameObject[transform.childCount];
		inventoryManager = InventoryCanvas.GetComponent<InventoryManager>();
		PlayerPrefs.DeleteAll();

        //Add GameObjects for to list
        for (int i = 0; i < transform.childCount; i++)
		{
			characters[i] = transform.GetChild(i).gameObject;

        }

		//active character
		foreach (GameObject go in characters){
			if (characters[index] == go){
				go.SetActive(true);
                inventoryManager.deck = go.GetComponent<Character_Prefab>().myDeck;
                inventoryManager.FirstInventory();
            }
			else{
				go.SetActive(false);
			}
		}
	}

    private void Update()
    {
		if (CharacterInformation == null)
			CharacterInformation = GameObject.Find("CharacterInformation");
		if(CharacterInformation != null)
        {
            InteractionCharacterSelectionPanel Panel = CharacterInformation.GetComponent<InteractionCharacterSelectionPanel>();

			if(Panel != null)
			{
                Panel.Name = characters[index].GetComponent<Character_Prefab>().Name;
                Panel.Health = characters[index].GetComponent<Character_Prefab>().Health;
                Panel.Mana = characters[index].GetComponent<Character_Prefab>().Mana;
                Panel.ClassType = characters[index].GetComponent<Character_Prefab>().ClassType;
                Panel.ImageProfile = characters[index].GetComponent<Character_Prefab>().ImageProfile;
            }

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
