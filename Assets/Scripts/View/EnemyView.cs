using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyView : MonoBehaviour
{
    private EnemyPresenter enemyPresenter;
    private Rigidbody2D rigidbody2D;
    System.Random rnd;

    public EnemyView()
    {
        enemyPresenter = new EnemyPresenter(this);
        rnd = new System.Random();
    }

    // Start is called before the first frame update
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void FixedUpdate()
    {
        enemyPresenter.enemyMove(rnd.Next(-1, 2));
    }

    public void enemyMove(Vector2 vector)
    {
        rigidbody2D.velocity = vector;
    }
}
