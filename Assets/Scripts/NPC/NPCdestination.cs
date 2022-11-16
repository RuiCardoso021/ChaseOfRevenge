using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCdestination : MonoBehaviour
{
    public int pivotPoint;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "NPC")
        {
            if (pivotPoint == 5)
            {
                pivotPoint = 0;
            }
            if (pivotPoint == 4)
            {
                this.gameObject.transform.position = new Vector3(4, 1.44f, -1);
                pivotPoint = 5;
            }
            if (pivotPoint == 3)
            {
                this.gameObject.transform.position = new Vector3(2, 1.44f, -1);
                pivotPoint = 4;
            }
            if (pivotPoint == 2)
            {
                this.gameObject.transform.position = new Vector3(-13, 1.44f, -1);
                pivotPoint = 3;
            }
            if (pivotPoint == 1)
            {
                this.gameObject.transform.position = new Vector3(-2, 1.44f, 5);
                pivotPoint = 2;
            }
            if (pivotPoint == 0)
            {
                this.gameObject.transform.position = new Vector3(-13, 1.44f, -1);
                pivotPoint = 1;
            }
        }
    }
}
