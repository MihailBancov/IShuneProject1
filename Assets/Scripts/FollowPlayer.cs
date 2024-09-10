using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public Transform player;    // —сылка на объект игрока
    public float smoothSpeed = 0.125f;  // —корость сглаживани€ движени€ камеры
    public Vector3 offset;  // —мещение камеры относительно игрока

    // LateUpdate вызываетс€ после всех обновлений кадров, поэтому камера будет следовать за игроком плавно
    void LateUpdate()
    {
        // ќпредел€ем желаемую позицию камеры, добавив смещение к позиции игрока
        Vector3 desiredPosition = player.position + offset;

        // ѕлавно перемещаем камеру к желаемой позиции с помощью линейной интерпол€ции
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);

        // ”станавливаем новую позицию камеры
        transform.position = smoothedPosition;
    }
}
