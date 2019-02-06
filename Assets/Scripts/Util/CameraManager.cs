using UnityEngine;

namespace Assets.Scripts.Util
{
    public class CameraManager : MonoBehaviour
    {
        public Camera cam;

        public static Camera CameraPrincipal { get; set; }

        public void Start()
        {
            DontDestroyOnLoad(this);
            CameraPrincipal = cam;
        }
    }
}
