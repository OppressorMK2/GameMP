using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyAI : MonoBehaviour {

    public GameObject player;
    public float distance;
    public float speed;
    public Target target;

    void Update ()
    {
        if (player.gameObject == null)
        {
            return;
        }
        distance = Vector3.Distance(player.transform.position, transform.position);
        if (distance < 10)
        {
            attack();
        }
        if (distance < 1.2)
        {
            target.TakeDamage(100 * Time.deltaTime);
        }
    }
    void attack()
    {
        transform.position = Vector3.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, player.transform.rotation, 200f * speed * Time.deltaTime);
    }
}
