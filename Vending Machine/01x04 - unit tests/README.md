# Unit Tests

## Requirements

### Unit Tests

Use one of the testing frameworks:

- MSTest (Suggested)
- NUnit
- xUnit

to write automated tests for the Buy use case.

### Mocking

For mocking the external dependencies, use the "Moq" library.

For the Buy Use Case, external dependencies are the following:

- the view (that access the Console)
- the repository
- the authentication service

### Coverage

Verify the coverage of the tests for the `BuyUseCase` class using coverlet.

What percentage could you cover?

## Suggestions

### Refactoring

Some refactoring may be needed to clearly separate the business code (use case) from the external dependencies and make it testable.

> **Notes**
>
> Separating the business logic from the external dependencies has some advantages and disadvantages.
>
> Disadvantages:
>
> - Adds complexity to the architecture.
>
> Advantages
>
> - The business logic can be easily tested using automated tests.
> - The database can be easily changed later in the lifetime of the project.
> - The UI can be replaced.
>   - Actually, it is rarely encountered such a requirement, but still, the separation is very useful for allowing to easily create automated tests.
>
> Could you find some other advantages/disadvantages?