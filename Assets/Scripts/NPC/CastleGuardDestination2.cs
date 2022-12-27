using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CastleGuardDestination2 : MonoBehaviour
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
                this.gameObject.transform.position = new Vector3(170, 42, 377);
                pivotPoint = 2;
            }
            if (pivotPoint == 0)
            {
                this.gameObject.transform.position = new Vector3(174, 41, 359);
                pivotPoint = 1;
            }
        }
    }
}
