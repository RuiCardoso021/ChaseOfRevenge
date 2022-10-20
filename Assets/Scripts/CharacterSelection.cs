using UnityEngine;
using UnityEngine.SceneManagement;
using Cinemachine;

public class CharacterSelection : MonoBehaviour
{
	public GameObject[] characters;
	public static GameObject CurrentCharacter;

	public GameObject camera;

	private int index;

    private void Start()
    {
		index = PlayerPrefs.GetInt("CharacterSelected");
		characters = new GameObject[transform.childCount];

		for (int i = 0; i < transform.childCount; i++)
        {
			characters[i] = transform.GetChild(i).gameObject;
        }

		foreach (GameObject go in characters)
			go.SetActive(false);

		if (characters[index]){
			characters[index].SetActive(true);
			CinemachineVirtualCamera cine = camera.GetComponent<CinemachineVirtualCamera>();
			cine.Follow = characters[index].transform;
			cine.LookAt = characters[index].transform;
			//CharacterSelection.CurrentCharacter = characters[index];

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
		
		SceneManager.LoadScene("Explore");
    }
}
