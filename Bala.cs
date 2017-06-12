using UnityEngine;

public class Bala : MonoBehaviour
{

    //Objectiu de Torre.cs
    private Transform objectiu;

    //Velocitat de la bala
    public float vel = 60f;

    //MAL DE LA BALA
    public int damageBala = 20;

    //Al ferir, feim un efecte
    public GameObject efecteHit;

    //Aquesta bala ha de teneir AOE
    public float areaofEffect = 0f;

    public AudioSource efecteDisparAudio;
    void Start()
    {
        efecteDisparAudio = GetComponent<AudioSource>();
    }
    //Trovar Objectiu
    public void TrovarObjectiu(Transform Objectiu2)
    {
        objectiu = Objectiu2;
    }

    // Update is called once per frame
    void Update()
    {
        if (objectiu == null)
        {
            Destroy(gameObject);
            return;
        }

        //Direcció de la bala
        Vector3 dir = objectiu.position - transform.position;
        float distanciaBala = vel * Time.deltaTime;

        //Distancia actual del objectiu - Si es menor, hem fet hit
        if (dir.magnitude <= distanciaBala)
        {
            TocatObjectiu();
            return;
        }

        transform.Translate(dir.normalized * distanciaBala, Space.World);
        transform.LookAt(objectiu);
    }

    void TocatObjectiu()
    {
        Debug.Log("HIT!");
        efecteDisparAudio.Play();

        if (areaofEffect > 0f)
        {
            areaOFEffect();
        }
        else
        {
            hemFerit(objectiu);
        }
        Destroy(gameObject);

    }

    void areaOFEffect()
    {
        Collider[] varColliderEnemic = Physics.OverlapSphere(transform.position, areaofEffect);
        foreach (Collider collider in varColliderEnemic)
        {
            if (collider.tag == "Enemy")
            {
                hemFerit(collider.transform);
            }

        }
    }

    void hemFerit(Transform Enemy)
    {
        Enemy enem = Enemy.GetComponent<Enemy>();

        //Enemics sense tipus
        if (enem != null)
        {
            enem.QuantitatVidaQuitada(damageBala);
        }

        GameObject effectInstance = (GameObject)Instantiate(efecteHit, transform.position, transform.rotation);
        Destroy(effectInstance, 2f);

        //Testing with objectiu per el bug que no desapareix
       //Destroy(Enemy.gameObject);
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, areaofEffect);
    }

}