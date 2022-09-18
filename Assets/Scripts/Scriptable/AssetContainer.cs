using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "_Scriptable Objects/Asset Container", fileName = "Asset Container")]
public class AssetContainer : ScriptableObject {
    [Header("Player")]
    public ShipMoveTest ShipMoveTest;
    public Bullet Bullet;
    [Header("Asteroids")]
    public SmallAsteroid SmallAsteroid;
    public MediumAsteroid MediumAsteroid;
    public BigAsteroid BigAsteroid;
}