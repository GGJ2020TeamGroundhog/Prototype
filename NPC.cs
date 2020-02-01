using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : Interactables
{
    public DialogueTrigger dialogueTrigger;
    public Dialogue dialogue;

    private void Start() {
        dialogueTrigger.dialogue = dialogue;
    }

    public override void Interact(string noUse) {
        dialogueTrigger.StartDialogue();
    }
}
