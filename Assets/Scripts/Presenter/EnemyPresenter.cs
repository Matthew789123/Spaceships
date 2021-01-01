using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPresenter
{
    private EnemyModel enemyModel;
    private EnemyView view;

    public EnemyPresenter(EnemyView view)
    {
        enemyModel = new EnemyModel();
        this.view = view;
    }
}
