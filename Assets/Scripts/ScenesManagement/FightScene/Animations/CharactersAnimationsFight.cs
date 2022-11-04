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
        if (ManagerGameFight.Instance.Manager.CharactersOnFight != null && validation)
        {
            _player = ManagerGameFight.Instance.Manager.CurrentCharacter;
            _enemy = ManagerGameFight.Instance.Manager.NextCharacter;
            _player.transform.Rotate(0, 90f, 0);
            _enemy.transform.Rotate(0, -90f, 0);

            validation = false;
        }

        if(_player != null && _enemy != null)
        {

        }
    }
}
