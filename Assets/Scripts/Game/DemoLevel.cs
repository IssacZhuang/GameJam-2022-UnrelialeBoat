using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DemoLevel : BaseMapComponent
{

    public override void OnCreate()
    {
        Debug.Log("���ص�ͼ");
        base.OnCreate();
    }
}

public class RodeNode : BaseThing<BaseThingConfig>
{

    public override void OnUpdate()
    {

        base.OnUpdate();
    }
}