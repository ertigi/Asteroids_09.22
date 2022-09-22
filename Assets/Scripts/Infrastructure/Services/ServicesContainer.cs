using System;
using System.Collections.Generic;
using UnityEngine;

public class ServicesContainer {
    private Dictionary<Type, IService> _services;

    public ServicesContainer() {
        _services = new Dictionary<Type, IService>();
    }

    public void Set<TService>(TService implementedService) where TService : IService {
        _services.Add(typeof(TService), implementedService);
    }

    public TServices Get<TServices>() where TServices : class, IService {
        return _services[typeof(TServices)] as TServices;
    }
}