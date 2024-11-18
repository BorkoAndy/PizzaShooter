using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PizzaPool : MonoBehaviour
{
    public static PizzaPool Instance;

    [SerializeField] private GameObject pizzaPrefab;
    [SerializeField] private int poolAmount;
    [SerializeField] private bool isExtensible;

    private List<GameObject> _pizzas;
   
    private void OnEnable() => Instance = this;

    private void Awake()
    {
        _pizzas = new List<GameObject>();

        for (int i = 0; i < poolAmount; i++)
        {
            GameObject newPizza = Instantiate(pizzaPrefab);
            newPizza.SetActive(false);
            _pizzas.Add(newPizza);
        }
    }

    public GameObject GetPizzaFromPool()
    {
        for(int j = 0; j < _pizzas.Count; j++)
        {
            if (!_pizzas[j].activeInHierarchy) return _pizzas[j];
        }
        if (isExtensible)
        {
            GameObject newPizza = Instantiate(pizzaPrefab);
            return newPizza;
        }
        return null;
    }
}
