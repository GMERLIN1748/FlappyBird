using UnityEngine;

public class birdscript : MonoBehaviour
{
    
    /// โดดรัวๆ10
    [SerializeField]
    private float _jumpForce = 10f;

    [SerializeField]
    private GameObject _menu;

    [SerializeField]
    private GameObject _gameOver;

    private Rigidbody2D _rigidbody;

    //ตัวแปรเก็บคะแนนปัจจุบันของผู้เล่น เริ่มจ่าก0
    private int _score = 0;

    // กำหนดขอบจอ (Viewport)
    [SerializeField] private float _topBoundary = 1.05f;
    [SerializeField] private float _bottomBoundary = -0.05f;

    //เปิดให้คลาสอื่นเข้าถึงคะแนนได้ (แบบ read-only)
    public int Score
    {
        get
        {
            return _score;
        }
    }
 
    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }


    //ตรวจว่าผู้เล่นยังมีชีวิตอยู่มั้ย
    public bool IsAlive
    {
        get
        {
            return gameObject.activeSelf;
        }
    }

    
    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0)) // ตรวจว่ากด Space bar คลิกเม้าส์ มั้ย
        {
            _rigidbody.linearVelocity = new Vector2(_rigidbody.linearVelocity.x, _jumpForce);  // ไม่รุ้ ก้อปมา

        }    

        // ตรวจว่านกหลุดขอบจอเป่า
        Vector3 viewPos = Camera.main.WorldToViewportPoint(transform.position);
        if (viewPos.y > _topBoundary || viewPos.y < _bottomBoundary)
        {
            Die();  //ถ้าใช่ แกตาย
        }

    }


    //ถูกเรียกเมื่อ Player ชนกับวัตถุอื่นที่มี Collider2D และไม่ใช่ Trigger 
    //ทำให้playerตุย  รีเซ็ตscoreใหม่
    private void OnCollisionEnter2D(Collision2D collision)
    {
        gameObject.SetActive(false);   // ปิด Player
        _menu.SetActive(true);         // เปิดเมนู
        _gameOver.SetActive(true);     //เปิด GameOver UI
        _score = 0;
        Die();    

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        _score += 1;  //เพิ่มคะแนนทีละ 1 ทุกครั้งที่ Player ผ่านเสา

        // ทุกครั้งที่ได้คะแนน เพิ่มความเร็วท่อทั้งหมดในฉาก
        PipeMove[] pipes = FindObjectsOfType<PipeMove>();
        foreach (var pipe in pipes)
        {
            pipe.IncreaseSpeed(0.5f); // ค่าความเร้ว
        }
    
        //if (collision.gameObject.CompareTag("Cloud"))
        //{
          //  Die(); // ชนเม้ก ตุย
            //return;
        //}

    }

    private void Die()
    {
        gameObject.SetActive(false);
        _menu.SetActive(true);
        _gameOver.SetActive(true);
        _score = 0;
        
        
    }
}