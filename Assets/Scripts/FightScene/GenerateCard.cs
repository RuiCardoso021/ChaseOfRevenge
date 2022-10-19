using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateCard : MonoBehaviour
{
   public GameObject block;
   private int numberCards = 2;
  
   void Start()
   {

        for (int x=-2; x<numberCards; ++x)
        {
            Instantiate(block, new Vector3(x,1,-7), Quaternion.identity);
        }
             
   }

    // Update is called once per frame
    void Update()
    {
        
    }
}
