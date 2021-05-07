using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FiniteStateAi {

    public abstract class Decision : ScriptableObject {

        public abstract bool Decide(StateController controller);

        /// <summary>
        /// Uses <see cref="Debug.LogError"/> to log an error message.
        /// </summary>
        /// <param name="decision">The <see cref="Decision"/> that recieved the wrong <see cref="StateController"/>.</param>
        /// <param name="controller">The <see cref="StateController"/> that was passed to the <see cref="Decision"/>.</param>
        /// <returns>Always returns <see langword="false"/>.</returns>
        protected bool LogErrorWrongController(Decision decision, StateController controller) {
            Debug.LogError($"Cannot use decision type '{decision.GetType().Name}' with a type '{controller.GetType().Name}' controller.");
            return false;
		}

    }

}
