using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniMap : MonoBehaviour
{
    Transform targetPlayer;
    //bool validation = false;

    private void Start()
    {
        
    }

    private void Update()
    {
        if (targetPlayer == null)
        {
            GameObject player = SpawnPointSave.instance.Player;

            if(player != null)
                targetPlayer = player.transform;
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
