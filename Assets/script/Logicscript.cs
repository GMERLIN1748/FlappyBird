using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Logicscript : MonoBehaviour
{
   ///อ้างถึงGameObject player
    //ใช้เพื่อเข้าถึงสคริปต์ PlayerController, ตั้งค่าตำแหน่ง และเปิด/ปิดผู้เล่น
    [SerializeField]
    private GameObject _player;

    //ตำแหน่งที่ผู้เล่นจะถูกวางไว้เมื่อเริ่มเกมใหม่
    //เริ่มต้นคือ (0, 0, 0) เวกเตอร์ศูนย์
    [SerializeField]
    private Vector3 _playerStartPosition = Vector3.zero;

    //MenuUI จะถูกเปิดหรือปิดตามสถานะของเกม
    [SerializeField]
    private GameObject _menuUI;

    [SerializeField]
    private TextMeshProUGUI _scoreText, _bestScoreText;
    


    private birdscript _playerController;

    private int _bestScore = 0;

    private void Start()
    {
        _playerController = _player.GetComponent<birdscript>();
    }

    private void Update()
    {
        _scoreText.text = _playerController.Score.ToString();

        if (_playerController.Score > _bestScore)  //ตรวจคะแนนของผู้เล่นในตอนเริ่มเกม สูงกว่าคะแนนสูงสุดเดิมหรือไม่
        {

            _bestScore = _playerController.Score;  //ถ้าใช่ → อัปเดตคะแนนสูงสุด และแสดงผล
            _bestScoreText.text = _bestScore.ToString();
        }

    }

    public void OnStartPressed()
    {
        _player.SetActive(true);    // เปิด Player (ให้โผล่มาเล่นได้)
        _player.transform.position = _playerStartPosition;   // ย้าย Player ไปตำแหน่งเริ่มต้น
        _menuUI.SetActive(false);  // ปิดเมนู UI

    }
}
