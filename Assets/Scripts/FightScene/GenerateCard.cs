using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateCard : MonoBehaviour
{
   public GameObject block;
   private float numberCards = 1;
  
   void Start()
   {

        for (float x=-1; x<numberCards; x+=0.5f)
        {
            Instantiate(block, new Vector3(x,1,-7), Quaternion.identity);
        }
             
   }

    // Update is called once per frame
    void Update()
    {
        
    }
}
