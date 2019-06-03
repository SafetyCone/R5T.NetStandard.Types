# R5T.NetStandard.Types
A base-types library containing types that depend only on base .NET Standard functionality.

## Tour of Concepts

### Description


## Tour of Types

* [`IDescriber`](https://github.com/MinexAutomation/R5T.NetStandard.Types/wiki/IDescriber)

### `IDescriber` and `IDescriber<T>`
The `IDescriber` interface allows encapsulating the behavior of describing objects. The interface defines one method:

`IDescriber.Describe(Object)`

Description can be seen as lossy (not all object state is captured) uni-directional string serialization (object to string). Serialization implies full capture (all object state is written) and bi-directionality (object to string and string to object).

There are two interfaces, one for describing objects, and a generic interface for describing objects of a specified type:

`IDescriber<T>.Describe(T)`

The generic interface does not inherit from the non-generic interface, allowing implementers to choose for themselves whether they want to also implement general object description. Usually general object description in implementations of the generic interface involves a type-check on the input object instance to ensure it is of the specified generic type, and some handling (usually throwing an exception) if it is not. There is no need for this boiler-plate in every `IDescriber<T>` implementation, thus `IDesciber<T>` does not inherit from `IDescriber`.

### `Describer<T>`
A base-class for implementations of both `IDescriber<T>` and `IDescriber`. The base-class provides a protected abstract `Describe_Implementation(T)` method that is implemented in descendants to perform the specific description operation.

The base-class provides the boiler-plate for the non-generic `Describe(Object)` method to call the generic `Describe(T)` method. The `Describe(Object)` method checks that the input object is of type `T`, and if so, just calls the generic `Describe(T)` method. If the input object is not of type `T`, an `ArgumentException` is thrown.

### `Describer`
A static-type providing a default `IDescriber` instance (which is of type `ToStringDescriber`).

### `ToStringDescriber`
Simply calls the Object.ToString() method, and thus can be seen as a default describer implementation.

### `ToStringDescriber<T>`
Implements both `IDescriber` and `IDescriber<T>` by inheriting from `Describer<T>`.

### `FunctionalDescriber`
Allows encapsulating a `Func<object, string>` describer function as an `IDescriber` instance.

The class allows public get and set access to the function, and includes a parameterless constructor to allow setting the function after construction. This was done to allow maximum flexibility of construction, and because the `FunctionalDescriber` will usually always be used as an `IDescriber`, there is no chance for users to change the describer function.

### `TypeDescriber`
Implements `IDescriber<Type>` to describe `Type` instances using just the name of the type (not including the namespace of the type, as provided by `FullNameTypeDescriptor`).

Provides a singleton instance to avoid multiple instantiation.

### `FullNameTypeDescriber`
Implements `IDescriber<Type>` to describe `Type` instances using the full-name (name and namespace) of the type. To get only the name of the type, use `TypeDescriber`.

Provides a singleton instance to avoid multiple instantiation.

### `ObjectDescriber`
Describes both the type and value of object instances using an `IDescriber<Type>` for the type and an `IDescriber` for the value.

The class allows public get and set access to the type and value describers, and includes a parameterless constructor to allow setting properties after construction. This was done to allow maximum flexibility of construction, and because the `ObjectDescriber` will usually always be used as an `IDescriber`, there is no chance for users to change properties.

Default type-describer and value-describer instances are provided, and these instances are used to construct the provided default instance.
