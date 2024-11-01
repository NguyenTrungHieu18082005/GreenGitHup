using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Click_Load : MonoBehaviour
{
    // Start is called before the first frame update
    public void Click_LoadClick()
    {
        Debug.Log("Load Clicked!");
        SceneManager.LoadScene("LOAD_");
    }


}
