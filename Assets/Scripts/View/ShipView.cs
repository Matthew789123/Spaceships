using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ShipView : MonoBehaviour
{
    protected ShipPresenter shipPresenter;
    protected Rigidbody2D rigidbody2D;
    
    // Start is called before the first frame update
    protected virtual void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    protected virtual void FixedUpdate()
    {
        shipPresenter.cooldownDown();
    }

    public void move(Vector2 vector)
    {
        rigidbody2D.velocity = vector;
    }

    public void gotHit(int damage)
    {
        shipPresenter.gotHit(damage);
    }

    public void destroy()
    {
        Destroy(gameObject);
    }

    public virtual void shoot(int projectileSpeed, int damage, string projectileType)
    {
        Transform parent = GetComponent<Transform>();
        ProjectileView pView = createProjectile(projectileSpeed, parent, projectileType);
        pView.damage = damage;
    }

    protected abstract ProjectileView createProjectile(int projectileSpeed, Transform parent, string projectileType); 

    public virtual void collidePlayer(int damage){}
}
