using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LightManager : MonoBehaviour
{

    public float minimum = 0.0f;
    public float maximum = 1f;
    public float duration = 5.0f;
    private float startTime;
    public SpriteRenderer sprite;
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        Color c = sprite.material.color;
        c.a = 0f;   
        sprite.material.color = c;
        StartCoroutine(FadeIn());
    }
    void Update()
    {
        
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Triggou");

        if (collision.gameObject.CompareTag("Oil"))
        {
            Debug.Log("Triggou OIL");
            sprite = GetComponent<SpriteRenderer>();
            Color c = sprite.material.color;
            c.a = 0f;
            sprite.material.color = c;
        }
    }
    IEnumerator FadeIn()
    {
        for (float f = 0.05f; f <= 1; f += 0.05f)
        {
            Color c = sprite.material.color;
            c.a = f;
            sprite.material.color = c;
            yield return new WaitForSeconds(0.09f);
        }
    }
    
}
