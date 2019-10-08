using UnityEngine;

[CreateAssetMenu(menuName = "MyPlayerSettings")]
public class MyPlayerSettings : ScriptableObject
{
    public int edutainmentLevel = 0;
    public int character = 0;
    public bool[] crystalsObtained = new bool[3]; //save progress
}
