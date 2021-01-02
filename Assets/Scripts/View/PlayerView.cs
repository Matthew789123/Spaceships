using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerView : MonoBehaviour
{
    private PlayerPresenter playerPresenter;
    private Rigidbody2D rigidbody2D;

    // Start is called before the first frame update
    void Start()
    {
        playerPresenter = new PlayerPresenter(this);
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            playerPresenter.shootPlayer();
        }
    }

    private void FixedUpdate()
    {
        playerPresenter.movePlayer(Input.GetAxisRaw("Vertical"), Input.GetAxisRaw("Horizontal"));
        playerPresenter.cooldownDown();
    }

    public void movePlayer(Vector2 vector)
    {
        rigidbody2D.velocity = vector;
    }

    public void gotHit(int damgae)
    {
        playerPresenter.gotHit(damgae);
    }

    public void destroyPlayer()
    {
        Destroy(gameObject);
    }

    public void shootPlayer(int projectileSpeed, int damage)
    {
        Transform player = GetComponent<Transform>();
        GameObject projectile = Instantiate(GameObject.Find("Projectile"), new Vector3(player.position.x + 0.5f, player.position.y), Quaternion.Euler(0, 0, -90));
        ProjectileView pView = projectile.AddComponent<ProjectileView>();
        pView.speed = projectileSpeed;
        pView.damage = damage;
    }
}
