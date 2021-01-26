using UnityEngine;

namespace Ulma.Util {
	public abstract class SingletonMonoBehaviour<T> : MonoBehaviour where T : MonoBehaviour {
		private bool m_dontDestroyOnLoad = false;
		private static T s_instance;

		public static T Instance {
			get {
				if (s_instance == null) {
					s_instance = FindObjectOfType<T>();
					if (s_instance == null) {
						Debug.LogError("Can't find" + typeof(T) + "attached to GameObject!");
					}
				}
				return s_instance;
			}
		}

		
		protected virtual void Awake() {
			if (this != Instance) {
				Debug.LogError("Dispose " + typeof(T) + " component because it has already attached to other GameObject." +
				               "Please check" + Instance.gameObject.name + ".");
				Destroy(this);
				return;
			}

			if (m_dontDestroyOnLoad) {
				DontDestroyOnLoad(gameObject);
			}
		}
	}
}