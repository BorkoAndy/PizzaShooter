using System.Collections;
using UnityEngine;

public class Bully : MonoBehaviour
{
    [SerializeField] private Transform pizzaPosition;
    [SerializeField] private Sprite upHandsSprite;
    [SerializeField] private Sprite downHandsSprite;
    [SerializeField] private float startOfTimeRange;
    [SerializeField] private float endOfTimeRange;    
    
    private int _levelMultiplier = 1;
    private float _coolingTime;
    
    private SpriteRenderer _spriteRenderer;

    private void OnEnable() => Score.OnLevelUpgrade += UpgradeLevel;
    private void OnDisable() => Score.OnLevelUpgrade -= UpgradeLevel;

    void Start()
    {        
        _coolingTime = UnityEngine.Random.Range(startOfTimeRange, endOfTimeRange);        
        _spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        StartCoroutine(ThrowPizza());        
    }
   
    private IEnumerator ThrowPizza()
    {        
        while (true)
        {            
            _spriteRenderer.sprite = upHandsSprite;
            GameObject newPizza = GetNewPizza();
            if (newPizza == null) yield return null;
            yield return new WaitForSeconds(_coolingTime - _levelMultiplier);
            _spriteRenderer.sprite = downHandsSprite;
            newPizza.GetComponent<Pizza>().Throw();
            yield return new WaitForSecondsRealtime(_coolingTime - _levelMultiplier);            
        }
    }
    private GameObject GetNewPizza()
    {
        GameObject newPizza =  PizzaPool.Instance.GetPizzaFromPool();
        if (newPizza == null) return null;
        newPizza.transform.position = pizzaPosition.position;
        newPizza.transform.rotation = pizzaPosition.rotation;
        newPizza.SetActive(true);
        return newPizza;
    }
    private void UpgradeLevel()
    {
        _levelMultiplier++;
        if (_coolingTime <= _levelMultiplier)
            _coolingTime = _levelMultiplier + 0.5f;
    }
}
