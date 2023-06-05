using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "newWeaponData", menuName = "Data/Weapon Data/Basic Weapon Data")]
public class WeaponDataSO : ScriptableObject
{
    [field: SerializeField] public int NumberOfAttack { get; private set; }

    [field: SerializeReference] public List<ComponentData> ComponentData { get; private set; }

    public void AddData(ComponentData data)
    {
        if(ComponentData.FirstOrDefault(t => t.GetType() == data.GetType()) != null) return;
        ComponentData.Add(data);
    }

    public T GetData<T>()
    {
        return ComponentData.OfType<T>().FirstOrDefault();
    }

    public List<Type> GetAllDependences()
    {
        return ComponentData.Select(component => component.ComponentDependency).ToList();
    }

}
