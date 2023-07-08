using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractiveObject : BaseThing<BaseThingConfig>
{
    public bool isDone = false; // �Ƿ��ѽ����� TrueΪ�ѽ�����FalseΪδ����
    public int status; // 1���ؼ���Ʒ����-�ݳ� 2.�ǹؼ���Ʒ-����
    public int showStatus; // 1������չʾ 2.��ʾ 3.����ʾ

    public override void OnSpawn()
    {
        base.OnSpawn();
    }

    public override void OnUpdate()
    {
        if (!isDone)
        {
            if (status == 1 && showStatus == 2)
            {
                // �ݳ�
                Debug.Log("�ݳ�");
            }
        }

        base.OnUpdate();
    }
}
