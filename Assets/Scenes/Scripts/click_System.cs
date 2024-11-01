using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class click_System : MonoBehaviour
{
    public void SystemClick()
    {
        Debug.Log("System Clicked!");
        SceneManager.LoadScene("SYSTEM_");

    }
}
