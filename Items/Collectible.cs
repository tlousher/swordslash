using System;
using System.Collections;
using Collections;
using Gui;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Items
{
    public sealed class Collectible : MonoBehaviour
    {
        public ParticleSystem spark;
        public CollectibleData data;

        private Vector3 startPosition;
        private float time;
        private bool idle;

        private void Start()
        {
            switch (data.rarity)
            {
                case CollectibleData.Rarity.Common:
                    spark.transform.localScale = Vector3.one * 3;
                    break;
                case CollectibleData.Rarity.Uncommon:
                    spark.transform.localScale = Vector3.one * 4;
                    break;
                case CollectibleData.Rarity.Rare:
                    spark.transform.localScale = Vector3.one * 5;
                    break;
                case CollectibleData.Rarity.Legendary:
                    spark.transform.localScale = Vector3.one * 6;
                    break;
                case CollectibleData.Rarity.NoDrop:
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
            startPosition = transform.position;
            GetComponentInChildren<TrailRenderer>().material = data.trailMaterial;
            StartCoroutine(MoveToPlayer());
        }

        private IEnumerator MoveToPlayer()
        {
            var endPosition = Player.instance.transform.position;
            idle = true;
            StartCoroutine(Idle());
            yield return new WaitForSeconds(2.5f);
            idle = false;
            yield return new WaitForEndOfFrame();
            startPosition = transform.position;
            time = 0;
            while (time < 1)
            {
                transform.position = Vector3.Lerp(startPosition, endPosition, time);
                time += Mathf.Clamp(Time.deltaTime / 5 * (1 / Vector3.Distance(startPosition, endPosition)), 0, 1);
            }
            Destroy(gameObject, .5f);
        }

        private IEnumerator Idle()
        {
            var rise = true;
            time = 0;
            while (idle)
            {
                transform.position = Vector3.Lerp(startPosition, new Vector3(startPosition.x, startPosition.y + 2, startPosition.z), Mathf.Clamp(time, 0, 1));
                if (rise)
                {
                    time += Time.deltaTime * 2.5f;
                }
                else
                {
                    time -= Time.deltaTime * 2.5f;
                }
                if (time >= 1 || time <= 0)
                {
                    rise = !rise;
                }

                yield return new WaitForEndOfFrame();
            }
        }

        [Serializable]
        public class CollectibleData : ItemData
        {
            public Rarity rarity;
            public Material trailMaterial;
            public Sprite collectionSprite;
            public string monsterBase;
            public CollectionPrefs.CollectionState collectionState;

            public enum Rarity
            {
                NoDrop,
                Common,
                Uncommon,
                Rare,
                Legendary
            }

            public static string RarityToString(Rarity rarity)
            {
                switch (rarity)
                {
                    case Rarity.Common:
                        return Language.GetText(Language.Text.Rarity_Common);
                    case Rarity.Legendary:
                        return Language.GetText(Language.Text.Rarity_Legendary);
                    case Rarity.Rare:
                        return Language.GetText(Language.Text.Rarity_Rare);
                    case Rarity.Uncommon:
                        return Language.GetText(Language.Text.Rarity_Uncommon);
                    case Rarity.NoDrop:
                    default:
                        return null;
                }
            }

            public static Rarity GetRandomRarity()
            {
                var spin = Mathf.RoundToInt(Random.value * 100);
                var prob = 0;

                for (var i = (int)Rarity.NoDrop; i <= (int)Rarity.Legendary; i++)
                {
                    var test = (Rarity)i;
                    prob += DropProbability(test);
                    if (spin <= prob)
                    {
                        return test;
                    }
                }

                return Rarity.Legendary;
            }

            private static int DropProbability(Rarity rarity)
            {
                switch (rarity)
                {
                    case Rarity.NoDrop:
                        return 40;
                    case Rarity.Common:
                        return 40;
                    case Rarity.Uncommon:
                        return 14;
                    case Rarity.Rare:
                        return 4;
                    case Rarity.Legendary:
                        return 2;
                    default:
                        return 0;
                }
            }
        }
    }
}
