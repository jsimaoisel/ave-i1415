#include <stdlib.h>
#include <stdio.h>

typedef int(*FP)(const void*, const void *);

int comparator(const void *a, const void *b) {
	return (*(const int *)a) - (*(const int *)b);
}

int main() {
	int values[] = { 11, 2, 3, 14, 5, 16 };
	
	FP fp = comparator;

	int a = 10, b = 20;
	fp(&a, &b);
	
	int numberOfValues = sizeof(values) / sizeof(int);
	
	for (int i = 0; i < numberOfValues; ++i)
		printf("%d, ", values[i]);
	printf("\n");
	
	
	qsort(values, numberOfValues, sizeof(int), fp);
	
	
	for (int i = 0; i < numberOfValues; ++i)
		printf("%d, ", values[i]);
	printf("\n");
	return 1;
}