I'm writing a talk about e2e testing and this API is going to be used as a code along example. These are the examples / points I want to hit:
1. Unit test passes but system is broken
    1. Validation test
2. Breaking API change not caught
    1. Separate SUT from tests
    2. Separate DTOs defined
        1. Not bound to how API is intended to be used.
    3. Nullable properties
3. In-memory database doesn’t behave like real database
4. Common setup enforces assumptions
5. Arrange part 1 - Auth is hard
6. Arrange part 2 - test data
7. Arrange part 3 - email sending
8. Act - Interacting with the API is verbose
9. Assert part 1 - Rich error messages
10. Assert part 2 - logging
11. Assert part 3 - permissions matrix