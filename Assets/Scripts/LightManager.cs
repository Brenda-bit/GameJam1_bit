using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LightManager : MonoBehaviour
{

    public float minimum = 0.0f;
    public float maximum = 1f;
    public float duration = 5.0f;
    public float startTime = 0;
    public SpriteRenderer sprite;
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        Color c = sprite.material.color;
        c.a = 0f;   
        sprite.material.color = c;
    }
    void Update()
    {
        
    }
    private void OnEnable()
    {
        // Método a ser executado toda vez que o GameObject é ativado
        StartCoroutine(FadeIn());
    }

    IEnumerator FadeIn()
    {
        for (float f = startTime; f <= 1; f += startTime)
        {
            Color c = sprite.material.color;
            c.a = f;
            sprite.material.color = c;
            yield return new WaitForSeconds(0.09f);
        }
    }
    
}
