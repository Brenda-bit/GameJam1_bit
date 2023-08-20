using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OilScript : MonoBehaviour
{
    public GameObject hideCanvas;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D otherCollider)
    {
        // Check if the other collider has a specific tag
        if (otherCollider.CompareTag("Player"))
        {
            Debug.Log("Player entered the trigger zone!");

            hideCanvas.SetActive(false);
            hideCanvas.SetActive(true);
        }
        
    }
    private void OnTriggerExit2D(Collider2D otherCollider)
    {
        Destroy(this.gameObject);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
