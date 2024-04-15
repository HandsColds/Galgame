using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    public Transform[] waypoints;  // 存储路径点的数组
    public float speed = 3.0f;     // 守卫的移动速度
    private Vector3 startPosition; // 用来保存守卫的初始位置
    private int targetIndex = 0;   // 当前目标路径点的索引
    private Vector3 targetPosition; // 当前目标位置
    private bool isReturning = false; // 标记守卫是否正在返回初始位置
    private Vector3 lastPosition;    // 上一帧的位置，用于判断移动方向

    void Start()
    {
        startPosition = transform.position; // 记录初始位置
        lastPosition = transform.position;  // 初始化上一帧位置
        if (waypoints.Length > 0)
        {
            targetPosition = waypoints[0].position; // 设置第一个路径点为初始目标位置
        }
    }

    void Update()
    {
        MoveTowardsTarget(); // 在Update中调用移动函数
    }

    private void MoveTowardsTarget()
    {
        // 移动守卫到当前目标位置
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);

        // 检查守卫是否达到当前目标位置
        if (Vector3.Distance(transform.position, targetPosition) < 0.1f)
        {
            if (!isReturning)
            {
                // 更新下一个目标位置
                targetIndex++;
                if (targetIndex >= waypoints.Length)
                {
                    targetPosition = startPosition; // 所有路径点完成后，设置目标为初始位置
                    isReturning = true; // 设置返回标志
                }
                else
                {
                    targetPosition = waypoints[targetIndex].position; // 更新到下一个路径点
                }
            }
            else
            {
                // 守卫返回到初始位置后可以停止或重新开始
                isReturning = false; // 重置返回标志
                targetIndex = 0; // 重新设置索引，以便可以重新开始巡逻
                targetPosition = waypoints[0].position; // 可选：重新设置目标为第一个路径点
            }
        }

        // 根据目标位置更新守卫的朝向，仅在相应轴上改变
        UpdateOrientation();
        lastPosition = transform.position;  // 更新上一帧位置
    }

    private void UpdateOrientation()
    {
        Vector3 movementDirection = transform.position - lastPosition;
        // 检查是哪个轴上有更大的移动
        if (Mathf.Abs(movementDirection.x) > Mathf.Abs(movementDirection.y))
        {
            // 在X轴上有较大移动，更新X轴朝向
            transform.localScale = new Vector3(Mathf.Sign(movementDirection.x), 1, 1);
        }
        else if (Mathf.Abs(movementDirection.y) > 0)
        {
            // 在Y轴上有移动，可以根据需要调整Y轴方向的表示（此处不一定需要，视视觉需求而定）
            // 可以添加如角色看上或看下的逻辑
        }
    }
}