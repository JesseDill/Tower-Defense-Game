using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class ControlActions : MonoBehaviour
{
    //Controls Action really is more of a reference point
    public bool hasTurret = false;
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
            FindObjectOfType<TurretField>().PlaceTurret(this);
        }
    }

}
