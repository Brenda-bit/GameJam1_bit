using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class IsFalling : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D otherCollider)
    {
        // Check if the other collider has a specific tag
        if (otherCollider.CompareTag("Player"))
        {
            SceneManager.LoadScene("Falha");
        }

    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
