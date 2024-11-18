using UnityEngine;


public class SwordHit : MonoBehaviour
{
    private Animator _animator;
    private void Start() => _animator = GetComponent<Animator>();
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))  _animator.SetTrigger("Slice");            
    }
}
