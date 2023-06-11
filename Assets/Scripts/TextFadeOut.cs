using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


[RequireComponent(typeof(Text))]
public class TextFadeOut : MonoBehaviour
{
    [SerializeField] private float fadeTime;
    private Text text;

    [SerializeField] private bool remove;

    private float delta;

    public bool end { get; private set; }



    void Start()
    {
        text = GetComponent<Text>();

        delta = 0;
        end = false;
    }



    void Update()
    {
        delta += Time.deltaTime;

        if (delta <= fadeTime)
        {
            Color color = text.color;
            color.a -= Time.deltaTime / fadeTime;
            text.color = color;
        }
        else
        {
            end = true;
            if (remove) Destroy(gameObject);
        }
    }

    public void ReStart()
    {
        delta = 0;
        end = false;
        Color color = text.color;
        color.a = 1f;
        text.color = color;
    }
}
