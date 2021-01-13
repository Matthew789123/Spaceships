using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyView : ShipView
{
    private System.Random rnd;
    public IState state;

    // Start is called before the first frame update
    protected override void Start()
    {
        shipPresenter = new EnemyPresenter(this);
        rnd = new System.Random();
        switch (rnd.Next(3))
        {
            case 0:
                state = new StateNormal();
                break;
            case 1:
                state = new StateRandom();
                break;
            case 2:
                state = new StateAngle();
                break;
        }
        base.Start();
    }

    protected override void FixedUpdate()
    {
        int[] input = state.move(rigidbody2D);
        shipPresenter.move(input[0], input[1]);
        base.FixedUpdate();
        shipPresenter.shoot();
    }
    
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "Player")
            ((EnemyPresenter)shipPresenter).collidePlayer();
        if (collision.name == "WallDestroy")
            destroy(0);
    }

    public override void collidePlayer(int damage)
    {
        GameObject.Find("Player").GetComponent<PlayerView>().gotHit(damage);
    }
}
