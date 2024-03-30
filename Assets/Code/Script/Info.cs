using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Info : MonoBehaviour
{
    [SerializeField] private GameObject image;
    [SerializeField] private Transform[] tables; // ������ ��������
    [SerializeField] private float dist;

    // ������ �� ��������� ����� ��� �������, ������� ������ �������� ���������� �� ��������
    [SerializeField] private Transform heroTransform;

    void Update()
    {
        bool shouldShowUI = false; // ���������� ��� �����������, ����� �� ���������� UI

        // ��������� ���������� �� ����� �� ������ ��������
        foreach (Transform table in tables)
        {
            if (Vector2.Distance(heroTransform.position, table.position) < dist)
            {
                shouldShowUI = true;
                break; // ���� ���������� �� ���� �� ����� �������� ������ dist, ��������� ����
            }
        }

        // �������� ��� ��������� UI � ����������� �� �������� shouldShowUI
        image.SetActive(shouldShowUI);
    }
}
