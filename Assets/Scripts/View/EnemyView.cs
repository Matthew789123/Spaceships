using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyView : MonoBehaviour
{
    private EnemyPresenter enemyPresenter;
    private Object enemy;
    private Rigidbody2D rigidbody2D;

    public EnemyView()
    {
        enemyPresenter = new EnemyPresenter(this);
        enemy = Instantiate(GameObject.FindGameObjectWithTag("Respawn"), new Vector3(9, 0, 0), new Quaternion(0, 0, 45, 0));
        rigidbody2D = ((Transform)enemy).GetComponent<Rigidbody2D>();
    }

    // Start is called before the first frame update
    void Start()
    {
        rigidbody2D.velocity = new Vector2(-1, 0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
