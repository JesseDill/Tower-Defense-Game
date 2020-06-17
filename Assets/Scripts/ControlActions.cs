using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class ControlActions : MonoBehaviour
{
    [SerializeField] Tower towerPrefab;
    bool hasTurret = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnMouseOver()
    {
        if (CrossPlatformInputManager.GetButtonDown("Fire1") && !hasTurret)
        {
            Instantiate(towerPrefab, new Vector3(transform.position.x, 0f, transform.position.z), Quaternion.identity);
            hasTurret = true;
        }
    }

}
