﻿using System.Collections.Generic;
using UnityEngine;

namespace TinyMatter.CardClash.Core {

	[CreateAssetMenu]
	public class GameEvent : ScriptableObject {
		#if UNITY_EDITOR
		[Multiline]
		public string DeveloperDescription = "";
		#endif
		
		/// <summary>
		/// The list of listeners that this event will notify if it is raised.
		/// </summary>
		private readonly List<GameEventListener> eventListeners = 
			new List<GameEventListener>();

		public void Raise() {
			for (var i = eventListeners.Count - 1; i >= 0; i--)
				eventListeners[i].OnEventRaised();
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