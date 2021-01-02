using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPresenter
{
    private PlayerModel playerModel;
    private PlayerView view;

    public PlayerPresenter(PlayerView view)
    {
        playerModel = new PlayerModel();
        this.view = view;
    }

    public void gotHit()
    {
        playerModel.gotHit();
        if (playerModel.hp == 0)
            view.destroyPlayer();
    }

    public void movePlayer(float moveInputVertical, float moveInputHorizontal)
    {
        view.movePlayer(new Vector2(moveInputHorizontal * playerModel.speed, moveInputVertical * playerModel.speed));
    }
}
