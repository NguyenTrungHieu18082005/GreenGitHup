using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Click_Title_Screen : MonoBehaviour
{
    // Start is called before the first frame update
    public void Click_Title_ScreenClick()
{
Debug.Log("Title Screen Clicked!");
SceneManager.LoadScene("TITLE_SCREEN_");
}
}