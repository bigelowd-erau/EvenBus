using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour
{
    private bool m_isQuitting;
    private bool m_IsLaunched;
    private bool m_TargetSet;

    void OnEnable()
    {
        EventBus.StartListening("Launch", Launch);
        EventBus.StartListening("SetTarget", SetTarget);
    }

    void OnApplicationQuit()
    {
        m_isQuitting = true;
    }

    void OnDisable()
    {
        if (!m_isQuitting)
        {
            EventBus.StopListening("Launch", Launch);
            EventBus.StopListening("SetTarget", SetTarget);
        }
    }

    void Launch()
    {
        if (!m_IsLaunched && m_TargetSet)
        {
            m_IsLaunched = true;
            Debug.Log("Recieved a launch event : rocket yeeting!");
        }
        else
        {
            if (m_IsLaunched)
               Debug.Log("Recieved a launch event : rocket already launched!");
            else //m_TargetSet == false
            { 
               Debug.Log("Recieved a launch event : rocket target not set!");
            }
        }
    }

    void SetTarget()
    {
        if (!m_IsLaunched)
        {
            if (!m_TargetSet)
                m_TargetSet = true;
            Debug.Log("Recieved a set target event : set new rocket target!");
        }
        else
        {
            Debug.Log("Recieved a set target event : rocket already launched!");
        }
    }
}
