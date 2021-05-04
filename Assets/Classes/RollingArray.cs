using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RollingArray<T> {

	T[] Array { get; }
	int Current { get; set; }

	public int Length => Array.Length;

	public RollingArray(int size) {
		if(size <= 1) throw new System.ArgumentException("Size must be at least 1.", nameof(size));
		Array = new T[size];
	}

	public RollingArray(int size, T population) : this(size) {
		for(int i = 0; i < size; i++) Array[i] = population;
	}

	public void Add(T item, out T last) {
		if(++Current >= Length) Current = 0;
		last = Array[Current];
		Array[Current] = item;
	}

}
