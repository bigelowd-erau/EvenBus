using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventPublisher : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("s"))
            EventBus.TriggerEvent("Shoot");
        if (Input.GetKeyDown("t"))
            EventBus.TriggerEvent("SetTarget");
        if (Input.GetKeyDown("l"))
            EventBus.TriggerEvent("Launch");
        if (Input.GetKeyDown("r"))
            EventBus.TriggerEvent("Reload");
        if (Input.GetKeyDown("1"))
            EventBus.TriggerEvent("Key1Engage");
        if (Input.GetKeyDown("2"))
            EventBus.TriggerEvent("Key2Engage");
        if (Input.GetKeyDown("z"))
            EventBus.TriggerEvent("Key1Disengage");
        if (Input.GetKeyDown("x"))
            EventBus.TriggerEvent("Key2Disengage");
    }
}
