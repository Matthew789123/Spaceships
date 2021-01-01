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
        
    }

    private void FixedUpdate()
    {
        playerPresenter.movePlayer(Input.GetAxisRaw("Vertical"));
    }

    public void movePlayer(Vector2 vector)
    {
        rigidbody2D.velocity = vector;
    }

    public void destroyPlayer()
    {
        Destroy(rigidbody2D);
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        playerPresenter.gotHit();
    }
}
