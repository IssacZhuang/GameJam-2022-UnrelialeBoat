using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Vocore;
using System.Linq;
using UnityEngine.UI;

public class ObjectBrightnessAll : BaseThing<ObjectBrightnessAllConfig>
{
    private Material[] collectedMaterials; // ����������Ĳ���

    private int isBrightenAll;
    private int shouldLightUpAll;
    private int outlineAll;
    private float thicknessAll;
    private float currentBrightnessAll;
    private float brightnessStartAll;
    //private float brightnessMiddleAll;
    private float brightnessEndAll;
    private Vector4 CurveAll;
    //private Vector4 CurveEndAll;


    private Func<float, float> speedCurve;
    //private Func<float, float> speedCurveEnd;
    private float animateStartTime;
    private float duration;
    //private float durationEnd;
    private bool isAnimateAll= false;
    //private bool isAnimateLoopAll = false;


    public override void OnSpawn()
    {
        base.OnSpawn();
        this.BindEvent(EventObjectBrightnessAll.eventDiscoverObjectAll, DiscoverObjectAll);
        //this.BindEvent(EventObjectBrightnessAll.eventUndiscoverObjectAll, UndiscoverObjectAll);
        //this.BindEvent(EventObjectBrightnessAll.eventDiscoverObjectLoopAll, DiscoverObjectLoopAll);
        //// ��ȡ��ǰ�����Renderer���������ȡ���еĵ�һ������
        //Renderer renderer = this.Instance.gameObject.GetComponent<Renderer>();
        //if (renderer != null)
        //{
        //    material = renderer.material;
        //}
        CollectMaterials();
    }

    public override void OnTick()
    {
        base.OnTick();
        if (isAnimateAll)
        {
            float _t = Mathf.Clamp01((Time.time - animateStartTime) / duration);
            //currentBrightnessAll = Mathf.Lerp(brightnessStartAll, brightnessEndAll, _t);
            currentBrightnessAll = brightnessStartAll + speedCurve(_t) * (brightnessEndAll - brightnessStartAll);
            ChangeAllPropertiesFloat(collectedMaterials, "_brightness", currentBrightnessAll);
            ChangeAllPropertiesFloat(collectedMaterials, "_thickness", thicknessAll);
            ChangeAllPropertiesInt(collectedMaterials, "_outline", outlineAll);
            ChangeAllPropertiesInt(collectedMaterials, "_isBrighten", isBrightenAll); 
            ChangeAllPropertiesInt(collectedMaterials, "_shouldLightUp", shouldLightUpAll);
            if (_t >= 1)
            {
                isAnimateAll = false;
            }
        }

        //if (isAnimateLoopAll)
        //{
        //    float _t = Mathf.Clamp01((Time.time - animateStartTime) / duration);
        //    float _tEnd = Mathf.Clamp01((Time.time - (animateStartTime+duration)) / (durationEnd + duration));
        //    float _tTotal = Mathf.Clamp01((Time.time - animateStartTime) / (durationEnd + duration));
        //    if (_t < 1)
        //    {
        //        currentBrightnessAll = brightnessStartAll + speedCurve(_t) * (brightnessMiddleAll - brightnessStartAll);
        //        ChangeAllPropertiesFloat(collectedMaterials, "_brightness", currentBrightnessAll);
        //        ChangeAllPropertiesFloat(collectedMaterials, "_thickness", thicknessAll);
        //        ChangeAllPropertiesInt(collectedMaterials, "_outline", outlineAll);
        //        ChangeAllPropertiesInt(collectedMaterials, "_isBrighten", isBrightenAll);
        //        ChangeAllPropertiesInt(collectedMaterials, "_shouldLightUp", shouldLightUpAll);
        //    }
        //    else if (_t >= 1 && _tTotal <= 1)
        //    {
        //        currentBrightnessAll = brightnessMiddleAll + speedCurveEnd(_tEnd) * (brightnessEndAll - brightnessMiddleAll);
        //        ChangeAllPropertiesFloat(collectedMaterials, "_brightness", currentBrightnessAll);
        //        ChangeAllPropertiesFloat(collectedMaterials, "_thickness", thicknessAll);
        //        ChangeAllPropertiesInt(collectedMaterials, "_outline", outlineAll);
        //        ChangeAllPropertiesInt(collectedMaterials, "_isBrighten", isBrightenAll);
        //        ChangeAllPropertiesInt(collectedMaterials, "_shouldLightUp", shouldLightUpAll);
        //    }
        //    else
        //    {
        //        isAnimateLoopAll = false;
        //    }
        //}
    }


    public void DiscoverObjectAll()
    {
        // �����¶״̬���𽥱仯����
        animateStartTime = Time.time;
        CurveAll = Config.DiscoverAnimates.curve;
        speedCurve = UtilsCurve.GenerateBizerLerpCurve(CurveAll.x, CurveAll.y, CurveAll.z, CurveAll.w);
        // ��ֵ
        isBrightenAll = Config.DiscoverAnimates.isBrighten;
        shouldLightUpAll = Config.DiscoverAnimates.shouldLightUp;
        outlineAll = Config.DiscoverAnimates.outline;
        thicknessAll = Config.DiscoverAnimates.thickness;
        brightnessStartAll = Config.DiscoverAnimates.brightnessStart;
        brightnessEndAll = Config.DiscoverAnimates.brightnessEnd;
        duration = Config.DiscoverAnimates.duration;
        // ��ǿ�ʼ����
        isAnimateAll = true;
        //isAnimateLoopAll = false;
    }

    //public void DiscoverObjectLoopAll()
    //{
    //    // �����¶״̬���𽥱仯����
    //    animateStartTime = Time.time;
    //    CurveAll = Config.DiscoverAnimatesLoop.curveStart;
    //    speedCurve = UtilsCurve.GenerateBizerLerpCurve(CurveAll.x, CurveAll.y, CurveAll.z, CurveAll.w);
    //    CurveEndAll = Config.DiscoverAnimatesLoop.curveStart;
    //    speedCurveEnd = UtilsCurve.GenerateBizerLerpCurve(CurveEndAll.x, CurveEndAll.y, CurveEndAll.z, CurveEndAll.w);
    //    // ��ֵ
    //    isBrightenAll = Config.DiscoverAnimatesLoop.isBrighten;
    //    shouldLightUpAll = Config.DiscoverAnimatesLoop.shouldLightUp;
    //    outlineAll = Config.DiscoverAnimatesLoop.outline;
    //    thicknessAll = Config.DiscoverAnimatesLoop.thickness;
    //    brightnessStartAll = Config.DiscoverAnimatesLoop.brightnessStart;
    //    brightnessMiddleAll = Config.DiscoverAnimatesLoop.brightnessMiddle;
    //    brightnessEndAll = Config.DiscoverAnimatesLoop.brightnessEnd;
    //    duration = Config.DiscoverAnimatesLoop.durationStart;
    //    durationEnd = Config.DiscoverAnimatesLoop.durationEnd;
    //    // ��ǿ�ʼ����
    //    isAnimateAll = false; 
    //    isAnimateLoopAll = true;
    //}


    //public void UndiscoverObjectAll()
    //{
    //    // ���巵��״̬���𽥱仯����
    //    animateStartTime=Time.time;
    //    CurveAll = Config.UndiscoverAnimates.curve;
    //    speedCurve = UtilsCurve.GenerateBizerLerpCurve(CurveAll.x, CurveAll.y, CurveAll.z, CurveAll.w);
    //    // ��ֵ
    //    isBrightenAll = Config.UndiscoverAnimates.isBrighten;
    //    shouldLightUpAll = Config.UndiscoverAnimates.shouldLightUp;
    //    outlineAll = Config.UndiscoverAnimates.outline;
    //    thicknessAll = Config.UndiscoverAnimates.thickness;
    //    brightnessStartAll = Config.UndiscoverAnimates.brightnessStart;
    //    brightnessEndAll = Config.UndiscoverAnimates.brightnessEnd;
    //    duration = Config.DiscoverAnimates.duration;
    //    // ��ǿ�ʼ����
    //    isAnimateAll = true;
    //    isAnimateLoopAll = false;
    //}

    public void ChangeAllPropertiesFloat(Material[] materials, string propertyName, float propertyValue)
    {
        foreach (Material material in materials)
        {
            // �������Ƿ����ָ��������
            if (material.HasProperty(propertyName))
            {
                // ��������������������ֵ
                material.SetFloat(propertyName, propertyValue);
            }
        }
    }

    public void ChangeAllPropertiesInt(Material[] materials, string propertyName, int propertyValue)
    {
        foreach (Material material in materials)
        {
            // �������Ƿ����ָ��������
            if (material.HasProperty(propertyName))
            {
                // ��������������������ֵ
                material.SetInt(propertyName, propertyValue);
            }
        }
    }

    public Material[] CollectMaterials()
    {
        // ��ʼ���洢���ʵ�����
        collectedMaterials = new Material[0];

        // ���õݹ麯�����ռ�����
        CollectMaterialsRecursive(this.Instance.gameObject.transform);

        return collectedMaterials;
    }

    private void CollectMaterialsRecursive(Transform parent)
    {
        // ��ȡ��ǰ�������Ⱦ�����
        Renderer renderer = parent.GetComponent<Renderer>();

        // �����Ⱦ�����ڣ��ռ������
        if (renderer != null)
        {
            Material[] materials = renderer.materials;

            // ����ǰ����Ĳ�����ӵ��洢������
            collectedMaterials = collectedMaterials.Concat(materials).ToArray();
        }

        // �ݹ鴦���Ӷ���
        for (int i = 0; i < parent.childCount; i++)
        {
            Transform child = parent.GetChild(i);
            CollectMaterialsRecursive(child);
        }
    }
}
