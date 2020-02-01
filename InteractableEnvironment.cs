using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InteractableEnvironment : Interactables
{
    public string roomName;
    public GameObject room;
    public Image fadeImage;
    public FadeManager fadeManager;

    public override void Interact(string name) {
        fadeManager.StopAllCoroutines();
        StartCoroutine(fadeManager.Fade(Color.black, fadeImage));
        Camera.main.transform.position = room.transform.position;
    }
}
