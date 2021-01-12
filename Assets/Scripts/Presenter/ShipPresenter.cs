using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public abstract class ShipPresenter
{
    public ShipModel shipModel;
    public ShipView view;
    public SpawnerModel spawner;
    public Leaderboards leaderboards;

    private int score;

    public ShipPresenter(ShipView view)
    {
        this.view = view;
        spawner = SpawnerModel.getInstance();
    }

    public virtual void move(float moveVertical, float moveHorizontal)
    {
        view.move(new Vector2(moveHorizontal * shipModel.speed, moveVertical * shipModel.speed));
    }

    public virtual void gotHit(int damage)
    {
        shipModel.gotHit(damage);
        score = spawner.points;
        if (shipModel.hp <= 0)
        {
            view.destroy(shipModel.points);
            if (view.type == 3)
            {
                CheckScore(score);
                SceneManager.LoadScene("menu");
            }
                
        }
            
    }

    public void CheckScore(int score)
    {
        string jsonString = PlayerPrefs.GetString("leaderboards");
        Leaderboards.Leaderboard scores = JsonUtility.FromJson<Leaderboards.Leaderboard>(jsonString);
        for (int i = 0; i < scores.entryList.Count; i++)
        {
            if (score > scores.entryList[i].score)
            {
                Leaderboards.Entry entry = new Leaderboards.Entry { score = score, name = "TEST" };
                scores.entryList.Insert(i, entry);
                scores.entryList.RemoveAt(scores.entryList.Count - 1);
                break;
            }
        }
        string json = JsonUtility.ToJson(scores);
        PlayerPrefs.SetString("leaderboards", json);
        PlayerPrefs.Save();
        
    }



    public virtual void shoot()
    {
        if (shipModel.cooldown == 0)
        {
            shipModel.shoot();
            view.shoot(shipModel.projectileSpeed, shipModel.damage, shipModel.projectileType, shipModel.offset, shipModel.rotation, 0);
        }
    }

    public virtual void cooldownDown()
    {
        shipModel.cooldownDown();
    }

    public virtual void collidePlayer() {}

    public virtual void addLife()
    {
        shipModel.addLife();
        view.printLifes(shipModel.hp);
    }
}
