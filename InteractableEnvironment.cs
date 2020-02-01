using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InteractableEnvironment : Interactables
{
    public string roomName;
    public GameObject room;
    public Player player;
    public Image fadeImage;
    public FadeManager fadeManager;

    public override void Interact(string name)
    {
        fadeManager.StopAllCoroutines();
        fadeImage.color = Color.clear;
        StartCoroutine(GameObject.FindGameObjectWithTag("FadeManager").GetComponent<FadeManager>().Fade(Color.black, fadeImage));
        player.transform.position = room.transform.position;
    }
}