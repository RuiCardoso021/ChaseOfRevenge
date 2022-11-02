using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GamePlayAnimation : MonoBehaviour
{
    // Start is called before the first frame update
    private GameObject _player;
    private GameObject _enemy;
    private bool active;

    private void Start()
    {
        active = true;
    }

    private void Update()
    {
        if (RecibeCharactersFight.Instance.SpawnerList[1] != null && active)
        {
            _player = RecibeCharactersFight.Instance.SpawnerList[0];
            _enemy = RecibeCharactersFight.Instance.SpawnerList[1];
            _player.transform.Rotate(0, 90f, 0);
            _enemy.transform.Rotate(0, -90f, 0);

            active = false;
        }

        if(_player != null && _enemy != null)
        {

        }
    }
}
