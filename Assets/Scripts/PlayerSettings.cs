using UnityEngine;

[CreateAssetMenu(menuName = "PlayerSettings")]
public class PlayerSettings : ScriptableObject
{
    public int edutainmentLevel = 0;
    public int character = 0;
    public bool[] crystalsObtained; //save progress
}
