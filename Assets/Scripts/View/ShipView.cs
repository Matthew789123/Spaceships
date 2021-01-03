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

    public void shoot(int projectileSpeed, int damage, string projectileType, float Xoffset, int rotation, float Yoffset)
    {
        Transform parent = GetComponent<Transform>();
        GameObject projectile = Instantiate(GameObject.Find(projectileType), new Vector3(parent.position.x + Xoffset, parent.position.y + Yoffset), Quaternion.Euler(0, 0, rotation));
        ProjectileView pView = projectile.AddComponent<ProjectileView>();
        pView.speed = projectileSpeed;
        pView.damage = damage;
    }

    public virtual void collidePlayer(int damage){}
}
