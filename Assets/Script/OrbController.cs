using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbController : MonoBehaviour
{
    [SerializeField] GameObject speedOrb;
    [SerializeField] GameObject uiSpeedOrb;
    [SerializeField] GameObject passOrb;
    [SerializeField] GameObject uiPassOrb;

    float timeIntervel = 5f;
    int option;
    

    private void Awake()
    {
        speedOrb.SetActive(false);
        uiSpeedOrb.SetActive(false);
        passOrb.SetActive(false);
        uiPassOrb.SetActive(false);
    }

    private void Update()
    {
        if(timeIntervel < Time.time )
        {
            timeIntervel = timeIntervel + 20;
            option = Random.Range(1, 3);
            OrbStatus(option,true);
        }
    }
    public void OrbStatus(int option ,bool status)
    {
        switch(option)
        {
            case 1:
                speedOrb.SetActive(status);
                uiSpeedOrb.SetActive(status);
                break;
            case 2:
                passOrb.SetActive(status);
                uiPassOrb.SetActive(status);
                break;
        }
        
    }


}
