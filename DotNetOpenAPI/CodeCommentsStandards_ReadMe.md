# Documentation Standards For Code Comments

**1. Class-level Documentation**
At the class level, document the purpose of the class and its key features.

* **Standards:**
  - Purpose: Describe the primary role of the class and its responsibilities.
  - Dependencies: List important dependencies or relationships to other classes, components, or systems.

**2. Method/Function-level Documentation**
Each method should have documentation explaining what it does, its parameters, and its return value. If applicable, include exceptions that the method can throw.

* **Standards:**
  - Purpose: What is the method doing? Why does it exist?
  - Parameters: A brief description of each input parameter, including the type and expected values or range (if applicable).
  - Return Value: Describe what the method returns, its type, and possible return values.
  - Exceptions: Mention any exceptions the method may raise and under what conditions.

**Example:**
```
/// <summary>

/// Represents a customer in the system.

/// It provides methods to retrieve customer data from by customer Id.

/// </summary>

public class Customer
{
/// <summary>

/// Retrieves the customer information based on the provided customer ID.

/// </summary>

/// <param name="customerId">The unique identifier of the customer.</param>

/// <returns>The customer object if found; otherwise, null.</returns>

/// <exception cref="ArgumentException">Thrown when the customer ID is invalid.</exception>

public Customer GetCustomerById(int customerId)
{
    if (customerId <= 0)
    {
        throw new ArgumentException("Invalid customer ID.");

    } 

    // Assume some logic to retrieve the customer by ID

    return new Customer { Name = "John Doe", Email = "john.doe@example.com" };
}
}
```
