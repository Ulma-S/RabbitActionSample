using UnityEngine;

namespace Ulma.Util {
	public abstract class StateBase : MonoBehaviour {
		private void Awake() {
			Initialize();
		}

		protected abstract void Initialize();
		
		public abstract void OnEnter();
		
		public abstract void OnUpdate();

		public abstract void OnExit();
	}
}