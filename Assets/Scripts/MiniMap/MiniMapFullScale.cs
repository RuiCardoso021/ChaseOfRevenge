using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniMapFullScale : MonoBehaviour
{
    Transform targetPlayer;
    [SerializeField] private GameObject fullMap;

    public void CloseFullMap()
    {
        fullMap.SetActive(false);
    }

    private void Update()
    {
        if (targetPlayer == null)
        {
            GameObject player = GameObject.Find(Global.findPlayer);

            if(player != null)
                targetPlayer = player.transform;
        }

        if(Input.GetKey(KeyCode.M))
        {
            fullMap.SetActive(true);
        }
    }

    private void LateUpdate()
    {
        if (targetPlayer != null)
        {
            Vector3 newPos = targetPlayer.position;
            newPos.y = transform.position.y;
            transform.position = newPos;

            transform.rotation = Quaternion.Euler(90f, targetPlayer.transform.eulerAngles.y, 0f);
        }
    }
}
