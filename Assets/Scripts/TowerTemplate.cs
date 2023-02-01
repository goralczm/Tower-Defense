using UnityEngine;

[System.Serializable]
public class TowerLevel
{
    public string name;
    public int cost;
    public int health;
    public int damage;
    public float range;
    public float rateOfFire;
    public Sprite sprite;
    public GameObject projectile;
}

[CreateAssetMenu(menuName = "Towers/Basic Tower")]
public class TowerTemplate : ScriptableObject
{
    public TowerLevel[] towerLevels;
}
