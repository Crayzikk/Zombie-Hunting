using UnityEngine;

public class LookAtMouse : MonoBehaviour
{
    void Update()
    {
        // Отримання позиції курсора миші у 2D просторі
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0f; // Задання Z-координати, оскільки ми працюємо у 2D просторі

        // Обчислення напрямку вектора до курсора
        Vector3 direction = mousePos - transform.position;

        // Обчислення кута повороту
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        // Застосування повороту об'єкту
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }
}
