using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitDetection : MonoBehaviour
{
    [SerializeField] int hitPoints = 5;
    [SerializeField] GameObject deathFX;
    [SerializeField] AudioClip deathSFX;
    [SerializeField] AudioClip hitSFX;
    [SerializeField] Transform cameraPos;

    AudioSource audioSource;

    //EnemySpawner enemySpawner = new EnemySpawner();

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        AddBoxCollider();
        AddRigidBody();
    }

    private void AddRigidBody()
    {
        Rigidbody rigidBody = gameObject.AddComponent<Rigidbody>();
        //rigidBody.useGravity = false;
        rigidBody.isKinematic = true;
    }

    private void AddBoxCollider()
    {
        Collider boxCollider = gameObject.AddComponent<BoxCollider>();
        boxCollider.isTrigger = false;
    }

    private void OnParticleCollision(GameObject other)
    {
        Damage();
        if (hitPoints < 1)
        {
            Death();
        }
    }

    public void Death()
    {
        GameObject fx = Instantiate(deathFX, transform.position, Quaternion.identity);
        //fx.transform.parent = enemySpawner.GetParent();

        /*DeathFX.transform.position = transform.position;
        if (!DeathFX.isPlaying)
        { 
            DeathFX.Play();
        }*/
        float blastDuration = fx.GetComponent<ParticleSystem>().main.duration;
        AudioSource.PlayClipAtPoint(deathSFX, cameraPos.position);
        Destroy(fx, blastDuration);
        Destroy(gameObject);
    }

    private void Damage()
    {
        audioSource.PlayOneShot(hitSFX);
        hitPoints = hitPoints - 1;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
