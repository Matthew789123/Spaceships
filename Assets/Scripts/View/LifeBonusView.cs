using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeBonusView : MonoBehaviour
{
    private LifeBonusPresenter bonusPresenter;

    // Start is called before the first frame update
    void Start()
    {
        bonusPresenter = new LifeBonusPresenter(this);
    }

    private void FixedUpdate()
    {
        bonusPresenter.timeTick();
    }

    public void destroy()
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "Player")
        {
            collision.gameObject.GetComponent<PlayerView>().addLife();
            destroy();
        }
    }
}
