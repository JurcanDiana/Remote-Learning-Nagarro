# 1. Buy Use Case

## Requirement

We will continue the implementation of the Vending Machine application. In this homework we will implement the functionality of buying a product.

### Access restriction

Only the client must be able to access this functionality.

The admin is not allowed to buy products. The admin must first logout in order to be able to buy.

### Buy flow

When the client wants to buy a product, he/she will press the buy button of the vending machine. This action translates in our simulator into typing "buy" in the console. Then, the vending machine will ask the client for the column number where the product is stored. If the column number is valid and there are products on the column (quantity > 0), then the machine will dispense a product that the user can pick up from the dispenser.

> **Note:**
>
> - The paying step, that must exist before dispensing the product, will be implemented in the next homework.

### Cancel

When the user is asked to specify the product’s column id, if empty string is provided, this must be interpreted as a cancel request and the buy process must be stopped.

## Use Case Analyses

The analysis of the use case includes the following steps:

1. Description (in text)
    - Actor, Action, Steps
2. Use Case Diagram
    - Update the existing one
3. Block Diagram
4. Class Diagram
5. Code Implementation

### Use Case Description

- **Actor**: unauthenticated user
- **Action**: buy a product
- **Steps**:
  1. Ask the client to provide a column id (the id of the product to be bought)
  2. Check stock exists
  3. Ask user to pay
  4. Decrement quantity for the specified product
  5. Dispense the product

- **Alternative flows**:
  -  if column id is invalid
    - display error message
    - stop the buy process
    - return to main menu
  -  if quantity == 0 for the specified product
    - display error message
    - stop the buy process
    - return to main menu
  -  if the client cancels the buy process
    - stop the buy process
    - return to main menu

### Use Case Diagram

![Use Case Diagram](README.resources/buy%20use%20case%20-%20use%20case%20diagram.drawio.png)

### Block Diagram

![Block Diagram](README.resources/buy%20use%20case%20-%20block%20diagram.drawio.png)

### Class Diagram

![Class Diagram](README.resources/buy%20use%20case%20-%20class%20diagram.drawio.png)

### Code Implementation

This is your homework :P

# 2. Exceptions

The use cases are throwing exceptions when something is preventing it to execute until the end. Currently there are two use cases that throw exceptions:

- Login Use Case
- Buy Use Case

These exceptions should be handled in a consistent way and a nice error message should be displayed to the user. Find the best way to handle the exceptions.

## Suggestion

Identify if there is a single place where all the exceptions can be caught and displayed to the user.

Avoid duplicating the error handling code in each use case.