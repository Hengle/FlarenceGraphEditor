using UnityEngine.SceneManagement;

namespace FLLib.UnityDependent {
    public class SceneLoadHelper {

        public static void loadScene(string sceneName) {
            System.GC.Collect();
            SceneManager.LoadScene(sceneName);
        }
        
        public static void loadScene(int sceneIndex) {
            System.GC.Collect();
            SceneManager.LoadScene(sceneIndex);
        }
        
    }
}