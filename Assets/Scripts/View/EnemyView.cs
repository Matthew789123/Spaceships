using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyView : ShipView
{
    private System.Random rnd;
    public int type;

    // Start is called before the first frame update
    protected override void Start()
    {
        shipPresenter = new EnemyPresenter(this, type);
        rnd = new System.Random();
        base.Start();
    }

    protected override void FixedUpdate()
    {
        if (rigidbody2D.IsTouching(GameObject.Find("WallTop").GetComponent<BoxCollider2D>()))
            shipPresenter.move(-1, -1);
        else if (rigidbody2D.IsTouching(GameObject.Find("WallBottom").GetComponent<BoxCollider2D>()))
            shipPresenter.move(1, -1);
        else
            shipPresenter.move(rnd.Next(-1, 2), -1);
        base.FixedUpdate();
        shipPresenter.shoot();
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "Player")
            shipPresenter.collidePlayer();
        if (collision.name == "WallLeft")
            destroy();
    }

    protected override ProjectileView createProjectile(int projectileSpeed, Transform parent, string projectileType)
    {
        GameObject projectile = Instantiate(GameObject.Find(projectileType), new Vector3(parent.position.x - 0.7f, parent.position.y), Quaternion.Euler(0, 0, 90));
        ProjectileView pView = projectile.AddComponent<ProjectileView>();
        pView.speed = -1 * projectileSpeed;
        return pView;
    }

    public override void collidePlayer(int damage)
    {
        GameObject.Find("Player").GetComponent<PlayerView>().gotHit(damage);
    }
}
