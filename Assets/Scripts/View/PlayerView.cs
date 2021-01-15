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
        float vertExtent = Camera.main.GetComponent<Camera>().orthographicSize;
        float horzExtent = vertExtent * Screen.width / Screen.height;
        rigidbody2D.position = new Vector2(-horzExtent + 1, vertExtent / 2);
        RectTransform transform = lifeText.GetComponent<RectTransform>();
        transform.position = new Vector3(-horzExtent + 1.5f, vertExtent - 0.9f);
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
}
