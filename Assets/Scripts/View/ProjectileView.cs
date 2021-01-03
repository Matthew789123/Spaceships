using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileView : MonoBehaviour
{
    public int speed;
    public int damage;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Rigidbody2D>().velocity = new Vector2(speed, 0);
    }

    private void FixedUpdate()
    {
        if (!GetComponent<Renderer>().isVisible)
            Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Projectile")
            return;
        if (collision.tag == "Enemy" && speed > 0)
        {
            collision.GetComponent<EnemyView>().gotHit(damage);
            destroy();
        }
        else if (collision.name == "Player" && speed < 0)
        {
            collision.GetComponent<PlayerView>().gotHit(damage);
            destroy();
        }
    }

    private void destroy()
    {
        Destroy(gameObject);
    }
}
