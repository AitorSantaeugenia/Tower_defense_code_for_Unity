using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class propiertatsJoc : MonoBehaviour {

    public static bool jocAcabat;
    public GameObject nivellCompletatUI;
    public GameObject gameOverUI;

    //public string nextLevel = "Level1";
    //public int NivellSeguent = 2;

    void Start(){
        jocAcabat = false;
        gameOverUI.SetActive(false);
    }

    // Update is called once per frame
    void Update() {
        //No necessarie en Unity 5.5 I THINK BRO
        if (jocAcabat)
            return;

        if (Jugador.lives <= 0) {
            FiDelJoc();

        }
    }

        void FiDelJoc(){
            jocAcabat = true;
            gameOverUI.SetActive(true);
            Debug.Log("Game Over");
        }

    public void levelGuanyat()
    {
        //Debug.Log("Level Won!");
        jocAcabat = true;
        nivellCompletatUI.SetActive(true);
    }

    }

