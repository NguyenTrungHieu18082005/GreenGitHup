using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Click_Options : MonoBehaviour
{
    // Start is called before the first frame update
    public void Click_OptionsClick()
    {
        Debug.Log("Options Clicked!");
        SceneManager.LoadScene("OPTIONS_");

    }
}
