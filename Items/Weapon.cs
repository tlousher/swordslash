using Collections;
using Items;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public Weapon_Data data;

    public float RangePositionY
    {
        get
        {
            return transform.position.y + data.range;
        }
    }

    public AudioClip GetAudioClip
    {
        get
        {
            return data.clips[Random.Range(0, data.clips.Length)];
        }
    }

#if UNITY_EDITOR
    private void OnDrawGizmos()
    {
        try
        {
            //Draws a line in the range of the weapon
            Gizmos.color = Color.cyan;
            Gizmos.DrawLine(new Vector3(-10, RangePositionY, transform.position.y),
                            new Vector3(10, RangePositionY, transform.position.y));
        }
        catch (System.NullReferenceException) { }
    }
#endif

    [System.Serializable]
    public class Weapon_Data : ItemData
    {
        public int range = 5;
        public int power = 1;
        public string ability;
        public Sprite collectionSprite;
        public CollectionPrefs.CollectionState collectionState;
        public AudioClip[] clips;
    }
}
