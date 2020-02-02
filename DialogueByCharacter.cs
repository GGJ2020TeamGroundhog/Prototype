using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Put this on other characters. Lists every dialogue they can have with the player.
public class DialogueByCharacter : MonoBehaviour
{
    public List<Dialogue> dialogues;
    public DialogueHead player;
    public DialogueHead other;

    public enum SpeakingOrder
    {
        Player,
        Other
    }
    public SpeakingOrder firstSpeaker;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("DialogueCharacterPlayer").GetComponent<DialogueHead>();
        other = GetComponent<DialogueHead>();
    }
}
