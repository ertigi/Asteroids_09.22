using UnityEngine;

public class BigAsteroid : Asteroid {
    public override AsteroidType GetAsteroidType() =>
        AsteroidType.Big;
}