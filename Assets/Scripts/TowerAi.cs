using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerAi : MonoBehaviour
{
    public TowerTemplate towerTemplate;

    private SpriteRenderer spriteRend;
    private Transform target;

    private int currTowerLevel;
    private float timer;

    private void Update()
    {
        if (towerTemplate == null)
            return;

        if (target == null)
        {
            Collider2D hit = Physics2D.OverlapCircle(transform.position, towerTemplate.towerLevels[currTowerLevel].range, 1 << 6);
            if (hit != null)
                target = hit.transform;
        }

        if (target == null)
            return;

        float distanceBtwTarget = Vector2.Distance(transform.position, target.transform.position);
        if (distanceBtwTarget > towerTemplate.towerLevels[currTowerLevel].range)
        {
            target = null;
            return;
        }
        
        if (timer <= 0)
        {
            Bullet tmpBullet = Instantiate(towerTemplate.towerLevels[currTowerLevel].projectile, transform.position, Quaternion.identity).GetComponent<Bullet>();
            tmpBullet.target = target.GetComponent<Enemy>();
            tmpBullet.damage = towerTemplate.towerLevels[currTowerLevel].damage;
            timer = towerTemplate.towerLevels[currTowerLevel].rateOfFire;
        }
        else
        {
            timer -= Time.deltaTime;
        }
    }
}
