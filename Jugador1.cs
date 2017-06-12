using System.Collections;
using UnityEngine;

/* Tractament característiques jugador */

public class Jugador1 : MonoBehaviour {

    //Manejo de Money
    public static int gold;
    public int startingGold = 500;

    //Manejo de vidas
    public static int lives;
    public int iniciLives = 20;

    //Rondes que hem survived
    public static int RoundSurvived;

    void Start(){
        gold = startingGold;
        lives = iniciLives;

        RoundSurvived = 0;
    }
}
