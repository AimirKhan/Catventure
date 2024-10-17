using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.Networking;

namespace Services.WebRequest
{
    public class DownloadImageHandler : MonoBehaviour
    {
        public static DownloadImageHandler Instance;

        private void Awake()
        {
            Instance = this;
        }

        public async UniTask<Texture2D> DownloadTextureCoroutine(string imageUrl)
        {
            using var request = UnityWebRequestTexture.GetTexture(imageUrl);

            await request.SendWebRequest();
        
            return request.result == UnityWebRequest.Result.Success
                ? DownloadHandlerTexture.GetContent(request)
                : null;
        }
    }
}
