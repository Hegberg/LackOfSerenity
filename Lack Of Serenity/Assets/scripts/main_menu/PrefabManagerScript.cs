using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PrefabManagerScript : MonoBehaviour {

    public static bool Created = false;

    public static List<UnityEngine.Object> EnemyProjectiles = new List<UnityEngine.Object>();
    public static List<UnityEngine.Object> PlayerProjectiles = new List<UnityEngine.Object>();
    public static List<UnityEngine.Object> Players = new List<UnityEngine.Object>();
    public static List<UnityEngine.Object> Enemies = new List<UnityEngine.Object>();

    public Transform Projectile1;
    public Transform Projectile2;
    public Transform Projectile3;
    public Transform Projectile4;
    public Transform PlayerProjectile1;

    public Transform Player;

    public Transform Enemy1;
    public Transform Enemy2;
    public Transform Enemy3;
    public Transform Enemy4;

    // Use this for initialization
    void Start () {
	    if(!Created)
        {
            //Lets lists be only created once and not added to multiple times
            Created = true;

            EnemyProjectiles.Add(Projectile1);
            EnemyProjectiles.Add(Projectile2);
            EnemyProjectiles.Add(Projectile3);
            EnemyProjectiles.Add(Projectile4);

            PlayerProjectiles.Add(PlayerProjectile1);

            Players.Add(Player);

            Enemies.Add(Enemy1);
            Enemies.Add(Enemy2);
            Enemies.Add(Enemy3);
            Enemies.Add(Enemy4);
        }
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
