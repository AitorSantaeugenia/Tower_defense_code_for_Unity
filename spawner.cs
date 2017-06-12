using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class spawner : MonoBehaviour {
    //Array per els tipus de enemics

    //Prefab dels enemics
    public wave[] waves;

    public Transform pointSpawn;

    //public static int EnemyInGame;

    //Canviar el valor al morir del mob
    public static int EnemicsEnPantalla = 0;

    //TIMER CD per el joc
    public Text timerWavecd;

    public Text numWavesText;

    //Temps de les waves
    public float waveTime = 5f;

    //Temps entre waves (amb temps anira disminuint)
    private float countdown = 10f;

    //Número de waves
    private int numeroDeWaves = 0;
    private int wavesText = 0;
    private int tesTing = 0;

    public propiertatsJoc propietatsJoc;

    void OnEnable()
    {
        EnemicsEnPantalla = 0;
    }

    void Update() {
        wavesText = Jugador.RoundSurvived;
      
        tesTing = waves.Length;
        if (wavesText > waves.Length)
        {
            wavesText = waves.Length;
        }
        numWavesText.text = "Wave:" + wavesText.ToString() + "/" + tesTing.ToString();

        if (EnemicsEnPantalla > 0)
        {
            return;
        }

        if(numeroDeWaves >= waves.Length && EnemicsEnPantalla <= 0)
        {
            //Debug.Log("Has Guanyat!!!");
            propietatsJoc.levelGuanyat();
            this.enabled = false;
            return;
        }

        if (countdown <= 0f) {
            StartCoroutine(WaveSpawn());
            countdown = waveTime;
            return;
        }

        countdown -= Time.deltaTime;
        countdown = Mathf.Clamp(countdown, 0f, Mathf.Infinity);


        //Timer del joc // Redondejat o no surt el número inicial
        timerWavecd.text = string.Format("{0:00:00}", countdown);
    }

    //Per separar les waves empram la llibreria del System.Collections
    IEnumerator WaveSpawn(){
        Jugador.gold = Jugador.gold + 50;
        //numeroDeWaves++;
        Jugador.RoundSurvived++;

        wave wave = waves[numeroDeWaves];

        EnemicsEnPantalla = wave.comptador;

        Debug.Log("Inicio próxima wave!");
        for (int i = 0; i < wave.comptador; i++){
            CrearEnemic(wave.enemyPrefab);
            yield return new WaitForSeconds(1f / wave.rate);
        }
        numeroDeWaves++;

    }

    void CrearEnemic(GameObject enemy){
        Instantiate(enemy, pointSpawn.position, pointSpawn.rotation);
    }
}
