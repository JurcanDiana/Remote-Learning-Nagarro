# Payment Mechanism

## Requirements

When the client buys a product, before getting it, a Payment must be made. The vending machine should support the following payment methods:

- With cash: coins/banknotes
- With credit card

### Payment flow

- The client specifies the selected product by typing the column number of the product.
- The client selects the payment method: Cash or Credit Card.
- The client pays the necessary amount.
- The machine gives back change if needed. (for cash payment only)
- The product is dispensed.

### Cash Payment

If user selects the cash payment, the vending machine will wait for the user to insert banknotes or coins, until the price of the product is reached. If necessary, the machine must give back change.

**Optional (for fun):**

Give back change using only real units of the Leu (1 ban, 5 bani, 10 bani, 50 bani, 1 leu, 5 lei, 10 lei, 50 lei 100 lei, 200 lei, 500 lei). You may consider that the machine has unlimited supply of banknotes and coins.

### Card Payment

If card payment is selected, the user must provide a card number.

**Optional (also fun):**

The inserted card number must be checked to have a valid format. This is done using the Luhn algorithm (https://en.wikipedia.org/wiki/Luhn_algorithm).

## Use Case Analysis

The payment is approached in this analysis like a use case even if, in reality, it is a sub use case.

The difference between a use case and a sub use case is that the later cannot be accessed directly. It can just be called by another use case.

### Use Case Description

- **Actor**: Buy Use Case
- **Action**: payment is requested for the selected product
- **Steps**:
  1. ask the client to select a payment method from a list
  2. client provides the money
  3. give back change if necessary

- **Alternative flows**:
  - if the client cancels the pay process (while selecting the payment method)
    - stop the buy process
    - return to main menu
  - if the client cancels the pay process (while providing money)
    - give back all the money already inserted
    - stop the buy process
    - return to main menu

### Use Case Diagram

![Use Case Diagram](README.resources/pay%20use%20case%20-%20use%20case%20diagram.drawio.png)

### Block Diagram

![Block Diagram](README.resources/pay%20use%20case%20-%20block%20diagram.drawio.png)

### Class Diagram

![Class Diagram](README.resources/pay%20use%20case%20-%20class%20diagram.drawio.png)

### Implementation in C#

This is your homework :P

> **Notes**
>
> - Take care of the unit tests. Some of them may need to be updated.
>
> - Write additional unit tests for the Payment classes.