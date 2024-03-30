using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Info : MonoBehaviour
{
    [SerializeField] private GameObject image;
    [SerializeField] private Transform[] tables; // Массив табличек
    [SerializeField] private float dist;

    // Ссылка на трансформ героя или объекта, который должен смотреть расстояние до табличек
    [SerializeField] private Transform heroTransform;

    void Update()
    {
        bool shouldShowUI = false; // Переменная для определения, нужно ли отображать UI

        // Проверяем расстояние от героя до каждой таблички
        foreach (Transform table in tables)
        {
            if (Vector2.Distance(heroTransform.position, table.position) < dist)
            {
                shouldShowUI = true;
                break; // Если расстояние до хотя бы одной таблички меньше dist, прерываем цикл
            }
        }

        // Включаем или выключаем UI в зависимости от значения shouldShowUI
        image.SetActive(shouldShowUI);
    }
}
