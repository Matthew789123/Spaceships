using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerView : ShipView
{
    // Start is called before the first frame update
    protected override void Start()
    {
        shipPresenter = new PlayerPresenter(this);
        base.Start();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            shipPresenter.shoot();
        }
    }

    protected override void FixedUpdate()
    {
        shipPresenter.move(Input.GetAxisRaw("Vertical"), Input.GetAxisRaw("Horizontal"));
        base.FixedUpdate();
    }

    protected override ProjectileView createProjectile(int projectileSpeed, Transform parent, string projectileType)
    {
        GameObject projectile = Instantiate(GameObject.Find(projectileType), new Vector3(parent.position.x + 0.7f, parent.position.y), Quaternion.Euler(0, 0, -90));
        ProjectileView pView = projectile.AddComponent<ProjectileView>();
        pView.speed = projectileSpeed;
        return pView;
    }
}
