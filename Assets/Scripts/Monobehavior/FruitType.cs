using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitType : MonoBehaviour
{
    [SerializeField] private FruitsEnum _type;

    public FruitsEnum GetFruitType => _type;
}
