using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbController : MonoBehaviour
{
    [SerializeField] GameObject speedOrb;
    [SerializeField] GameObject uiSpeedOrb;

    private float timeIntervel = 5f;

    private void Awake()
    {
        speedOrb.SetActive(false);
        uiSpeedOrb.SetActive(false);
    }

    private void Update()
    {
        if(timeIntervel < Time.time )
        {
            timeIntervel = timeIntervel + 10;
            OrbStatus(true);
        }
    }
    public void OrbStatus(bool status)
    {
        speedOrb.SetActive(status);
        uiSpeedOrb.SetActive(status);
    }


}
