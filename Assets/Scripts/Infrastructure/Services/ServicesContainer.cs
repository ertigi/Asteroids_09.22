using System;
using System.Collections.Generic;
using UnityEngine;

public class ServicesContainer {
    private Dictionary<Type, IService> _systems;

    public ServicesContainer() {
        _systems = new Dictionary<Type, IService>();
    }

    public void Set<TService>(TService implementedService) where TService : IService {
        _systems.Add(typeof(TService), implementedService);
    }

    public TServices Get<TServices>() where TServices : class, IService {
        return _systems[typeof(TServices)] as TServices;
    }
}