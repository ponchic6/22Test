using TMPro;
using UnityEngine;
using Zenject;

public class FruitProgressIncreaser : MonoBehaviour
{
    [SerializeField] private TMP_Text _text;
    private int _maxFruitsCount;
    private int _currentCount = 0;
    private ILevelFruitCreator _levelFruitCreator;
    
    [Inject]
    public void Constructor(ILevelFruitCreator levelFruitCreator)
    {
        _levelFruitCreator = levelFruitCreator;

        SubscribeOnCollision();
    }

    private void IncreaseFruitScore(GameObject fruit)
    {
        _currentCount++;
        _text.text = _currentCount + "/" + _maxFruitsCount;
    }

    private void SubscribeOnCollision()
    {
        foreach (var keyValuePair in _levelFruitCreator.GetFruitDictionary())
        {
            keyValuePair.Value.OnCollision += IncreaseFruitScore;
        }
    }
}
