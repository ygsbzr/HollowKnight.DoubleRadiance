using System;
using System.Collections;
using System.Linq;
using System.Text;
using UnityEngine;
namespace DoubleRadiance
{
    class AbsFinder:MonoBehaviour
    {
        private void Start()
        {
            UnityEngine.SceneManagement.SceneManager.activeSceneChanged += FindAbsScene;
        }

        private void FindAbsScene(UnityEngine.SceneManagement.Scene arg0, UnityEngine.SceneManagement.Scene arg1)
        {
           
            if(arg0.name=="GG_Workshop"&&arg1.name=="GG_Radiance")
            {
                StartCoroutine(FindAbs());
            }
        }

        private IEnumerator FindAbs()
        {
            yield return new WaitWhile(() => GameObject.Find("Absolute Radiance") == null);
            GameObject absControl = new GameObject();
            absControl.AddComponent<RadianceControl>();
        }
        private void OnDestroy()
        {
            UnityEngine.SceneManagement.SceneManager.activeSceneChanged -= FindAbsScene;
        }
    }
}
