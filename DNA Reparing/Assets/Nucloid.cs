using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Nucloid : MonoBehaviour
{
    public bool isDone = false;
    private static int  correct=0;
    private static int  inCorrect=0;
    public int cylinderCount;
    public static bool finishGame = false;
    //public int greenCounter;
    //public List<MeshRenderer> silindir;
    public Text winText;
    public Text scoreText2;
    public Text correntText;
    public Text inCorrectText;
    private List<string> renkler;
    AudioSource audio;


    GameObject GameController;
    GameObject ColorSet;

    private void Start()
    {
        winText.enabled = true;
        cylinderCount = GameObject.FindGameObjectsWithTag("Cylinder").Length;
        renkler = new List<string>();

        //for (var i = 0; i < silindir.Count; i++)
        //{
        //    if (silindir[i].GetComponent<MeshRenderer>().material.color == Color.green)
        //    {
        //        greenCounter++;
        //    }

        //}
        GameController = GameObject.FindGameObjectWithTag("gameController");
        ColorSet = GameObject.FindGameObjectWithTag("sarmal");
        audio = GetComponent<AudioSource>();

    }
    public bool Calc()
    {
        bool isFinish = true;
        foreach(GameObject go in GameObject.FindGameObjectsWithTag("Cylinder"))
        {
            if(go.GetComponent<Nucloid>().isDone == false)
            {
                isFinish = false;
            }
            else
            {

            }
        }
        return isFinish;
    }

    private void OnTriggerEnter(Collider other)
    {
        var renk = other.transform.gameObject.GetComponent<MeshRenderer>().material.name.Split(' ')[0];
        renkler.Add(renk);
       // Debug.Log($"renk add {renk}");
        ControlColor();
    }

    private void OnTriggerExit(Collider other)
    {
        var renk = other.transform.gameObject.GetComponent<MeshRenderer>().material.name.Split(' ')[0];
        renkler.Remove(renk);
        //Debug.Log($"renk remove {renk}");
        ControlColor();
    }
    public void FinishGame()
    {
        winText.enabled = true;
        scoreText2.text = "DNA COMPELATED";
        Debug.Log("Bitti");
        GameController.GetComponent<GameController>().setCompleted();
        ColorSet.GetComponent<ColorSet>().endRotate();
    }

    private void ControlColor ()
    {
        if (renkler.Count == 2)
        {
            /////Debug.Log("Control " + renkler[0] + " " + renkler[1]);
            if (renkler[0] == "sarı" && renkler[1] == "mor" || renkler[0] == "mor" && renkler[1] == "sarı")
            {
                correct++;
                GetComponent<MeshRenderer>().material.color = Color.green;
                audio.Play();
                isDone = true;
                
                

            }
            else if(renkler[0] == "turuncu" && renkler[1] == "mavi" || renkler[0] == "mavi" && renkler[1] == "turuncu")
            {
                correct++;
                GetComponent<MeshRenderer>().material.color = Color.green;
                audio.Play();
                isDone = true;

            }
            else
            {
                inCorrect++;
                GetComponent<MeshRenderer>().material.color = Color.red;
                isDone = false;
            }
            

        }
        
    }


    private void Update()
    {
        Calc();
        if(finishGame == false && Calc() == true)
        {
            finishGame = true;
            FinishGame();
        }

        correntText.text = correct + "\nGreen Nucloid";
        inCorrectText.text = 16-correct + "\nRed Nucloid";

    }
  

}
