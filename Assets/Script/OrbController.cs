using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbController : MonoBehaviour
{
    [SerializeField] GameObject speedOrb;
    [SerializeField] GameObject uiSpeedOrb;
    [SerializeField] GameObject passOrb;
    [SerializeField] GameObject uiPassOrb;
    [SerializeField] GameObject scoreKillOrb;
    [SerializeField] GameObject uiScoreKillOrb;
    [SerializeField] GameObject slowOrb;
    [SerializeField] GameObject uiSlowOrb;

    float deactiveTime;
    float timeIntervel = 5f;
    int option;
    

    private void Awake()
    {
        OrbStatus(false);
    }

    private void Update()
    {
        if(timeIntervel < Time.time )
        {
            deactiveTime = timeIntervel + 8;
            timeIntervel = timeIntervel + 20;
            option = Random.Range(1, 5);
            OrbStatus(option,true);
        }
        else if(Time.time > deactiveTime)
        {
            OrbStatus(false);
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
            case 3:
                scoreKillOrb.SetActive(status);
                uiScoreKillOrb.SetActive(status);
                break;
            case 4:
                slowOrb.SetActive(status);
                uiSlowOrb.SetActive(status);
                break;
        }
        
    }
    private void OrbStatus(bool status)
    {
        speedOrb.SetActive(status);
        passOrb.SetActive(status);
        scoreKillOrb.SetActive(status);
        slowOrb.SetActive(status);
        uiSpeedOrb.SetActive(status);
        uiPassOrb.SetActive(status);
        uiScoreKillOrb.SetActive(status);
        uiSlowOrb.SetActive(status);
    }

}
