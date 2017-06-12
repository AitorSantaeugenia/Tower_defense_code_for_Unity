using UnityEngine;
using UnityEngine.UI;

//DATA MODIFICACIO: 20/05/2017
//Afegit variables per vida, tipus enemic així com les funcionalitats

public class Enemy : MonoBehaviour {
    //Velocitat enemic
    [HideInInspector]
    public float speed;

    //Velocitat inicial
    public float startingSpeed = 10f;

    //Vida enemic inicial i a modificar
    public float vidaInicial = 100;
    private float vida;

    //Al morir, donara or segons el tipus
    public int tipusEnemic = 20;

    //Efecte al morir Particle, animació hem dona error amb prefabs
    public GameObject alMorir;

    //Barra de vida
    public Image barradeVida;
    private bool haMort = false;

    void Start()
    {
        speed = startingSpeed;
        vida = vidaInicial;
    }

    public void QuantitatVidaQuitada(float quantitat){
        vida -= quantitat;
        
        //Barra de vida a modificar
        //Si posem més vida no funciona (al Unity)
        barradeVida.fillAmount = vida / vidaInicial;

        if (vida <= 0f && !haMort) { 
            Matar();
        }

    }

    public void Freeze(float quantitat)
    {
        speed = startingSpeed * (1f - quantitat);
    }

    void Matar(){
        haMort = true;

        //EFECTE AL MORIR
        GameObject effectealMorir = (GameObject)Instantiate(alMorir, transform.position, Quaternion.identity);
        Destroy(effectealMorir, 1f);

        //Si matem al minion, pujem l'or
        Jugador.gold += tipusEnemic;

        //Cada cop que matem a un enemic, -1 de la variable per començar abans
        spawner.EnemicsEnPantalla--;

        //DESTRUIM OBJECTE
        Destroy(gameObject);
    }   
}
