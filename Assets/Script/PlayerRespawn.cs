using UnityEngine;

public class PlayerRespawn : MonoBehaviour
{
    private Vector3 startPosition;

    void Start()
    {
        // シーン開始時の位置を保存
        startPosition = transform.position;
    }

    void Update()
    {
        // Eキーを押したら開始位置に戻す
        if (Input.GetKeyDown(KeyCode.E))
        {
            transform.position = startPosition;
        }
    }
}
