using UnityEngine;

public class GrannyMove : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float mouseSensitivity;      

    private void Update()
    {       
        //Accelerometer move
        Vector3 acceleration = Input.acceleration;
        transform.Translate(acceleration.x * speed * Time.deltaTime, 0, 0);       

        // Keyboard move
        float inputHorizontal = Input.GetAxisRaw("Horizontal");
            transform.Translate(inputHorizontal * speed * Time.deltaTime, 0, 0);
    }
}
