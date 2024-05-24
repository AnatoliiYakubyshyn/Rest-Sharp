Feature: JsonPlaceHolder


Scenario: Put request
	Given url is "https://jsonplaceholder.typicode.com/posts"
	And the body is "tolia body"
	And the title is "cool title"
	When Post request send
	Then status code is 201
