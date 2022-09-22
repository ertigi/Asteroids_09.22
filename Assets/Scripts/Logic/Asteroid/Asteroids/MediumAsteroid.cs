using UnityEngine;

public class MediumAsteroid : Asteroid {
    public override AsteroidType GetAsteroidType() =>
        AsteroidType.Medium;
}
