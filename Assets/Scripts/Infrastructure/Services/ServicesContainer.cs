using System;
using System.Collections.Generic;
using UnityEngine;

public class ServicesContainer {
    private Dictionary<Type, IService> _systems;

    public ServicesContainer() {
        _systems = new Dictionary<Type, IService>();
    }

    public void Set<TSystem>(TSystem implementedSystem) where TSystem : IService {
        _systems.Add(typeof(TSystem), implementedSystem);
    }

    public TServices Get<TServices>() where TServices : class, IService {
        return _systems[typeof(TServices)] as TServices;
    }
}