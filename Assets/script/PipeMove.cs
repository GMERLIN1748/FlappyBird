using UnityEngine;

public class PipeMove : MonoBehaviour
{
    [SerializeField]
    private float _moveSpeed = 3f;
    private float _minX = -20f;

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.left * _moveSpeed * Time.deltaTime;
        if (transform.position.x <= _minX)
        {
            Destroy(gameObject);
        }
    }
    
    // เรียกจาก BiBi เพื่อเพิ่มความเร็ว
    public void IncreaseSpeed(float amount)
    {
        _moveSpeed += amount;
    }
}