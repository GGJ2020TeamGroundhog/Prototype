using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    // RESET CONSTANTS
    private const float TIMELIMIT = 10.0f;


    [SerializeField] Player player;
    [SerializeField] Transform teleportDes;
    public bool isPaused = false;
    public Image fadeImage;
    public FadeManager fadeManager;



    private float timeIteration;
    private float timeLeft = TIMELIMIT;
    public TextMeshProUGUI timerText;
    // Start is called before the first frame update
    void Start()
    {
        timeIteration = 1;
        timerText.text = (timeLeft.ToString());
        StartCoroutine("LoseTime");

    }

    // Update is called once per frame
    void Update()
    {
        timerText.text = (timeLeft.ToString()  );
    }





    // TIME 
    IEnumerator LoseTime()
    {
        while (true)
        {
            if (timeLeft <= 0.0f)
            {
                timerEnded();
                yield break;
            }
            else
            {
                yield return new WaitForSeconds(1);
                timeLeft--;
            }
        }
    }
    void timerEnded()
    {

        RewindTime();
        fadeManager.StopAllCoroutines();
        fadeImage.color = Color.clear;
        StartCoroutine(GameObject.FindGameObjectWithTag("FadeManager").GetComponent<FadeManager>().Fade(Color.blue, fadeImage));

    }

    void RewindTime()
    {
        player.transform.position = teleportDes.position;
        timeIteration++;

        Debug.Log("REWIND TIME\n Time iteration: "+timeIteration);
        timeLeft = TIMELIMIT;


        StartCoroutine("LoseTime");

    }

}
