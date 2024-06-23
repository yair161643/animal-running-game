using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pitScript : MonoBehaviour
{
    public float fallSpeed = 50f; // Adjust this value to control the fall speed

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Eagle"))
        {
            Debug.Log("All good");
        }
        else
        {
            Debug.Log("Game Closed");

            Rigidbody rb = other.GetComponent<Rigidbody>(); // Get the Rigidbody component

            if (rb != null)
            {
                rb.useGravity = true; // Enable gravity
                rb.constraints = RigidbodyConstraints.None; // Release all constraints

                // Increase downward velocity
                rb.velocity = new Vector3(0f, -fallSpeed, 0f);
            }

            Collider col = other.GetComponent<Collider>(); // Get the Collider component

            if (col != null)
            {
                col.enabled = false; // Disable the collider
            }
        }
    }
}
