using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Enemy))]

public class movimentEnemic : MonoBehaviour {
    private Transform target;
    private int wavepointIndex = 0;

    private Enemy enemy;
    //Canvi de objectiu de la torre
    public float canviRotacio = -3f;

    void Start()
    {
        enemy = GetComponent<Enemy>();
        target = Waypoints.points[0];

    }

    void Update()
    {
        Vector3 dir = target.position - transform.position;
        //ROTACIO ENEMIC TESTING
        Quaternion rotation = Quaternion.LookRotation(dir);
        //ROTACIO ENEMIC TESTING
        transform.rotation = Quaternion.Lerp(transform.rotation, rotation, Time.deltaTime * canviRotacio);
        transform.Translate(dir.normalized * enemy.speed * Time.deltaTime, Space.World);

        if (Vector3.Distance(transform.position, target.position) <= 0.4f)
        {
            GetNextWaypoint();
        }

        //Si no esta atacant, el enemic tindra la velocitat normal
        enemy.speed = enemy.startingSpeed;
    }

    void GetNextWaypoint()
    {
        if (wavepointIndex >= Waypoints.points.Length - 1)
        {
            fiWaypoints();
            return;
        }
        wavepointIndex++;
        target = Waypoints.points[wavepointIndex];
    }

    void fiWaypoints()
    {
        Jugador.lives--;
        spawner.EnemicsEnPantalla--;
        Destroy(gameObject);

    }

}
