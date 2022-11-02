using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorCastleTrigger : MonoBehaviour
{
    public Transform portal;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            GameObjectTransfer.Instance.LoadedCharacter.Add(GameObject.Find(Global.findPlayer));
            GameObjectTransfer.Instance.LoadNextScene();
        }
    }
}
