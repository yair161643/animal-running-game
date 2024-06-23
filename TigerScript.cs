using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TigerScript : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {

        // Find all GameObjects with tag "bear" within a 10-unit radius
        Collider[] colliders = Physics.OverlapSphere(transform.position, 50f);

        foreach (Collider collider in colliders)
        {
            if (collider.CompareTag("Bear"))
            {
                // Deactivate the bear GameObject
                collider.gameObject.SetActive(false);
            }
        }

    }
}
