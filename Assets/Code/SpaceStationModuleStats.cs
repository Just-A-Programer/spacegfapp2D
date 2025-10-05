using System;
using Unity.VisualScripting;
using UnityEngine;

[CreateAssetMenu(fileName = "SpaceStationModuleStats", menuName = "Scriptable Objects/SpaceStationModuleStats")]
public class SpaceStationModuleStats : ScriptableObject
{
    public int NumberOfModules;
    public int TotalModuleSum;
    public int TotalMass;
    public int TotalMaxMass;
    public float TotalBuildTime;
    public float TotalMorale;
    public int TotalBudget;
    public int TotalCost;
    public string[] ModuleName;
    public int[] ModulePrice;
    public int[] ModuleMass;
    public float[] ModuleMorale;
    public Sprite[] ModuleSprite;
    public GameObject[] ModulePrefab;
    public int[] ModuleAmount;
}
