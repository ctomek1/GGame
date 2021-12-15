using UnityEngine;

namespace Models
{
    [CreateAssetMenu(menuName = "Models/WeaponModel")]
    public class WeaponModel : ScriptableObject
    {
        [SerializeField] float fireCooldown = 1f;
        [SerializeField] float projectileSpeed = 10;
        [SerializeField] GameObject projectilePrefab;
        [SerializeField] float reloadTime = 3f;
        [SerializeField] float bulletsInMagazine = 10;
        
        public float FireCooldown => fireCooldown;
        public float ProjectileSpeed => projectileSpeed;
        public GameObject ProjectilePrefab => projectilePrefab;
        public float ReloadTime { get => reloadTime; set => reloadTime = value; }
        public float BulletsInMagazine { get => bulletsInMagazine; set => bulletsInMagazine = value; }
    }
}