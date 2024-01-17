using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonoBehaviorObj : MonoBehaviour
{
    public enum types
    {
        Plain, Object, UI
    }

    [SerializeField]
    public types type;
}
