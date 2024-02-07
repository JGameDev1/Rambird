using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPoolConf : MonoBehaviour
{ public List<GameObject> ProjectilePool; public GameObject PrefabProjectile;
    [Range(0, 20)]
    public int PoolSize;

    private void Start()
    {AddProjectilesToPool(PoolSize);}

    void AddProjectilesToPool(int amount)
{for (int i = 0; i < amount; i++)
 {GameObject Projectile = Instantiate(PrefabProjectile);
 Projectile.SetActive(false); ProjectilePool.Add(Projectile);
 transform.parent = transform;}}

    public GameObject RequestProjectile()
    {   for (int i = 0; i < ProjectilePool.Count; i++)
        {if (!ProjectilePool[i].activeSelf)
         {ProjectilePool[i].SetActive(true);
          return ProjectilePool[i];}
        } return ProjectilePool[0];}
}
