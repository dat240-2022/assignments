# Image guessing game

## Background 

Recent advances in computational capabilities of machines along side advances in algorithmic intelligence, have surpassed expectations and resulted in staggering feats such as 'AlphaGo' defeating a world champion in the game of Go using deep neural networks. With all the perceived superiority of machines in decision making using Deep Learning we are interested in the question -- Do machines think like humans? In this project you will develop a game which can be used to collect the data on how humans think when they see images and identify objects. Or in other works what humans think are important to identify objects in the image. This will help machine learning scientists compare how neural networks work compared to the way humans think.

## The game

There are some games which are designed to be fun but also achieve something useful. Such games are called [games with a purpose (GWAP)](https://en.wikipedia.org/wiki/Human-based_computation_game) 

There are some examples of such games like [Peekaboom](https://www.cs.cmu.edu/~biglou/Peekaboom.pdf)

In this project, you will attempt to do this by making a single or two-player game on recognizing images.
In single player mode you will be playing against an oracle.
In two player mode, two players are paired in the beginning of the game -- The Proposer and the Guesser. 

### Rules of the game

The Proposer gets to see the entire image and the label
that they have to help the Guesser guess. The sooner the Guesser succeeds, the more points both the Guesser and the Proposer get.
Example of Image and label : The Proposer is shown this image and wants the Guesser to guess: GoKart


<img width="713" alt="Screenshot 2022-10-21 at 18 02 10" src="https://user-images.githubusercontent.com/1608263/138315055-88303986-cdec-4577-a13b-085f7e4dad39.png">

The image is segmented into multiple segments (in this case 50 segments). The Proposer can click on any of the segments (one at a time). Once the Proposer clicks on a segment, that segment appears on the screen of the Guesser. The Guesser then has to guess the label (unknown to the Guesser). The Guesser is allowed 3 tries

The Proposer gets its turn if
1) the Guesser has three wrong guesses in a row or
2) The Guesser gives up

Below is an example screen for the Guesser after 5 segments have been chosen by the
Proposer. Pretty lousy Proposer don't you think ;-)

<img width="474" alt="Screenshot 2022-10-21 at 18 04 30" src="https://user-images.githubusercontent.com/1608263/138315345-89491740-677f-4a93-bdb6-5aa9e6812c56.png">

Now the Proposer has to judiciously chose the next segment based on the earlier guesses of the Guesser. The figure above shows 10 segments selected by the Proposer in that order. The number 1 was the first proposal, 2 the second proposal and so on..

The game ends if the Guesser is successfully able to guess the label, or if all segments are opened, or if the Guesser decides to quit. 

### Points system

The fewer segments needed to guess the better it is for both the players. The score for both players is the number of uncovered segments until a successful guess. This score is then maintained in a leaderboard showing top players.


### Basic features: Single player or Oracle mode

When there is no pairing possible, a single player can play against a random oracle which selects a set of random segments incrementally. Then ask the same player to propose better segments. These segments would be pre-recorded for future Guessers.

  * User should be able to register and log in. 
  * User should be able to create a new game
  * Single Player: 
    - An Oracle service selects an image for the game
    - The oracle randomly selects a tile
    - The tile is shown to the user
    - The user makes a guess
    - The Oracle verifies the guess.
    - If the Oracle decides to pick another tile, the various tiles can be combined with a library like ImageSharp before showing it to the client.
    - If the user get's it right, the app should display the complete image. 
  * The app could keep track of a leaderboard. 
  * The app should show a list of recent games
  * All of this can be done with a regular webpage and GET/POSTs 


### Advanced features: Two player mode 
  - Logged in players can join created games. Two players per game. 
  - The player that created the game takes the role of the Oracle
  - Using client side refreshes or WebSockets (SignalR is a package for ASP.NET that simplifes this) to update the page when the other player makes a selection. 
  - Leaderboard, by team. Number of guesses and speed.

### Advanced features: Multiplayer: Multiple people can join a game, all guessing 

  - Oracle get's notified on who guessed what
  - Oracle picks a new tile when everyone has made their guess. 
  - Whomever guesses right first wins
  - Alternative where one of the player is the Proposer and the Guessers compete. 

### Advanced features: Upload new images

- Logged in user can upload new images
- Automatically sliced
- Manual slicing 
- Categorize the image

**Note that the advanced features are not necessary to get a passing grade, but to be considered a delivery of very good or excellent performance one or two advanced features need to be implemented.**

## Criteria for judging the delivery:

- Separation of Concerns. Game logic is clearly separated from infrastructure logic and UI logic. 
- Domain model. The domain here is not big, but the domain objects you have should be clearly defined, well connected and contain the logic required to operate on them. 
- Unit tests: Game logic has unit tests
- Integration tests: Infrastructure and side effects are tested
- Code follows a readable and discoverable structure. It is easy to figure out what belongs where and things are where you expect it to be. 
- It is easy to clone the project and run it. It should work out of the box. 
- CI set up with GitHub Actions.
- Following general object oriented principles like information hiding, tell - don't ask
- Abstractions - Is it easy to replace the implementation of the single player Oracle with another one (for instance an AI model)

## Report:
 - Report can be written in a Word document or an overleaf template [here](https://www.overleaf.com/read/nkhzxdyqhkjn)
 - The report can be maximum 10 pages please submit in pdf format only
 - The resport should reflect:
   - How you organized your collaboration and defined your process
   - How you defined your work by splitting work in smaller work items. 
   - How you tracked your work
   - Technical decisions you made during the project and why that decision was made
   - How did you communicate
   - How did you stop and evaluate during the project. What worked and what did not work. What changes did they make and how did they work?
   - Perfectly okay to make mistakes and screw up things underway, if they can show that they acknowledged it, came up with a solution, implemented it and evaluated it.

## Dataset

The dataset can be downloaded from here https://www.dropbox.com/sh/j80xn9prbw086wc/AAA3hCVfPAsHxNq1Ie0okL-Ta?dl=0
It has 3 files
 1. scattered images.zip this contains a collection of folders each for an image and each folder contains image segments 0 up to 50 in png format
 2. Image_mapping.csv image to id mapping
 3. Label_mapping.csv id to label mapping

## Groups

- Each Group will have 5 students. Groups will be based on the self-assessment you filled out. 
- Everyone must work in a group since exceuting a project in a team setting is one of the skills that will be assessed in this course.
- The whole group gets same grade so everyone is collectively responsible for the group's grade.
- Please register your group (choose a group name containing last names of all team members) along with your team members in [QuickFeed](https://uis.itest.run/app/home)
- **Registering your group in QuickFeed is mandatory** and important since it will create a github repository which you must use for storing and maintaining your code


## Deadline

- Deadline for the project code and the report is **17.11.2022 by 16.00**

## Oral exam
- Note that this course does not have a written exam as announced, 100% of the grade is based on the oral exam and performance in the project 
- Oral examinations is tentatively scheduled in the week 50 (December 13th to December 17th). We will send out a doodle poll once it is closer.
