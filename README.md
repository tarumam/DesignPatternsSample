# DesignPatternsSample
Basic concepts / implementation of GOFdesign patterns and SOLID

## SOLID PRINCIPLES
- **S**ingle Responsibility Principle - A class is responsible for one thing and has one reason to change
- **O**pen Closed Principle - The system has to be open for extensions but should be closed for modifications
- **L**ISKOV Substitution Principle – Functions that use pointer to base classes must be able to use objects or derived classes without knowing it. Should be able to substitute a base type for a subtype.
- **I**nterface Segregation Principle – If we have an interface which includes too much stuff, then break it apart into smaller interfaces. So, instead of having one big interface we should have lots of smaller interfaces which are more atomic.
- **D**ependency Inversion Principle -- The high level parts of the system should not depend on low level parts of the system directly that instead they should depend on some kind of abstraction.

## DESIGN PATTERNS
Design Patterns are ways to solve common project design or architectural problems. We can apply known tested solutions for known problems. Using it we can increase quality, code organization, decrease complexity, facilitate team communication.
A pattern describes a problem that occurs repeatedly, proposes a solution and it can be implemented many times but not necessarily in the same way.

###### Construction Patterns:
- **Builder**: Is used to build an object step by step. When a piecewise object construction is complicated, provide an API for doing it succinctly; 
- **Factories**: Is used when the object creation becomes too convoluted. So it is a component responsible solely for the wholesale creation of objects (not piecewise as builder). Factory is a separated component which knows initialize types in a particular way. Abstract factory is used for hierarchical creation for example.
- **Prototype**: A partially or fully initialized object that you copy (clone) and make use of; Is used when it’s easier to deep copy an existing object to fully initialize a new one; Serialization is a good approach.
- **Singleton**: A component which is instantiated only once. Usually it is used for database repositories, factories, to prevent anyone creating additional copies and so on;
- **Façade**: Expose several components though a single interface to make the things convenient for the end user. Usually is used to decrease complexity of understanding an interface.

###### Structural Patterns:
- **Adapter**: Give us the interface that we require from the interface we have. It's a construct which adapts an existing interface X to conform to the required interface Y.
- **Bridge**: A mechanism that decouples an interface (hierarchy) from an implementation (hierarchy).
###### Behavioral Patterns:
- **Chain of Responsibility**: It can be implemented as a bunch of references from a component pointing to another, composing a chain. This chain can be programmatically broken if you wish.
