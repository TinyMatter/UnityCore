﻿using UnityEngine;

namespace TinyMatter.Core {
	[CreateAssetMenu(menuName = "Variables/Float")]
	public class FloatVariable : BaseVariable<float> {
		public void ApplyChange(float amount) {
			SetValue(Value + amount);
		}

		public void ApplyChange(FloatVariable amount) {
			ApplyChange(amount.Value);
		}

		public override void UpdateFromRemote() {
			var remoteValue = RemoteSettings.GetFloat(keyName, Value);
            
			initialValue = remoteValue;
		}
	}
}