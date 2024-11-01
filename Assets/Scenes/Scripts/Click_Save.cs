using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Click_Save : MonoBehaviour
{
    public void Click_SaveClick()
    {
        Debug.Log("Save Clicked!");
        SceneManager.LoadScene("SAVE_");
    }
}
