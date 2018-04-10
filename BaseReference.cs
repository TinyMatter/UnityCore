namespace TinyMatter.CardClash.Core {
    public abstract class BaseReference<TVariable, TValue> where TVariable : BaseVariable<TValue> {
        public bool UseConstant = true;
        public TValue ConstantValue;
        public TVariable Variable;

        public BaseReference(TValue value) {
            UseConstant = true;
            ConstantValue = value;
        }
        
        public BaseReference() {
        }

        public TValue Value => UseConstant ? ConstantValue : Variable.Value;

        public static implicit operator TValue(BaseReference<TVariable, TValue> reference) {
            return reference.Value;
        }

        public void SetValue(TValue newValue) {
            if (UseConstant) {
                ConstantValue = newValue;
            }
            else {
                Variable.SetValue(newValue);
            }
        }
    }
}