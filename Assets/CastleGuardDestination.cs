using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CastleGuardDestination : MonoBehaviour
{
    public int pivotPoint;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "NPC")
        {          
            if (pivotPoint == 2)
            {
                pivotPoint = 0;
            }
            if (pivotPoint == 1)
            {
                this.gameObject.transform.position = new Vector3(176, 42, 360);
                pivotPoint = 2;
            }
            if (pivotPoint == 0)
            {
                this.gameObject.transform.position = new Vector3(172, 41, 378);              
                pivotPoint = 1;
            }
        }
    }
}
