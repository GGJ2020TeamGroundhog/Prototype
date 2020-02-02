using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InteractableEnvironment : Interactables
{
    public GameManager gameManager;
    public string roomName;
    public GameObject room;
    public Player player;
    public Image fadeImage;
    public FadeManager fadeManager;
    public void Awake()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>();
    }
    public override void Interact(string name)
    {
        fadeManager.StopAllCoroutines();
        fadeImage.color = Color.clear;
        StartCoroutine(fadeManager.Fade(Color.black, fadeImage, room));
        
    }
}