using System;
using UnityEngine;

namespace Gui
{
    public class Transition : MonoBehaviour
    {
        internal static float TransitionTime;

        private void Awake()
        {
            var animator = GetComponent<Animator>();
            var stateInfo = animator.GetCurrentAnimatorStateInfo(0);
            TransitionTime = stateInfo.length;
        }
    }
}
