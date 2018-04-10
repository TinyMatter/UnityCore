
namespace TinyMatter.CardClash.Core {

	[System.Serializable]
	public class IntReference : BaseReference<IntVariable, int> {
		public IntReference(int value) : base(value) { }

		public void Decrement(int amount = 1) {
			if (UseConstant) {
				ConstantValue = ConstantValue - amount;
			}
			else {
				Variable.Decrement(amount);
			}
		}
		
		public void Increment(int amount = 1) {
			if (UseConstant) {
				ConstantValue = ConstantValue + amount;
			}
			else {
				Variable.Increment(amount);
			}
		}
	}
}