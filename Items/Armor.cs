using Items;
using UnityEngine;

public class Armor : MonoBehaviour
{
    public Armor_Data data;

    [System.Serializable]
    public class Armor_Data : ItemData
    {
        public int resistance = 5;
        public Sprite spriteBack;
        public Sprite sprite2;
        public Sprite sprite2Back;
    }
}
