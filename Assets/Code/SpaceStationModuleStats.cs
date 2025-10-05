using System;
using Unity.VisualScripting;
using UnityEngine;

[CreateAssetMenu(fileName = "SpaceStationModuleStats", menuName = "Scriptable Objects/SpaceStationModuleStats")]
public class SpaceStationModuleStats : ScriptableObject
{
    public int NumberOfModules;
    public int TotalMass;
    public int TotalMaxMass;
    public float TotalBuildTime;
    public float TotalMorale;
    public float TotalChanceOFSucsess;
    public int TotalBudget;
    public int TotalCost;
    public string[] ModuleName;
    public int[] ModulePrice;
    public int[] ModuleMass;
    public float[] ModuleMorale;
    public Sprite[] ModuleSprite;
    public GameObject[] ModulePrefab;

#if UNITY_EDITOR
    private void OnValidate()
    {
        if (ModuleName.Length != NumberOfModules)             { Array.Resize(ref ModuleName, NumberOfModules); }
        if (ModulePrice.Length != NumberOfModules)            { Array.Resize(ref ModulePrice, NumberOfModules); }
        if (ModuleMass.Length != NumberOfModules)             { Array.Resize(ref ModuleMass, NumberOfModules); }
        if (ModuleMorale.Length != NumberOfModules)           { Array.Resize(ref ModuleMorale, NumberOfModules); }
        if (ModuleSprite.Length != NumberOfModules)           { Array.Resize(ref ModuleSprite, NumberOfModules); }
        if (ModulePrefab.Length != NumberOfModules)           { Array.Resize(ref ModulePrefab, NumberOfModules); }
    }

#endif
}
