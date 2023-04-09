using System;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEditor.Callbacks;

[CustomEditor(typeof(WeaponDataSO))]
public class WeaponDataSOEditor : Editor
{
    private static List<Type> dataCompTypes = new();

    private WeaponDataSO dataSO;

    private bool showForceUpdateButtons;
    private bool showAddComponentsButtons;

    private void OnEnable()
    {
        dataSO = target as WeaponDataSO;
    }

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        if (GUILayout.Button("Set Number of Attack"))
        {
            foreach (var item in dataSO.ComponentData)
            {
                item.InitializeAttackData(dataSO.NumberOfAttack);
            }
        }

        showAddComponentsButtons = EditorGUILayout.Foldout(showAddComponentsButtons, "Add Components");

        if (showAddComponentsButtons) 
        {
            foreach (Type dataCompType in dataCompTypes)
            {
                if(GUILayout.Button($"{dataCompType.Name}"))
                {
                    var comp = Activator.CreateInstance(dataCompType) as ComponentData;
                    if(comp == null) return;
                    comp.InitializeAttackData(dataSO.NumberOfAttack);
                    dataSO.AddData(comp);
                }
            }
        }

        showForceUpdateButtons = EditorGUILayout.Foldout(showForceUpdateButtons, "Force Update Buttons");

        if (showForceUpdateButtons)
        {
            if (GUILayout.Button("Force Update Component Name"))
            {
                foreach (var item in dataSO.ComponentData)
                {
                    item.SetComponentName();
                }
            }

            if (GUILayout.Button("Force Update Attack Names"))
            {
                foreach (var item in dataSO.ComponentData)
                {
                    item.SetAttackDataNames();
                }
            }
        }

    }

    [DidReloadScripts]
    private static void OnRecompile()
    {
        var assemblies = AppDomain.CurrentDomain.GetAssemblies();
        var types = assemblies.SelectMany(assembly => assembly.GetTypes());
        var filteredTypes = types.Where(
            type => type.IsSubclassOf(typeof(ComponentData)) && !type.ContainsGenericParameters && type.IsClass
        );
        dataCompTypes = filteredTypes.ToList();
    }
}
