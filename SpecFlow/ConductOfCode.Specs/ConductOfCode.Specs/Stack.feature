Feature: Stack
	In order to support last-in-first-out (LIFO) operations
	As an developer
	I want to use a stack

Scenario: Empty stack
	Given an empty stack
	Then it has no elements
	And it throws an exception when calling pop
	And it throws an exception when calling peek

Scenario: Non empty stack
	Given a non empty stack
	When calling peek
	Then it returns the top element
	But it does not remove the top element
	When calling pop
	Then it returns the top element
	And it removes the top element
