# Requirements

Requirements for the [`Stack<T>` Class](https://msdn.microsoft.com/en-us/library/3278tedw(v=vs.110).aspx) written the *Easy Approach to Requirements Syntax (EARS)* templates:

## Ubiquitous

> The `Stack<T>` shall store instances of the same specified type in last-in-first-out (LIFO) order.

> The `Stack<T>` shall return the number of elements contained when the property `Count` is invoked.

## Event-driven

> When the method `Push` is invoked, the `Stack<T>` shall inserts the element at the top.

> When the method `Pop` is invoked, the `Stack<T>` shall remove and return the element at the top.

> When the method `Peek` is invoked, the `Stack<T>` shall return the element at the top without removing it.

## State-driven

> While an element is present, the `Stack<T>` shall return `true` when the method `Contains` is invoked.

> While an element is not present, the `Stack<T>` shall return `false` when the method `Contains` is invoked.

## Unwanted behavior

> If empty and the method `Pop` is invoked, then the `Stack<T>` shall throw `InvalidOperationException`.

> If empty and the method `Peek` is invoked, then the `Stack<T>` shall throw `InvalidOperationException`.

## Optional

> Where instantiated with a specified collection, the `Stack<T>` shall be pre-populated with the elements of the collection.
