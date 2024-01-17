using UnityEngine;
using Zenject;

public class FruitFactory : IFruitFactory
{   
    private const string FruitPath = "Fruits/Apple";
    
    private readonly DiContainer _diContainer;

    public FruitFactory(DiContainer diContainer)
    {
        _diContainer = diContainer;
    }
    
    public FruitCollidDetector CreateFruit(Vector3Int vector)
    {
        FruitCollidDetector fruit = _diContainer.InstantiatePrefabResourceForComponent<FruitCollidDetector>(FruitPath);
        fruit.transform.position = vector;
        return fruit;
    }
}