using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxScript : MonoBehaviour
{
    [SerializeField] List<string> tagsThatCanBreak; //���� �������� ������� ����� ���������� box
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(tagsThatCanBreak.Contains(collision.transform.gameObject.tag))
        {
            Destroy(gameObject);
            //��� ����� �������� �������� ����������
        }
    }
}