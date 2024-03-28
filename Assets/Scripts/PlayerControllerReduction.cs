using UnityEngine;

public class PlayerControllerReduction:PlayerController
{

    //�� ������� ������� � ��������� ������� ������ �������� �� �� ��� ������ ��� ���� ���� �����������, � ��� ��� ������ �������� �� ��������, ��� ���� ��� ���� ��� ������������� � �������� �� ������� ���������� ������ false ��� ������ ������� ScaleSwitch() ���� ����� ����� � ����� �� ���� ����������� ��������� � ����������� ������� 
    [SerializeField] GameObject effectSwiching;//����� ������� ��� �������� ����������
    private GameObject effectSwichingScene;
    [SerializeField] float scaleFactor = 0.5f;//��� ����������
    public Vector3 defaultScale;// ����� �����

    protected override void Start()
    {
        base.Start();
        characterTransform = transform;
        defaultScale = characterTransform.localScale;
    }

    protected override void CheckAbilityKey()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            ScaleSwitch();
            EffectSwitch();
        }
    }

    private void EffectSwitch()
    {
        effectSwichingScene = Instantiate(effectSwiching, transform.position, Quaternion.identity);
        Destroy(effectSwichingScene, 1f);
    }


    private void ScaleSwitch()
    {

        if (characterTransform.localScale != defaultScale)
        {
            characterTransform.localScale = defaultScale;
            //��� ������������� ��� ������������ � �����
        }

        else
        {
            characterTransform.localScale *= scaleFactor;
            //���� ���� �� ������ ��� ��������������, ��� ���� �������� ��������� ��������, ��������� �����,���������� ���� �������, � ���� ����� ������� ���� � ����� ����� �������� ��� ������ ��� ��������, ������ ���������
            //speed += 2f;
            //rb.mass -= 1f;
            //rb.gravityScale -= 1f;
        }
    }
}
