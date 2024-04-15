using UnityEngine;

public class EnemyVision : MonoBehaviour
{
    public Transform enemyTransform; // 敌人的Transform
    public Vector3 offset; // 红圈相对于敌人的偏移量
    public float visionDistance = 1.0f; // 视线距离，即红圈前方的距离

    void Update()
    {
        if (enemyTransform != null)
        {
            // 更新红圈的位置，使其保持在敌人前方
            transform.position = enemyTransform.position + enemyTransform.forward * offset.z + enemyTransform.right * offset.x + enemyTransform.up * offset.y;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        // 检测是否为主角
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player entered enemy vision");
        }
    }
}

