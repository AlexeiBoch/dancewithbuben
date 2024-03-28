using UnityEngine;

public class PlayerControllerReduction:PlayerController
{

    //из данного скрипта я впринцепе вырезал логику проверки на то что сверху над нами есть препядствие, а так оно должно работать по принцепу, что если над нами луч соприкасается с обьектом мы булевую переменную делаем false чем блочим функцию ScaleSwitch() чтоб грубо говря в кишке не было возможности вернуться к нормальному размеру 
    [SerializeField] GameObject effectSwiching;//вызов эффекта для сокрытия уменьшения
    private GameObject effectSwichingScene;
    [SerializeField] float scaleFactor = 0.5f;//коф уменьшения
    public Vector3 defaultScale;// дефот скейл

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
            //тут соответсвенно все возвращается в норму
        }

        else
        {
            characterTransform.localScale *= scaleFactor;
            //ниже типа мы меняем ему характеристики, все таки наверное уменьшаем скорость, уменьшаем массу,гравитацию ебал трогать, и силу обоих прыжком тоже я думаю стоит порезать это просто как заглушка, сделай нормально
            //speed += 2f;
            //rb.mass -= 1f;
            //rb.gravityScale -= 1f;
        }
    }
}
