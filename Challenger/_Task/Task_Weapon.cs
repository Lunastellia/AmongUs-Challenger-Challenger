using System;
using HarmonyLib;
using UnityEngine;
using static ChallengerOS.Utils.Option.CustomOptionHolder;

namespace ChallengerMod.TasksUpdate
{
	internal class Weapons
	{
		

		[HarmonyPatch(typeof(Asteroid))]
		private static class AsteroidPatch
		{
			[HarmonyPatch(nameof(Asteroid.Reset))]
			[HarmonyPostfix]
			private static void AwakePostfix(Asteroid __instance)
			{
				if (__instance.gameObject.GetComponent<Rigidbody2D>()) return;
				Rigidbody2D rigidbody2D = __instance.gameObject.AddComponent<Rigidbody2D>();
				if (BetterTaskWeapon.getBool() == true)
				{
					rigidbody2D.gravityScale = 0f;
					rigidbody2D.transform.localScale = new Vector3(0.2f, 0.2f, 1f);
					rigidbody2D.velocity = new Vector2(0.1f, 0.1f);
				}
				else
                {
					rigidbody2D.gravityScale = 0f;
					rigidbody2D.transform.localScale = new Vector3(0.6f, 0.6f, 1f);
					rigidbody2D.velocity = new Vector2(1f, 1f);
				}


			}
		}


		

		internal class WeaponsCustom : MonoBehaviour
		{
			public WeaponsCustom(IntPtr ptr) : base(ptr) { }

			public void Update()
			{
			}
		}
	}
}