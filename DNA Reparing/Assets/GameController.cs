using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    float countdownTo = 120.0F;
    public Text sayac;
    public GameObject sarmalGameObj;
    public GameObject zeminEfekt;
    public GameObject gameOverCanvas;
    public GameObject completedCanvas;


    void Start()
    {
        
    }

    void Update()
    {
        countdownTo -= Time.deltaTime;
        

        if (countdownTo > 0)
        {
            sayac.text = System.Math.Round(countdownTo).ToString(".#", new CultureInfo("en-US"));
        }
        else
        {
            sarmalGameObj.SetActive  (false);
            zeminEfekt.SetActive(false);
            gameOverCanvas.SetActive  (true);
        }
    }

    public void setCompleted()
    {
        completedCanvas.SetActive(true);
    }
    
}

