using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InfoValuesCharacter_Prefab : MonoBehaviour
{
    // Start is called before the first frame update
    private GameObject gm;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (gm == null && ManagerGameFight.Instance != null && FightSceneCamera.Instance != null && ManagerGameFight.Instance.PermissedExecute)
        {
            gm = Resources.Load(Global.linkToInfoValuesCharacter) as GameObject;
            Instantiate(gm, transform);
        }

        //if (gm != null)
        //{
        //    gm.transform.position = new Vector3(-1.2f, 1.5f, 0.5f);
        //    gm.transform.rotation = Quaternion.AngleAxis(7f, Vector3.up);
        //}

        if  (gm != null)
        {

            Camera _mainCamera = FightSceneCamera.Instance.mainCamera;
            if (_mainCamera != null)
            {
                var rotation = _mainCamera.transform.rotation;
                gm.transform.LookAt(gm.transform.position + rotation.y  * Vector3.forward, Vector3.up);
            }
            
        }
        

    }
}
