using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Ql_mainmenu : MonoBehaviour
{
    public void Tv_menu(){
        Debug.Log("tro ve menu thanh cong");
        SceneManager.LoadScene("MainMenu");

    }
}
