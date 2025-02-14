﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using System.IO;

public abstract class ShipView : MonoBehaviour
{
    protected ShipPresenter shipPresenter;
    protected Rigidbody2D rigidbody2D;
    public int type;
    public UnityEngine.UI.Text lifeText;

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
    
    public void destroy(int points)
    {
        GameObject.Find("Spawner").GetComponent<SpawnerView>().enemyDestroyed(points);
        System.Random rnd = new System.Random();
        if (rnd.Next(15) == 0)
        {
            GameObject bonus = Instantiate(GameObject.Find("LifeBonus"), new Vector3(rigidbody2D.position.x, rigidbody2D.position.y), Quaternion.identity);
            bonus.AddComponent<LifeBonusView>();
        }
        if(type==3)
        {
            CheckScore(GameObject.Find("Spawner").GetComponent<SpawnerView>().getPoints());
        }
        Destroy(gameObject); 
    }
    
    public void CheckScore(int score)
    {
       
        LeaderboardView view = new LeaderboardView();
        view.CheckScore(score);  
    }


    public void shoot(int projectileSpeed, int damage, string projectileType, float Xoffset, int rotation, float Yoffset)
    {

        GameObject projectile = Instantiate(GameObject.Find(projectileType), new Vector3(rigidbody2D.position.x + Xoffset, rigidbody2D.position.y + Yoffset), Quaternion.Euler(0, 0, rotation));
        ProjectileView pView = projectile.AddComponent<ProjectileView>();
        pView.speed = projectileSpeed;
        pView.damage = damage;
    }

    public virtual void collidePlayer(int damage) {}

    public void printLifes(int hp) 
    {
        if (hp < 0)
            hp = 0;
        lifeText.text = "Lifes: " + hp.ToString();
    }

    public void addLife() 
    {
        shipPresenter.addLife();
    }

    public void addBonus(string name)
    {
        switch (name)
        {
            case "movement":
                shipPresenter = new MovementSpeedDecorator(shipPresenter);
                break;
            case "triple":
                shipPresenter = new TripleShootDecorator(shipPresenter);
                break;
            case "rapid":
                shipPresenter = new CooldownReductionDecorator(shipPresenter);
                break;
        }
        GameObject.Find(name).GetComponent<SpriteRenderer>().sortingLayerName = "UI";
    }
}
