using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Vocore;

public class InteractiveObject : BaseThing<BaseThingConfig>
{
    public bool isDone = false; // �Ƿ��ѽ����� TrueΪ�ѽ�����FalseΪδ����
    public int status; // 1���ؼ���Ʒ����-�ݳ� 2.�ǹؼ���Ʒ-����
    public int showStatus; // 1������չʾ 2.��ʾ 3.����ʾ 4.��̽��δ��ʾ

    public override void OnSpawn()
    {
        base.OnSpawn();
        this.BindEvent<int>(EventHoverObject.eventHoverObject, OnHover);
    }

    public void OnHover(int damage)
    {
        //do something
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
