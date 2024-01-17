using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    [SerializeField]
    public int types;
    

    [SerializeField]
    public DunRoom targetRoom;
    public PointPosition position;

    public int tildID;

    public int x, y;

}
