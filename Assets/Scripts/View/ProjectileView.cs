using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileView : MonoBehaviour
{
    public int speed;
    public int damage;
    private Rigidbody2D rigidbody2D;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        rigidbody2D.velocity = new Vector2(speed, 0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (rigidbody2D.IsTouching(GameObject.Find("Player").GetComponent<BoxCollider2D>()))
            return;
        if (collision.gameObject.tag == "Enemy")
            collision.GetComponent<EnemyView>().gotHit(damage);
        Destroy(gameObject);
    }
}
