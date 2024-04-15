using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashlightController : MonoBehaviour
{
    public Transform target;  // 守卫的Transform组件
    public float rotationSpeed = 5.0f;  // 灯光旋转的速度

    private Light spotlight;  // 聚光灯组件

    void Start()
    {
        spotlight = GetComponent<Light>();  // 获取聚光灯组件
        if (spotlight == null || spotlight.type != LightType.Spot)
        {
            Debug.LogError("FlashlightController needs a Spot Light component!");
        }
    }

    void Update()
    {
        if (target != null)
        {
            // 朝向目标旋转
            Vector3 targetDirection = target.position - transform.position;
            Quaternion targetRotation = Quaternion.LookRotation(targetDirection);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
        }
    }
}

