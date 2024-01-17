using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Xml;
using UnityEngine;
using UnityEngine.UIElements;

public class RandomEncounter
{
    // Start is called before the first frame update
    // 게임에 사용 될 랜덤 시드값 선언
    public string gameSeed;


    [SerializeField]
    public System.Random mapSeed;
    public System.Random shopSeed;
    public System.Random generalSeed;

    public int mapSeedout, shopSeedout, generalSeedout;



    // Set In Game Seeds
    public void init(string str)
    {
        mapSeed = new System.Random();
        shopSeed = new System.Random();
        generalSeed = new System.Random();
        mapSeedout = shopSeedout = generalSeedout = 0;
        gameSeed = str;
        if (gameSeed == "")
        {
            gameSeed = setRandomSeed();
        }
        int seedHash = gameSeed.GetHashCode();
        mapSeed = new System.Random(seedHash);
        shopSeed = new System.Random(seedHash);
        generalSeed = new System.Random(seedHash);

    }

    // if Seed input Box filled, generate new Seeds
    public void setSeed(string seed)
    {
        init(seed);

    }

    // If input seed is null, then create random Seed
    private string setRandomSeed()
    {
        const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
        return new string(Enumerable.Repeat(chars, 8)
            .Select(s => s[generalSeed.Next(s.Length)]).ToArray());
    }

    // return mapSeed's Next
    public int getMapNext(int m = 0, int M = 100)
    {
        mapSeedout++;
        return mapSeed.Next(m, M);

    }
    // return shopSeed's Next
    public int getShopNext(int m = 0, int M = 100)
    {
        shopSeedout++;
        return shopSeed.Next(m, M);

    }
    // return generalSeed's Next
    public int getGeneralNext(int m = 0, int M = 100)
    {
        generalSeedout++;
        return generalSeed.Next(m, M);

    }

    public Double getGeneralNext(float m = 0, float M = 100)
    {
        generalSeedout++;
        return (M - m) * generalSeed.NextDouble() + m;
        
    }

}
