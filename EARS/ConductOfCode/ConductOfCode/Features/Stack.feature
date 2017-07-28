Feature: Stack<T>

	In order to store instances of the same specified type in last-in-first-out (LIFO) sequence
	As a developer
	I want to use a Stack<T>

@Ubiquitous
Scenario: The Stack<T> shall store instances of the same specified type in last-in-first-out (LIFO) order
	Given an empty stack
	When the pushing the elements:
		| Element |
		| One     |
		| Two     |
		| Three   |
	Then the elements should be popped in the order:
		| Element |
		| Three   |
		| Two     |
		| One     |

@Ubiquitous
Scenario: The Stack<T> shall return the number of elements contained when the property Count is invoked
	Given a stack with the elements:
		| Element |
		| One     |
		| Two     |
		| Three   |
	When counting the elements
	Then the result should be 3

@EventDriven
Scenario: When the method Push is invoked, the Stack<T> shall inserts the element at the top
	Given a stack with the elements:
		| Element |
		| One     |
		| Two     |
		| Three   |
	When pushing the element "Four"
	Then the element "Four" should be on top

@EventDriven
Scenario: When the method Pop is invoked, the Stack<T> shall remove and return the element at the top
	Given a stack with the elements:
		| Element |
		| One     |
		| Two     |
		| Three   |
	When popping the element on top
	Then the result should be "Three"
	And the element "Two" should be on top

@EventDriven
Scenario: When the method Peek is invoked, the Stack<T> shall return the element at the top without removing it
	Given a stack with the elements:
		| Element |
		| One     |
		| Two     |
		| Three   |
	When peeking at the element on top
	Then the result should be "Three"
	And the element "Three" should be on top

@StateDriven
Scenario: While an element is present, the Stack<T> shall return true when the method Contains is invoked
	Given a stack with the elements:
		| Element |
		| One     |
		| Two     |
		| Three   |
	When determining if the stack contains the element "Three"
	Then the result should be true

@StateDriven
Scenario: While an element is not present, the Stack<T> shall return false when the method Contains is invoked
	Given a stack with the elements:
		| Element |
		| One     |
		| Two     |
		| Three   |
	When determining if the stack contains the element "Four"
	Then the result should be false

@UnwantedBehavior
Scenario: If empty and the method Pop is invoked, then the Stack<T> shall throw InvalidOperationException
	Given an empty stack
	When popping the element on top
	Then InvalidOperationException should be thrown

@UnwantedBehavior
Scenario: If empty and the method Peek is invoked, then the Stack<T> shall throw InvalidOperationException
	Given an empty stack
	When peeking at the element on top
	Then InvalidOperationException should be thrown

@Optional
Scenario: Where instantiated with a specified collection, the Stack<T> shall be pre-populated with the elements of the collection
	Given a stack with the elements:
		| Element |
		| One     |
		| Two     |
		| Three   |
	Then the stack should contain the elements:
		| Element |
		| Three   |
		| Two     |
		| One     |
