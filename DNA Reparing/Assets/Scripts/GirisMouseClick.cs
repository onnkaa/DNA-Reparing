using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GirisMouseClick : MonoBehaviour
{
    public void onClick()
    {
        SceneManager.LoadScene("konusma");
    }
}
