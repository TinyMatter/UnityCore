using System.Collections.Generic;
using UnityEngine;

namespace TinyMatter.Core {

	[CreateAssetMenu(menuName = "Events/Game")]
	public class GameEvent : ScriptableObject {
		[Multiline] [SerializeField] private string DeveloperDescription = "";
		
		/// <summary>
		/// The list of listeners that this event will notify if it is raised.
		/// </summary>
		private readonly List<GameEventListener> eventListeners = 
			new List<GameEventListener>();

		public void Raise() {
			for (var i = eventListeners.Count - 1; i >= 0; i--)
				eventListeners[i].OnEventRaised();
		}

		public void RaiseIfTrue(bool flag) {
			if (flag) {
				Raise();
			}
		}

		public void RegisterListener(GameEventListener listener) {
			if (!eventListeners.Contains(listener))
				eventListeners.Add(listener);
		}

		public void UnregisterListener(GameEventListener listener) {
			if (eventListeners.Contains(listener))
				eventListeners.Remove(listener);
		}
	}

}