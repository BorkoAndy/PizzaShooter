using System;
using UnityEngine;

public class Window : MonoBehaviour
{
    [SerializeField] private Sprite brokenWindow;

    private SpriteRenderer _spriteRenderer;
    private CapsuleCollider2D _capsuleCollider;

    public static Action OnWindowBrake;
    

    private void Start()
    {
        _spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        _capsuleCollider = GetComponentInChildren<CapsuleCollider2D>();
    }
    private void OnTriggerEnter2D(Collider2D collision) => BrakeWindow();    

    public void BrakeWindow()
    {
        _capsuleCollider.enabled = false;
        _spriteRenderer.sprite = brokenWindow;
        OnWindowBrake?.Invoke();
        if(DataPersistance.isVibro) Handheld.Vibrate();        
    }
}
