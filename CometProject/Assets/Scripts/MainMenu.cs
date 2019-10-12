using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {
	public void Go ()
    {
        //SceneManager.LoadScene("Assets/Prototype/Asset Testing.unity");
        SceneManager.LoadScene("Assets/UI/Playground.unity");
    }
    public void BackToMenu()
    {
        //SceneManager.LoadScene("Assets/Prototype/Asset Testing.unity");
        SceneManager.LoadScene("Assets/UI/Main Menu.unity");
    }
}
