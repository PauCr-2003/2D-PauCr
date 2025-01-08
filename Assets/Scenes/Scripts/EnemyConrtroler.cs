using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// El enemigo se mueva de un waypoint al siguiente
// El enemigo persiga al jugador y le cause daño si esta dentro de un rango

public class EnemyControler : MonoBehaviour
{
    public Rigidbody2D cRigidbody;
    public Transform[] waypoints;

    public float speed = 0.5f;

    private int currentPoint = 0;

    // Start is called before the first frame update

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 dir = waypoints[currentPoint].position - transform.position;
        dir.y = 0;

        cRigidbody.velocity = new Vector2(dir.normalized.x * speed, cRigidbody.velocity.y);
        Debug.Log(dir.magnitude);

        // Bucle de la patrol
        if (dir.magnitude < 0.1f)
        {
            currentPoint = (currentPoint + 1) % waypoints.Length;
            Debug.Log("He llegado al waypoint");
        }
    }
}