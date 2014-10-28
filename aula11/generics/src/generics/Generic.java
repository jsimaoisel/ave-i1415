package generics;

class Generic<T> {
	@SuppressWarnings("unchecked")
	T[] xpto = (T[]) new Object[100];
	T  value;	
	Generic(T value) {
		this.value=value;
	}

	T  getValue() {
		return value;
	}

	void setValue(T t) {
		value=t;
	}
}

