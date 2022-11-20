using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CharactersAnimationsFight : MonoBehaviour
{
    // Start is called before the first frame update
    private GameObject _player;
    private GameObject _enemy;
    private bool validation;

    private void Start()
    {
        validation = true;
    }

    private void Update()
    {
        if (ManagerGameFight.Instance.PermissedExecute && validation)
        {
            foreach (GameObject item in ManagerGameFight.Instance.Manager.CharactersOnFight)
            {
                if (item != null)
                {
                    if (item.GetComponent<Character_Prefab>() != null)
                    {
                        item.transform.Rotate(0, 90f, 0);
                    }
                    else if (item.GetComponent<Enemy_Prefab>() != null)
                    {
                        item.transform.Rotate(0, -90f, 0);
                    }
                }    
            }

            _player = ManagerGameFight.Instance.Manager.CurrentCharacter;
            _enemy = ManagerGameFight.Instance.Manager.NextCharacter;
            
            validation = false;
        }

        if(_player != null && _enemy != null)
        {

        }
    }
}
