Feature: Stack<T>

	In order to store instances of the same specified type in last-in-first-out (LIFO) sequence
	As a developer
	I want to use a Stack<T>

@Ubiquitous
Scenario: The Stack<T> shall store instances of the same specified type in last-in-first-out (LIFO) order

@Ubiquitous
Scenario: The Stack<T> shall return the number of elements contained when the property Count is invoked

@EventDriven
Scenario: When the method Push is invoked, the Stack<T> shall inserts the element at the top

@EventDriven
Scenario: When the method Pop is invoked, the Stack<T> shall remove and return the element at the top

@EventDriven
Scenario: When the method Peek is invoked, the Stack<T> shall return the element at the top without removing it

@StateDriven
Scenario: While an element is present, the Stack<T> shall return true when the method Contains is invoked

@StateDriven
Scenario: While an element is not present, the Stack<T> shall return false when the method Contains is invoked

@UnwantedBehavior
Scenario: If empty and the method Pop is invoked, then the Stack<T> shall throw InvalidOperationException

@UnwantedBehavior
Scenario: If empty and the method Peek is invoked, then the Stack<T> shall throw InvalidOperationException

@Optional
Scenario: Where instantiated with a specified collection, the Stack<T> shall be pre-populated with the elements of the collection
