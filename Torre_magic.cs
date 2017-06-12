using System.Collections;
using UnityEngine;

//DATA MODIFICACIO: 25/03/2017
//Bloquejarem les torres amb l'objectiu
//Amb el mateix Script, dispararem a l'objectiu

public class Torre_magic : MonoBehaviour {

    //Variable per l'objectiu de la torre
    private Transform objectiu;
    //Per la vida
    private Enemy objectiuEnemic;

    //Rang de la torre
    public float range = 50f;
    //Tag per els enemics
    public string enemicsTag = "Enemy";
    //Canvi de objectiu de la torre
    public float canviRotacio = 10f;

    [Header("Magic Torre")]
    public bool magicLaser = false;
    public LineRenderer linerender;
    public ParticleSystem efecteImpactat;
    public int dotdamage = 20;

    //Freeze per el enemic amb la torre de magia
    public float freezeEnemic = 0.5f;

    //TORRE DISPARS
    //Dispar per segon de la Torre
    public float disparTorre = 1f;
    //Un cop disparat, que torni a disparar
    private float cddisparTorre = 0f;

    //Var per canyo
    public GameObject balaCano;
    public Transform puntDispar;

    //Part a rotar
    public Transform td_cannon;
    //EFECTE AUDIO DISPAR
    public AudioSource efecteDisparAudio;

    // Use this for initialization
    void Start () {
		InvokeRepeating("UpdateObjectiu", 0f, 0.5f);
        efecteDisparAudio = GetComponent<AudioSource>();
    }
	
    //Refresca els objectius dins del rang
    void UpdateObjectiu(){
        GameObject[] enemicsAlJoc = GameObject.FindGameObjectsWithTag(enemicsTag);
        //Rang més petit per la torre
        float shortDistance = Mathf.Infinity;
        //Enemic més a prop
        GameObject nearEnemy = null;

        foreach (GameObject enemy in enemicsAlJoc)
        {
            float enemyDistance = Vector3.Distance(transform.position, enemy.transform.position);
            if (enemyDistance < shortDistance)
            {
                shortDistance = enemyDistance;
                nearEnemy = enemy;
            }
        }
        //Trovam algun enemic
        if (nearEnemy != null && shortDistance <= range)
        {
            objectiu = nearEnemy.transform;
            objectiuEnemic = nearEnemy.GetComponent<Enemy>();

        }
        else
            objectiu = null;
    }

    // Update is called once per frame
    void Update()
    {
        if (objectiu == null)
        {
            if (magicLaser)
            {
                if (linerender.enabled)
                {
                    linerender.enabled = false;
                    efecteImpactat.Stop();
                    efecteDisparAudio.Stop();
                }
                    
            }
            return;
        }
            

        enemicFixat();

        if (magicLaser)
        {
            Laser();
        }
        else
        {
            if (cddisparTorre <= 0f)
            {
                DisparTorreObjectiu();
                cddisparTorre = 1f / disparTorre;
            }

            //El CD del dispar será reduit cada segon
            cddisparTorre -= Time.deltaTime;
        }

       

    }
    
    void Laser()
    {
        objectiuEnemic.QuantitatVidaQuitada(dotdamage * Time.deltaTime);
        objectiuEnemic.Freeze(freezeEnemic);

        if (!linerender.enabled)
        {
            linerender.enabled = true;
            efecteImpactat.Play();
            efecteDisparAudio.Play();
        }
            
        linerender.SetPosition(0, puntDispar.position);
        linerender.SetPosition(1, objectiu.position);

        Vector3 direccio = puntDispar.position - objectiu.position;
        efecteImpactat.transform.position = objectiu.position + direccio.normalized * 5f;

        efecteImpactat.transform.rotation = Quaternion.LookRotation(direccio);



    }

    void enemicFixat()
    {
        //Direcció a rotar del caño
        Vector3 dir = objectiu.position - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(dir);
        Vector3 rotacio = Quaternion.Lerp(td_cannon.rotation, lookRotation, Time.deltaTime * canviRotacio).eulerAngles;

        td_cannon.rotation = Quaternion.Euler(0f, rotacio.y, 0f);
    }

    void DisparTorreObjectiu(){
        //Iniciament de la bala ASSET
        GameObject balaTrajecte = (Instantiate(balaCano, puntDispar.position, puntDispar.rotation));
        Bala balaTorre = balaTrajecte.GetComponent<Bala>();

        //Passam parametre de balaTorre d'aquest objectiu
        if (balaTorre != null){
            balaTorre.TrovarObjectiu(objectiu);
        }
       
    }

    void onDrawGizmosSelected(){
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
