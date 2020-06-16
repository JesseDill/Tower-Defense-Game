using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitDetection : MonoBehaviour
{
    [SerializeField] int hitPoints = 5;
    [SerializeField] GameObject deathFX;
    [SerializeField] Transform parent;

    // Start is called before the first frame update
    void Start()
    {
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

    private void Death()
    {
        GameObject fx = Instantiate(deathFX, transform.position, Quaternion.identity);
        fx.transform.parent = parent;

        /*DeathFX.transform.position = transform.position;
        if (!DeathFX.isPlaying)
        { 
            DeathFX.Play();
        }*/
        Destroy(gameObject);
    }

    private void Damage()
    {
        hitPoints = hitPoints - 1;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
