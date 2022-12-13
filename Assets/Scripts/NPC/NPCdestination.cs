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
                this.gameObject.transform.position = new Vector3(77, 44, 181);
                pivotPoint = 5;
            }
            if (pivotPoint == 3)
            {
                this.gameObject.transform.position = new Vector3(69, 44, 185);
                pivotPoint = 4;
            }
            if (pivotPoint == 2)
            {
                this.gameObject.transform.position = new Vector3(64, 44, 171);
                pivotPoint = 3;
            }
            if (pivotPoint == 1)
            {
                this.gameObject.transform.position = new Vector3(78, 44, 171);
                pivotPoint = 2;
            }
            if (pivotPoint == 0)
            {
                this.gameObject.transform.position = new Vector3(79, 44, 160);
                pivotPoint = 1;
            }
        }
    }
}
