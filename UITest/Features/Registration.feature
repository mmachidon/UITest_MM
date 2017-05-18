Feature: Registration


Scenario: Registration check
    Given I am a User
    When I submit a email to Registration Form
	And submit all required fields
    And I activate newly created account
	And I login to application
    Then I see home page