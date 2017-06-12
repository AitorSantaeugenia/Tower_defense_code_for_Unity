using UnityEngine;
using UnityEngine.SceneManagement;

public class paused_menu : MonoBehaviour {

    public GameObject ui_menu;
    public string sceneACargar = "MainMenu";
    //Update per si clicam el ESCAPE implementarem la UI Menú
    void Update()    {
        if (Input.GetKeyDown(KeyCode.Escape))
            Pause();

    }

    public void Pause(){
        ui_menu.SetActive(!ui_menu.activeSelf);

        //Aturem el joc si hi ha pause
        if (ui_menu.activeSelf){
            Time.timeScale = 0f;
        }else {
            Time.timeScale = 1f;
        }

    }

    public void Retry(){
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void Menu(){
        Time.timeScale = 1f;
        SceneManager.LoadScene(sceneACargar);

    }

}
