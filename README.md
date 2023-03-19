# Create Investment Application

This application providr you to
* Add an investment
    
    * An investment should include:
        * Name
        * Start Date
        * Interest Type: Simple or Compound
        * Interest Rate
        * Principle Amount
    * The name of an investment should be unique
* Update an investment
* Delete an investment
* Fetch Investment
    * Returning:
        * Name
        * Start Date
        * Interest Type: Simple or Compound
        * Interest Rate
        * Principle Amount
        * Current value of the investment rounded to the nearest month
    
    
    ```
    Acceptance Criteria 1
    GIVEN an investment is of type simple
    WHEN interest is calculated
    THEN a value is returned equal to  A = P(1 + rt)
    AND the period is rounded to the nearest month

    Where:
    A = Total Accrued Amount (principal + interest)
    P = Principal Amount
    I = Interest Amount
    r = Rate of Interest per year in decimal
    t = Time Period involved in months or years
    See https://www.calculatorsoup.com/calculators/financial/simple-interest-plus-principal-calculator.php

    Acceptance Criteria 2
    GIVEN an investment is of type compound
    WHEN interest is calculated
    THEN a value is returned equal to  A = P(1 + r/n)nt
    AND the compounding perdiod is Monthly
    AND the period is rounded to the nearest month
    
    Where:
    A = Accrued amount (principal + interest)
    P = Principal amount
    r = Annual nominal interest rate as a decimal
    n = number of compounding periods per unit of time
    t = time in decimal years; e.g., 6 months is calculated as 0.5 years. 
    See https://www.calculatorsoup.com/calculators/financial/compound-interest-calculator.php
    ```

* In memory DB is used to the unit testing while API is used SQLite as the database option.
* Code is extensible for new Interest Type without modifying the existing types.

## Instructions Run the application

* Clone the code and setup InvestmentApp.API as startup project.
* resolve the nuget packages by clean and rebuild the solutions.
* Note: this application is running in donet 5. So make sure to install the DotNet 5 SDK before you run.
* I have used SQLite as the Database option so if you are happy to go with, you need SQLite in the machine and need write access to IISUSER to create database in the given folder path.
* If you are like to go with SQLServer then you need to do relevant configuration to the code and create Migrations before you update the Database.
* Now you can run the application.

## Not Covered

* Message verifications are not covered in the unit testing.
* Relevent logs are not created in the current application.

## Assumptions

* Assume Interest types are case sencitive.







