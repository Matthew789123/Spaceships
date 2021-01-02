using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPresenter
{
    private ShipModel playerModel;
    private PlayerView view;

    public PlayerPresenter(PlayerView view)
    {
        playerModel = new PlayerModel();
        this.view = view;
    }

    public void gotHit(int damage)
    {
        playerModel.gotHit(damage);
        if (playerModel.hp == 0)
            view.destroyPlayer();
    }

    public void movePlayer(float moveInputVertical, float moveInputHorizontal)
    {
        view.movePlayer(new Vector2(moveInputHorizontal * playerModel.speed, moveInputVertical * playerModel.speed));
    }

    public void shootPlayer()
    {
        if (playerModel.cooldown == 0)
        {
            playerModel.shoot();
            view.shootPlayer(playerModel.projectileSpeed, playerModel.damage);
        }
    }

    public void cooldownDown()
    {
        playerModel.cooldownDown();
    }
}
