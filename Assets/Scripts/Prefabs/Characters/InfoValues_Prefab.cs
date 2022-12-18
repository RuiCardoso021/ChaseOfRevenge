using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InfoValues_Prefab : MonoBehaviour
{

    public float delay = 3f;
    void Start()
    {
        Destroy(this, this.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).length + delay);
    }
}
