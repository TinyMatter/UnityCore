using UnityEngine;
using Sirenix.OdinInspector;

namespace TinyMatter.CardClash.Core {
	[CreateAssetMenu(menuName = "Variables/Float")]
	public class FloatVariable : BaseVariable<float> {
		public void ApplyChange(float amount) {
			SetValue(Value + amount);
		}

		public void ApplyChange(FloatVariable amount) {
			ApplyChange(amount.Value);
		}
	}
}