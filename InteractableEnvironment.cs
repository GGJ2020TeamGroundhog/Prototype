using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableEnvironment : Interactables
{
    public string roomName;
    public GameObject room;

    public override void Interact(string name) {
        GameObject.FindGameObjectWithTag("FadeManager").GetComponent<FadeManager>().Fade();
        Camera.main.transform.position = room.transform.position;
    }
}
