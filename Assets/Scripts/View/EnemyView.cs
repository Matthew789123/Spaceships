using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyView : MonoBehaviour
{
    private EnemyPresenter enemyPresenter;
    private Rigidbody2D rigidbody2D;
    private System.Random rnd;

    // Start is called before the first frame update
    void Start()
    {
        enemyPresenter = new EnemyPresenter(this);
        rnd = new System.Random();
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void FixedUpdate()
    {
        if (rigidbody2D.IsTouching(GameObject.Find("WallTop").GetComponent<BoxCollider2D>()))
            enemyPresenter.enemyMove(-1);
        else if (rigidbody2D.IsTouching(GameObject.Find("WallBottom").GetComponent<BoxCollider2D>()))
            enemyPresenter.enemyMove(1);
        else
            enemyPresenter.enemyMove(rnd.Next(-1, 2));
    }

    public void enemyMove(Vector2 vector)
    {
        rigidbody2D.velocity = vector;
    }

    public void gotHit(int damage)
    {
        enemyPresenter.gotHit(damage);
    }

    public void destroyEnemy()
    {
        Destroy(gameObject);
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "Player")
            enemyPresenter.collidePlayer();
    }

    public void collidePlayer(int damage)
    {
        GameObject.Find("Player").GetComponent<PlayerView>().gotHit(damage);
    }
}
