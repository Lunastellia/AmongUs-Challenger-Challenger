using PowerTools;
using UnityEngine;

namespace ChallengerMod.Utility.Utils
{
    public static class SpriteAnimUtils
    {

        public static void PlayAnimation(AnimationClip clip, Vector3 position, float scale, float speed = 1f)
        {
            GameObject gameObject = new GameObject();
            gameObject.transform.position = position;
            gameObject.transform.localScale *= scale;
            gameObject.AddComponent<SpriteRenderer>();
            gameObject.AddComponent<SpriteAnim>().Play(clip, speed);
        }
        public static void PlayAnimation2(AnimationClip clip, Vector3 position, float scale, float speed = 1f)
        {
            GameObject gameObject = new GameObject();
            gameObject.transform.position = position;
            gameObject.transform.localScale *= scale;
            gameObject.AddComponent<SpriteRenderer>();
            gameObject.AddComponent<SpriteAnim>().Play(clip, speed);
            gameObject.name = "Sphere";
            
        }
        public static void StartPetrify(AnimationClip clip, Vector3 position, float scale, float speed = 1f)
        {
            GameObject gameObject = new GameObject();
            gameObject.transform.position = position;
            gameObject.transform.localScale *= scale;
            gameObject.AddComponent<SpriteRenderer>();
            gameObject.AddComponent<SpriteAnim>().Play(clip, speed);
            gameObject.name = "PetrifySprite";
            gameObject.layer = 5;

        }
        public static void StartAnimation3(AnimationClip clip, Vector3 position, float scale, float speed = 1f)
        {
            GameObject gameObject = new GameObject();
            gameObject.transform.position = position;
            gameObject.transform.localScale *= scale;
            gameObject.AddComponent<SpriteRenderer>();
            gameObject.AddComponent<SpriteAnim>().Play(clip, speed);
            gameObject.name = "LogoChallenger";
        }
        public static void StartCircle(AnimationClip clip, Vector3 position, float scale, float speed = 1f)
        {
            GameObject gameObject = new GameObject();
            gameObject.transform.position = position;
            gameObject.transform.localScale *= scale;
            gameObject.AddComponent<SpriteRenderer>();
            gameObject.AddComponent<SpriteAnim>().Play(clip, speed);
            gameObject.name = "Circle";
            gameObject.layer = 5;
        }
    }
}