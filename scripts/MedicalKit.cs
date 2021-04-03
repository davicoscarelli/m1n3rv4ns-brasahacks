using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MedicalKit : MonoBehaviour
{

    void OnTriggerEnter(Collider ColisionObject)
    {

        if (ColisionObject.tag == "Player")
        {
            ColisionObject.GetComponent<TapController>().CureLife();
            Destroy(gameObject);
        }
    }
}
