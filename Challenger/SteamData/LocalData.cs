using Steamworks;
using UnityEngine;
using static ChallengerMod.Unity;

namespace ChallengerMod.Utility.Steam
{
	public class SteamScript : MonoBehaviour

	{
        private Texture2D m_LargeAvatar;
        public static int avatarInt;
        private CSteamID m_Friend;
        Rect rect = new Rect(0, 0, 184, 184);
        Vector2 pivot = new Vector2(0.5f, 0.5f);

        public static Texture2D GetSteamImageAsTexture2D(int iImage)
        {
            Texture2D ret = null;
            uint ImageWidth;
            uint ImageHeight;
            bool bIsValid = SteamUtils.GetImageSize(iImage, out ImageWidth, out ImageHeight);

            if (bIsValid)
            {
                byte[] Image = new byte[ImageWidth * ImageHeight * 4];

                bIsValid = SteamUtils.GetImageRGBA(iImage, Image, (int)(ImageWidth * ImageHeight * 4));
                if (bIsValid)
                {
                    ret = new Texture2D((int)ImageWidth, (int)ImageHeight, TextureFormat.RGBA32, false, true);
                    ret.LoadRawTextureData(Image);
                    ret.Apply();
                }
            }

            return ret;
        }

        void Start()
		{
			if (SteamManager.Initialized)
			{
				
		        string name = SteamFriends.GetPersonaName();
                m_Friend = SteamUser.GetSteamID();


                    int ret = SteamFriends.GetLargeFriendAvatar(m_Friend);
                    print("SteamFriends.GetLargeFriendAvatar(" + m_Friend + ") : " + ret);
                    m_LargeAvatar = GetSteamImageAsTexture2D(ret);
                    SteamAvatar = Sprite.Create(m_LargeAvatar, rect, pivot);

            }
		}

	}
}