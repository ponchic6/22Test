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
    
    public FruitCollider CreateFruit(Vector3Int vector)
    {
        FruitCollider fruit = _diContainer.InstantiatePrefabResourceForComponent<FruitCollider>(FruitPath);
        fruit.transform.position = vector;
        return fruit;
    }
}