# Green vs. Red Game Summary
Green vs. Red is a Console Application that accepts user input to create a 2D array, fill it with 0s (representing red cells) and 1s (representing green cells). There are a set of rules that define the color of each cell for the next turn (generation). After all rules are applied on each individual cell, the next turn (generation) begins, with cells changing colors based on the outcome of all applied rules in the previous turn. The goal of the game is to choose a certain cell and the number of game turns (all through user input) and successfully calculate during how many turns that cell has been green.

## User input format:
- Line 1: The X (width) and Y (height) size of the 2D array, in the format "X, Y". X <= Y < 1000 
- Next Y lines: 0s and 1s (a total of X digits), in the format "XXX"
- Last line: X1 and Y1 coordinates of the target cell and N number of turns the game should last for, in the format "X1, Y1, N"

## Rules
Each cell's neighbors (both orthogonally and diagonally) are checked:
- Red cell rule: each red cell, surrounded by exactly 3 or 6 green cells, will become green in the next generation, otherwise it will remain red.
- Green cell rule: each green cell, surrounded by exactly 2, 3 or 6 green cells, will remain green in the next generation, otherwise it will become red.

