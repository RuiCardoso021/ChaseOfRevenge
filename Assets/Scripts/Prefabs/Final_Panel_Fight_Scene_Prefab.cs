using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class Final_Panel_Fight_Scene_Prefab : MonoBehaviour
{
    public void RestartFight()
    {
        bool gameHasEnded = false;
        float restartDelay = 1f;

        if (gameHasEnded == false)
        {
            gameHasEnded = true;
            Debug.Log("GameOver!");
            Invoke("RestartFightScene", restartDelay);
        }
    }

    public void BackToScene()
    {
        if (TransferGameObject.Instance != null)
        {
            TransferGameObject.Instance.LoadedCharacter.Add(GameObject.Find(Global.findPlayer));
            TransferGameObject.Instance.BackToScene();
        }
    }
}
