using UnityEngine;
using DG.Tweening;
using Sirenix.OdinInspector;

[CreateAssetMenu(menuName = "Animation/Setting")]
public class AnimationSetting : ScriptableObject {
    
    [BoxGroup("Timing")] public float duration = 0.3f;
    [BoxGroup("Timing")] public bool isSpeed = false;
    [BoxGroup("Timing")] public float delay = 0f;

    [BoxGroup("Easing")] public Ease easing = Ease.InOutQuad;

    [ShowIf("ShowEasingExtras")] [BoxGroup("Easing")]
    public float overshootOrAmplitude = 1.3f;

    [ShowIf("ShowEasingExtras")] [BoxGroup("Easing")]
    public float period = 0f;
    
    private bool ShowEasingExtras() {
        if (customCurve != null) {
            return false;
        }

        bool show = false;
        
        switch (easing) {
            case Ease.InBack:
                show = true;
                break;
            case Ease.OutBack:
                show = true;
                break;
            case Ease.InOutBack:
                show = true;
                break;
            case Ease.InElastic:
                show = true;
                break;
            case Ease.OutElastic:
                show = true;
                break;
            case Ease.InOutElastic:
                show = true;
                break;
            case Ease.Flash:
                show = true;
                break;
            case Ease.InFlash:
                show = true;
                break;
            case Ease.OutFlash:
                show = true;
                break;
            case Ease.InOutFlash:
                show = true;
                break;
        }

        return show;
    }
    
    [BoxGroup("Easing")] public AnimationSettingCurve customCurve;
}

public static class AnimationExtension {
    
    public static T SetEase<T>(this T t, AnimationSetting animationSetting) where T : Tween
    {
        if ((object) t == null || !t.IsActive())
            return t;

        //custom curve
        if (animationSetting.customCurve != null) {
            return t.SetEase(animationSetting.customCurve.curve);
        }


        return t.SetEase(animationSetting.easing, animationSetting.overshootOrAmplitude, animationSetting.period);
    }
    
} 