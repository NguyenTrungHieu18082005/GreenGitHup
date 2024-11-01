using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Click_Tutorials : MonoBehaviour
{
    // Start is called before the first frame update
    public void Click_TutorialsClick()
    {
        Debug.Log("Tutorials Clicked!");
        SceneManager.LoadScene("TUTORIALS_");
    }
}
