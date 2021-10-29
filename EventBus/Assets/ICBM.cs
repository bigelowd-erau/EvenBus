using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ICBM : MonoBehaviour
{
    private bool m_isQuitting;
    private bool m_IsLaunched;
    private bool m_TargetSet;
    private (bool, bool) keysEnagedStatus = (false, false);

    void OnEnable()
    {
        EventBus.StartListening("Launch", Launch);
        EventBus.StartListening("SetTarget", SetTarget);
        EventBus.StartListening("Key1Engage", Key1Engage);
        EventBus.StartListening("Key2Engage", Key2Engage);
        EventBus.StartListening("Key1Disengage", Key1Disengage);
        EventBus.StartListening("Key2Disengage", Key2Disengage);
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
            EventBus.StopListening("Key1Engage", Key1Engage);
            EventBus.StopListening("Key2Engage", Key2Engage);
            EventBus.StopListening("Key1Disengage", Key1Disengage);
            EventBus.StopListening("Key2Disengage", Key2Disengage);
        }
    }

    void Launch()
    {
        if (!m_IsLaunched && m_TargetSet && keysEnagedStatus.Item1 && keysEnagedStatus.Item2)
        {
            m_IsLaunched = true;
            Debug.Log("ICBM recieved a launch event : Ending World!");
        }
        else
        {
            if (m_IsLaunched)
                Debug.Log("ICBM recieved a launch event : ICBM already launched!");
            else
            {
                string launchErrors = "ICBM recieved a launch event :";
                if (m_TargetSet == false)
                    launchErrors += " ICBM target not set!";
                if (!keysEnagedStatus.Item1)
                    launchErrors += " ICBM key 1 not engaged!";
                if (!keysEnagedStatus.Item2)
                    launchErrors += " ICBM key 2 not engaged!";
                Debug.Log(launchErrors);
            }
        }
    }

    void SetTarget()
    {
        if (!m_IsLaunched)
        {
            if (!m_TargetSet)
                m_TargetSet = true;
            Debug.Log("ICBM recieved a set target event : set new ICBM target!");
        }
        else
        {
            Debug.Log("ICBM recieved a set target event : ICBM already launched!");
        }
    }

    void Key1Engage()
    {
        if (!keysEnagedStatus.Item1)
        {
            Debug.Log("ICBM recieved a key 1 engage event : key 1 now engaged");
            keysEnagedStatus.Item1 = true;
        }
        else
            Debug.Log("ICBM recieved a key 1 engage event : key 1 already engaged");
    }

    void Key2Engage()
    {
        if (!keysEnagedStatus.Item2)
        {
            Debug.Log("ICBM recieved a key 2 engage event : key 2 now engaged");
            keysEnagedStatus.Item2 = true;
        }
        else
            Debug.Log("ICBM recieved a key 2 engage event : key 2 already engaged");
    }

    void Key1Disengage()
    {
        if (keysEnagedStatus.Item1)
        {
            Debug.Log("ICBM recieved a key 1 disengage event : key 1 now disengaged");
            keysEnagedStatus.Item1 = false;
        }
        else
            Debug.Log("ICBM recieved a key 1 disengage event : key 1 already disengaged");
    }

    void Key2Disengage()
    {
        if (keysEnagedStatus.Item2)
        {
            Debug.Log("ICBM recieved a key 2 disengage event : key 2 now disengaged");
            keysEnagedStatus.Item2 = false;
        }
        else
            Debug.Log("ICBM recieved a key 2 disengage event : key 2 already disengaged");
    }
}
