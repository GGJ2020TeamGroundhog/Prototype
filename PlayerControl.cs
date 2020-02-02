using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerControl : MonoBehaviour
{
    public bool inDialogue;
    public bool waitingForNextBubble;
    public DialogueTrigger dt;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            if (!inDialogue)
            {
                dt.StartDialogue();
            }
            else
            {
                if (waitingForNextBubble)
                {
                    dt.PlayNext();
                }
            }
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
