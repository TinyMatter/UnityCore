
namespace TinyMatter.Core {
	[System.Serializable]
	public class FloatReference : BaseReference<FloatVariable, float> {
		public FloatReference(float value) : base(value) { }
	}
}