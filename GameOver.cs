using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour {

    public string sceneACargar = "MainMenu";

    //Botó retry
    public void Retry(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    //Botó menu
    public void Menu(){
        SceneManager.LoadScene(sceneACargar);
        //print("Menu clicked");
    }

}
