using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InteractableEnvironment : Interactables
{
    public GameObject room;
    public Image fadeImage;
    public FadeManager fadeManager;
    public void Awake()
    {
        fadeImage = GameObject.FindGameObjectWithTag("FadeImage").GetComponent<Image>();
    }
    public override void Interact(string name)
    {
        fadeManager.StopAllCoroutines();
        fadeImage.color = Color.clear;
        StartCoroutine(fadeManager.Fade(Color.black, fadeImage, room));
        
    }
}