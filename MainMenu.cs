using UnityEngine.SceneManagement;
using UnityEngine;

public class MainMenu : MonoBehaviour {

    public string sceneACargar = "MainLevel";

    public void Play(){
        SceneManager.LoadScene(sceneACargar);
    }

    public void Sortir(){
        Debug.Log("Balls deep!");
        Application.Quit();
    }

}
