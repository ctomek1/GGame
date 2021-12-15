using Models;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Views
{
    public class WeaponView : MonoBehaviour
    {
        [SerializeField] WeaponModel weaponModel;
        [SerializeField] Transform nozzle;
        [SerializeField] float weaponRangeForEnemies;
        [SerializeField] Animator anim;
        [SerializeField] ParticleSystem shotParticle;

        float timeToFire;
        float bulletsInMagazine;
        float currentBulletsInMagazine;
        bool isPlayingAnimation = false;


        public float WeaponRangeForEnemies { get => weaponRangeForEnemies; set => weaponRangeForEnemies = value; }
        public bool HasToReload { get => currentBulletsInMagazine <= 0; }

        public bool CanFire(float time) => time >= timeToFire;

        private void OnEnable()
        {
            bulletsInMagazine = weaponModel.BulletsInMagazine;
            currentBulletsInMagazine = bulletsInMagazine;
        }

        public void Fire(Vector3 destination)
        {
            if(!isPlayingAnimation)
            {
                if (!HasToReload)
                {
                    if (CanFire(Time.time))
                    {
                        timeToFire = Time.time + weaponModel.FireCooldown;
                        ShootProjectile(destination);
                        currentBulletsInMagazine--;
                    }
                }
                else
                {
                    Reload();
                }
            }          
        }

        void ShootProjectile(Vector3 destination)
        {
            var nozzlePosition = nozzle.position;
            var go = Instantiate(weaponModel.ProjectilePrefab, nozzlePosition, Quaternion.identity);
            shotParticle.Play();
            var rigid = go.GetComponent<Rigidbody>();
            rigid.velocity = (destination - nozzlePosition).normalized * weaponModel.ProjectileSpeed;
        }

        void Reload()
        {
            StartCoroutine(PlayAnim("Reload"));
            currentBulletsInMagazine = bulletsInMagazine;
        }

        private IEnumerator PlayAnim(string animationName)
        {
            isPlayingAnimation = true;

            anim.Play(animationName, 0, 0.0f);
            yield return new WaitForSeconds(1.0f);

            isPlayingAnimation = false;
        }
    }
}