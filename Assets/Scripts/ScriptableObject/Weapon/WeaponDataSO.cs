using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "newWeaponData", menuName = "Data/Weapon Data/Basic Weapon Data")]
public class WeaponDataSO : ScriptableObject
{
    [field: SerializeField] public int NumberOfAttack { get; private set; }

    [field: SerializeReference] public List<ComponentData> ComponentData { get; private set; }

    [ContextMenu("Add Sprite Data")]
    private void AddSpriteData() => ComponentData.Add(new WeaponSpriteData());

    [ContextMenu("Add Movement Data")]
    private void AddMovementData() => ComponentData.Add(new WeaponMovementData());

    public T GetData<T>()
    {
        return ComponentData.OfType<T>().FirstOrDefault();
    }

}
