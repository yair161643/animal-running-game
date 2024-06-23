using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;


public class createShutterd : MonoBehaviour
{
    public GameObject brokeCreate;
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
        if (other.CompareTag("Deer"))
        {
            GameObject instantiatedObject = Instantiate(brokeCreate, transform.position, transform.rotation);
            Destroy(this.gameObject);
            Destroy(instantiatedObject, 1.7f);
        }
        else if(other.CompareTag("Tiger")|| other.CompareTag("Eagle")|| other.CompareTag("Player"))
        {
            Debug.Log("Game Over");
            QuitGame();
        }
    }


    void QuitGame()
    {
#if UNITY_EDITOR
        EditorApplication.isPlaying = false; // Stop playing the editor
#else
        Application.Quit(); // Quit application (works for standalone builds)
#endif
    }

}
