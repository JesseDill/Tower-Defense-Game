using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfDestruct : MonoBehaviour
{
    [SerializeField] float BlastDuration = 2f;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, BlastDuration);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
