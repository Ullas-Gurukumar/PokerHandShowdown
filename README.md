# PokerHandShowdown

The first board in the example shows that Joe wins but Bob should win. Bob should win because Bob has a flush while Joe only has a pair. (Flush > Pair)
I have only tested with input file and unit testing. All the example had only 3 players
I didn't know which files were important to push to my repo so I ended up pushing the compiled classes and caches as well. Sorry if that causes any trouble.
Everything was done on Windows 10 (build 18875)

## Assumptions
* First line will be Name of the player and the next line will be there 5 card.
* Each card will be separated with ", "
* There will be a empty line ("") between each game. The next line will be the name of the player in the next game.
* I have done my testing based on the sample data provided in the document, so all my testing contains 3 players with 5 cards each. 
* I'm not checking if there are too many of the same cards in the deck.
* The ranking of the card: 2 < 3 < 4 < 5 < 6 < 7 < 8 < 9 < 10 < J < Q < K < A. Ace is the highest and 2 is the lowers
* The ranking of the suit: D < C < H < S. Diamonds is the lowest and Spades is the highest.
* The ranking of hand: High Card < One Pair < Three of a Kind < Flush (if 2 players have the same hand, it check for each card based on the circumstance)

## Note
This is the first time I have used C#. I used Visual Studio 2019 to generate the base empty project, built classes and unit testing on top of that based on microsoft documentation. 
Due to my lack of experience withing with .net and C#, I might not be using the best practices for C#. I'm using C# similar to the way I use Java.

