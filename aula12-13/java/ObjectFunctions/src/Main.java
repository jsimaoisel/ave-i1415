import java.util.*;


class Student {
	public String name;
	public int number;
}

class StudentComparatorByName implements Comparator<Student> {

	@Override
	public int compare(Student s1, Student s2) {
		return s1.name.compareTo(s2.name);
	}

}

class StudentComparatorByNumber implements Comparator<Student> {

	@Override
	public int compare(Student s1, Student s2) {
		return s1.number - s2.number;
	}

}

public class Main {
	public static void main(String[] args) {
		LinkedList<Student> students = new LinkedList<Student>();
		
		Collections.sort(students, new StudentComparatorByName());

		Collections.sort(students, 
			new Comparator<Student>() {
				@Override
				public int compare(Student s1, Student s2) {
					return s1.number - s2.number;
				}
			}
		);	

		Collections.sort(
			students, 
			(s1, s2) -> s1.number - s2.number
		);

	}

}















/*
Collections.sort(students, new StudentComparatorByName());
Collections.sort(students, 
new Comparator<Student>() {
	@Override
	public int compare(Student s1, Student s2) {
		return s1.number - s2.number;
	}
});
Collections.sort(
		students, 
		(s1, s2) -> s1.number - s2.number
);*/
