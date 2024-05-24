using UnityEngine;
using RoR2;
using System.Collections;

namespace AssassinMod.Components
{
    public class MenuSoundComponent : MonoBehaviour
    {

        private void OnEnable()
        {
            base.StartCoroutine(this.MenuSound());
        }

        private IEnumerator MenuSound()
        {
            //wait for 0.21/30 seconds
            //play landing sound
            //at 1.08 (0.87 later) play knife 2
            //at 1.38 (0.3 later) play knife 1
            yield return new WaitForSeconds(0.21f);
            Util.PlaySound("Play_land_impact", gameObject);
            yield return new WaitForSeconds(0.87f);
            Util.PlaySound("Play_knife_draw2", gameObject);
            yield return new WaitForSeconds(0.3f);
            Util.PlaySound("Play_knife_draw1", gameObject);
            yield return null;
        }
    }
}