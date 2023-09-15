using Collections;
using UnityEngine;

namespace Items
{
    public class Weapon : MonoBehaviour
    {
        public WeaponData data;

        public float RangePositionY => transform.position.y + data.range;

        public AudioClip GetAudioClip => data.clips[Random.Range(0, data.clips.Length)];

#if UNITY_EDITOR
        private void OnDrawGizmos()
        {
            try
            {
                //Draws a line in the range of the weapon
                Gizmos.color = Color.cyan;
                var position = transform.position;
                Gizmos.DrawLine(new Vector3(-10, RangePositionY, position.y),
                    new Vector3(10, RangePositionY, position.y));
            }
            catch (System.NullReferenceException) { }
        }
#endif

        [System.Serializable]
        public class WeaponData : ItemData
        {
            public int range = 5;
            public int power = 1;
            public string ability;
            public Sprite collectionSprite;
            public CollectionPrefs.CollectionState collectionState;
            public AudioClip[] clips;
        }
    }
}
