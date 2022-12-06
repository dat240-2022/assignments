# Group project

As a group you can pick one of the two projects available for the class.

[Campus Eats](campus_eats.md) - Create an application that will let students order food from the cafeteria from anywhere on campus and have the food brought to them via couriers.

[Image Guessing Game](image_guessing_game.md) - Create a single or two-player game on recognizing images, which can be used to collect the data on how humans think when they see images and identify objects.

# Common for both projects

## Technology

You are free to use what ever technology you want, within the requirements of the project. That includes languages, but we expect you to write good, maintainable code in whatever language you pick.

This is not a front-end course, but several of the topics we have touched upon makes sense in a front-end context. You are free to build the kind of front-end you want, from a full on SPA to simple HTML pages, but whatever you do, keep it clean, structured and readable.

This is not a design course. You will not be penalised for having an application that looks crap, as long as it's functional. The functionality is the important thing.

## Criteria for judging the delivery

* Separation of Concerns. Business logic is clearly separated from infrastructure logic and UI logic.
* Separation of contexts. See what belongs together and keep it together.
* Loosely coupled code. Use things like events and external message bus to make a robust message transfer between the contexts.
* Domain model. The domain here is not big, but the domain objects you have should be clearly defined, well connected and contain the logic required to operate on them.
* Unit tests: Business logic has unit tests
* Integration tests: Infrastructure and side effects are tested
* Code follows a readable and discoverable structure. It is easy to figure out what belongs where and things are where you expect it to be.
* It is easy to clone the project and run it. It should work out of the box, and be able to run with a single command. It should have minimal dependencies for the machine it's running on. Requiring the latest .NET SDK, Node.js or Python installed are reasonable dependencies. Do is requiring Docker.
* CI set up with GitHub Actions.
* Following general object oriented principles like information hiding, tell - don't ask
* Abstractions - Is it easy to replace the implementation of various infrastructure with with another one?
* Did the team manage to implement an adequate number of features?
* Did the team have a good process in place for tracking work?
* How many of the advanced features were implemented?

## Report

* Report can be written in a Word document or an overleaf template [here](https://www.overleaf.com/read/nkhzxdyqhkjn)
* The report can be maximum 10 pages please submit in pdf format only
* The report should reflect:
  * How you organized your collaboration and defined your process
  * How you defined your work by splitting work in smaller work items.
  * How you tracked your work
  * Technical decisions you made during the project and why that decision was made
  * How did you communicate
  * How did you stop and evaluate during the project. What worked and what did not work. What changes did you make and how did they work?
  * Perfectly okay to make mistakes and screw up things underway, if you can show that you acknowledged it, came up with a solution, implemented it and evaluated it.

## Groups

* Each Group should have 5 students. Groups will be self-forming on Discord, but if you don't have a group, let us know and we'll assist.
* Everyone must work in a group since executing a project in a team setting is one of the skills that will be assessed in this course.
* The whole group gets same grade so everyone is collectively responsible for the group's grade.
* Please register your group (choose a group name containing last names of all team members) along with your team members in [QuickFeed](https://uis.itest.run/app/home)
* **Registering your group in QuickFeed is mandatory** and important since it will create a github repository which you must use for storing and maintaining your code

## Deadline

* Deadline for the project code and the report is **19.11.2022 by 16.00**

## Oral exam

* 40% of the grade is based on the oral exam and performance in the project.
* Oral examinations is tentatively scheduled 9. Dec 2022 https://docs.google.com/spreadsheets/d/1SPRg7SBPZ6vgKcXtlfgYmn79pfyYx44H2rSMrjnRg_I/edit#gid=0
