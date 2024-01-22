using Services;
using TMPro;
using UnityEngine;
using Zenject;

namespace Monobehavior.View
{
    public class FruitProgressIncreaser : MonoBehaviour, IFruitProgressIncreaser
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

        public void SetFruitLimit(int limit)
        {
            _maxFruitsCount = limit;
            _text.text = 0 + "/" + _maxFruitsCount;
        }

        private void IncreaseFruitScore(GameObject fruit)
        {
            _currentCount++;
            _text.text = _currentCount + "/" + _maxFruitsCount;
        }

        private void SubscribeOnCollision()
        {
            foreach (var fruit in _levelFruitCreator.FruitList)
            {
                fruit.OnCollision += IncreaseFruitScore;
            }
        }
    }
}
