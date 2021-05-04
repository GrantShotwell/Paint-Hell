using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Text.RegularExpressions;

#if UNITY_EDITOR
using UnityEditor;
#endif

namespace FiniteStateAi {

	public class StateController : MonoBehaviour {

		public State current;

		public void UpdateState() {
			current.UpdateState(this);
		}

		public void Transition(State state) {
			if(current != state && state) {
				State old = current;
				current = state;
				OnTransition(old, state);
			}
		}

		protected virtual void OnTransition(State old, State current) {
			old.TriggerExitActions(this);
			current.TriggerEnterActions(this);
		}

		void OnDrawGizmos() {
			if(current) {
				Gizmos.color = current.color;
				Gizmos.DrawIcon(transform.position, "PreMatQuad");
			}
		}

	}

}
