using System.Collections;
using UnityEngine;

//DATA MODIFICACIO: 25/03/2017
//Bloquejarem les torres amb l'objectiu
//Amb el mateix Script, dispararem a l'objectiu

public class Torre : MonoBehaviour {

    //Variable per l'objectiu de la torre
    private Transform objectiu;
    //Rang de la torre
    public float range = 50f;
    //Tag per els enemics
    public string enemicsTag = "Enemy";
    //Canvi de objectiu de la torre
    public float canviRotacio = 10f;

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

	// Use this for initialization
	void Start () {
		InvokeRepeating("UpdateObjectiu", 0f, 0.5f);
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
        }
        else
            objectiu = null;
    }

    // Update is called once per frame
    void Update()
    {
        if (objectiu == null)
            return;

        //Direcció a rotar del caño
        Vector3 dir = objectiu.position - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(dir);
        Vector3 rotacio = Quaternion.Lerp(td_cannon.rotation, lookRotation, Time.deltaTime*canviRotacio).eulerAngles;

        td_cannon.rotation = Quaternion.Euler(0f, rotacio.y, 0f);

        if(cddisparTorre <= 0f){
            DisparTorreObjectiu();
            cddisparTorre = 1f / disparTorre;
        }

        //El CD del dispar será reduit cada segon
        cddisparTorre -= Time.deltaTime;

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
