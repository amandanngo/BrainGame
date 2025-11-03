using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
    public void ClickStartGame(){
        SceneManager.LoadScene("SampleScene");
    }
}
