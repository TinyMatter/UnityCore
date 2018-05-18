using System;
using RSG;
using UnityEngine;

namespace TinyMatter.CardClash.Core {
    public class UnityService {
        public readonly Camera mainCamera;
        private PromiseTimer promiseTimer;

        public UnityService(Camera mainCamera) {
            this.mainCamera = mainCamera;
            promiseTimer = new PromiseTimer();
        }

        public static UnityService DefaultService() {
            return new UnityService(mainCamera: Camera.main);
        }

        public void Update() {
            promiseTimer.Update(Time.deltaTime);
        }

        public IPromise WaitFor(float seconds) {
            return promiseTimer.WaitFor(seconds);
        }

        public IPromise WaitUntil(Func<TimeData, bool> predicate) {
            return promiseTimer.WaitUntil(predicate);
        }

        public IPromise<T> FindObjectOfTypeAsync<T>(float timeout = 1.0f) where T : UnityEngine.Object {
            return AsyncObjectFinder.Instance.FindObjectOfTypeAsync<T>(timeout);
        }
    }
}