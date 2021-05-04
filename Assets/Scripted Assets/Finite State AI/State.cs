using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FiniteStateAi {

    [CreateAssetMenu(fileName = "New State", menuName = "Finite State AI/State")]
    public class State : ScriptableObject {

        public Color color = Color.grey;
        public Action[] actions = new Action[] { };
        public Transition[] transitions = new Transition[] { };

        public void UpdateState(StateController controller) {
            TriggerUpdateActions(controller);
            CheckTransitions(controller);
        }

        public void TriggerEnterActions(StateController controller) {
            foreach(Action action in actions) action.TriggerEnter(controller);
		}

        public void TriggerUpdateActions(StateController controller) {
            foreach(Action action in actions) action.TriggerUpdate(controller);
		}

        public void TriggerExitActions(StateController controller) {
            foreach(Action action in actions) action.TriggerExit(controller);
		}

        public void CheckTransitions(StateController controller) {
            foreach(Transition transition in transitions) {
				State state = transition.decision.Decide(controller) ? transition.trueState : transition.falseState;
                if(state) {
                    controller.Transition(state);
                    break;
                }
			}
        }

    }

}
