using RSG;
using UnityEngine;

namespace TinyMatter.Core {
    public class AsyncObjectFinder : Singleton<AsyncObjectFinder> {
        private readonly IPromiseTimer promiseTimer = new PromiseTimer();

        private void Update() {
            promiseTimer.Update(Time.deltaTime);
        }

        /// <summary>
        /// Find an object in the scene by type.
        /// 
        /// For example: FindObjectOfTypeAsync&lt;CardSlotGridBehavior&gt;().Then(grid => Debug.Log("Found grid!"));
        /// </summary>
        /// <param name="timeout">in seconds</param>
        /// <typeparam name="T">The type of Component to find in the scene</typeparam>
        /// <returns>A promise that will resolve to the Component</returns>
        public IPromise<T> FindObjectOfTypeAsync<T>(float timeout = 1.0f) where T : Object {
            return new Promise<T>((resolve, reject) => {
                Promise.Race(
                    WaitUntilFoundObjectOfType<T>(),
                    TimeoutPromise(timeout)
                ).Then(() => {
                    resolve((T) Object.FindObjectOfType(typeof(T)));
                });
            });
        }

        public IPromise<T[]> FindObjectsOfTypeAsync<T>(float timeout = 1.0f) where T : Object {
            return new Promise<T[]>((resolve, reject) => {
                Promise.Race(
                    WaitUntilFoundObjectOfType<T>(),
                    TimeoutPromise(timeout)
                ).Then(() => {
                    resolve((T[]) Object.FindObjectsOfType(typeof(T)));
                });
            });
        }

        private IPromise TimeoutPromise(float seconds) {
            return promiseTimer.WaitFor(seconds);
        }

        public IPromise WaitUntilFoundObjectOfType<T>() where T : Object {
            return promiseTimer.WaitUntil(timeData => (T) Object.FindObjectOfType(typeof(T)));
        }
    }
}