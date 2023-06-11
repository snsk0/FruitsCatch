using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct GameParameter
{
    //â ï®ÇÃêî
    [SerializeField] private float _interval; 
    public float interval { get { return _interval; } }

    [SerializeField] private float appleRndom;
    [SerializeField] private float goldenAppleRandom;
    [SerializeField] private float stoneRandom;
    [SerializeField] private float bombRandom;

    public FruitsType getFruitsType()
    {
        float random = Random.Range(0.0f, appleRndom + goldenAppleRandom + stoneRandom + bombRandom);

        if (random < appleRndom)
        {
            return FruitsType.APPLE;
        }
        else if (random < appleRndom + goldenAppleRandom)
        {
            return FruitsType.GOLDEN_APPLE;
        }
        else if (random < appleRndom + goldenAppleRandom + stoneRandom)
        {
            return FruitsType.STONE;
        }
        else
        {
            return FruitsType.BOMB;
        }
    }
}


