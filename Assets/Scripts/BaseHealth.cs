using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BaseHealth : MonoBehaviour
{
    [SerializeField] int hitPoints = 20;
    [SerializeField] Text healthText;

    // Start is called before the first frame update
    void Start()
    {
        healthText.text = hitPoints.ToString();
    }
    private void OnTriggerEnter(Collider other)
    {
        hitPoints--;
        healthText.text = hitPoints.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
