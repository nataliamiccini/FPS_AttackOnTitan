using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerCombat : MonoBehaviour
{
    [SerializeField]  GameObject[] _weapons;
    [SerializeField]  float _rateOFFire = 0.2f;
    [SerializeField]  GameObject _muzzleFlashvfx;
    [SerializeField]  GameObject _bullet;
    //[SerializeField] private GameObject[] _bulletSpawPoint;
    [SerializeField] Transform _SpawPointT;
    [SerializeField] Transform _bulletSpawPoint;
    private bool _isArmed = false;
    private bool _isFiring = false;
    
    
    // --- Audio ---
    public AudioClip GunShotClip;
    public AudioSource source;
    public Vector2 audioPitch = new Vector2(.9f, 1.1f);

    // --- Options ---
    private bool lastScopeState;
    
    public GameObject playerCam;
    public float range = 100f;
    public float damage = 25f;
    
    public GameObject doorL;
    public GameObject doorR;
    private int enemyDead;
    
    
    // Update is called once per frame
    void Update()
    {
        //check to see if armed and if press left mouse button
        if (Input.GetMouseButtonDown(0) && _isArmed)
        {
            _muzzleFlashvfx.SetActive(true);
            _isFiring = true;
            StartCoroutine(Firing());
            
        }
        
        if (Input.GetMouseButtonUp(0) && _isArmed)
        {
            _muzzleFlashvfx.SetActive(false);
            _isFiring = false;
        }
        
        if (enemyDead == 5)
        {
            Debug.Log("Doors opened!");
            doorL.transform.rotation = Quaternion.Euler(0f, -50f, 0f);
            doorR.transform.rotation = Quaternion.Euler(0f, -140f, 0f);
        }
    }
    

    public void SetWeapon(weapon.WeapunType weaponType)
    {
        if (weaponType == weapon.WeapunType.boltGun)
        {
            _weapons[0].SetActive(true);
            _isArmed = true;
        }
            
    }

    IEnumerator Firing()
    {
        while (_isFiring)
        {
            GameObject bullet = Instantiate(_bullet, _bulletSpawPoint.position, _bulletSpawPoint.rotation);
            //fire the bullet in the direction
            bullet.GetComponent<Rigidbody>().velocity = _SpawPointT.forward * 1000 * Time.deltaTime;
            yield return new WaitForSeconds(_rateOFFire);
            RaycastHit hit;
            if (Physics.Raycast(playerCam.transform.position, transform.forward, out hit, range))
            {
                //Debug.Log("hit");
                EnemyManager enemyManager = hit.transform.GetComponent<EnemyManager>();
                EnemyManager2 enemyManager2 = hit.transform.GetComponent<EnemyManager2>();
                if (enemyManager != null)
                {
                    //then we hit an enemy
                    Debug.Log("Enemy hit!");
                    enemyManager.Hit(damage);
                    if (enemyManager.health <= 0)
                    {
                        enemyDead++;
                    }
                }
                if (enemyManager2 != null)
                {
                    //then we hit an enemy
                    Debug.Log("Big Enemy hit!");
                    enemyManager2.Hit(damage);
                }
            }
        }

        if (source != null)
        {
            // --- Sometimes the source is not attached to the weapon for easy instantiation on quick firing weapons like machineguns, 
            // so that each shot gets its own audio source, but sometimes it's fine to use just 1 source. We don't want to instantiate 
            // the parent gameobject or the program will get stuck in a loop, so we check to see if the source is a child object ---
            if(source.transform.IsChildOf(transform))
            {
                source.Play();
            }
            else
            {
                // --- Instantiate prefab for audio, delete after a few seconds ---
                AudioSource newAS = Instantiate(source);
                if ((newAS = Instantiate(source)) != null && newAS.outputAudioMixerGroup != null && newAS.outputAudioMixerGroup.audioMixer != null)
                {
                    // --- Change pitch to give variation to repeated shots ---
                    newAS.outputAudioMixerGroup.audioMixer.SetFloat("Pitch", Random.Range(audioPitch.x, audioPitch.y));
                    newAS.pitch = Random.Range(audioPitch.x, audioPitch.y);

                    // --- Play the gunshot sound ---
                    newAS.PlayOneShot(GunShotClip);

                    // --- Remove after a few seconds. Test script only. When using in project I recommend using an object pool ---
                    Destroy(newAS.gameObject, 4);
                }
            }
        }

        
    }
}
