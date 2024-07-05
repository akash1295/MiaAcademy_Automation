Feature: Apply to MiaPrep Online High School

  Scenario: Apply to MOHS
    Given User navigates to the Mia Academy website
    When User navigates to MiaPrep Online High School through the link on banner
    And User applies to MOHS
    And User fills in the Parent Information
    Then User should proceed to the Student Information page
    And User stops the test