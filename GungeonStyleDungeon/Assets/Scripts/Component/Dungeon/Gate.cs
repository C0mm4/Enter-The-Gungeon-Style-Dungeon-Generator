using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gate : MonoBehaviorObj
{
    SpriteRenderer sprite;

    // Door Activate Handler
    public void Activate()
    {
        Debug.Log("Door Activate");
    }

    // Door DeActivate Handler
    public void DeActivate()
    {
        StartCoroutine(DeActivateCallBack());
    }

    // Door Deactivate, destroy door object 1 sec later
    public IEnumerator DeActivateCallBack()
    {
        yield return new WaitForSeconds(1);
        GameManager.Resource.Destroy(this.gameObject);
    }
}
