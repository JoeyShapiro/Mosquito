# Mosquito
## Description
### A program that will go through a folder, recursively and look for executables.
This was made for a senior project. We need ~2500 windows executables.<br>
This will help with the process of collection.<br>

## Running
### The program requires 1 argument, which is the root folder.
It will store the collected exes in a folder named "harvest".<br>
A list of collected is also stored in a file named "harvested.txt".<br>
This allows for it to check what is already collected.<br>

## Examples
### Must be ran in its own folder
Look through whole drive:<br>
`.\Mosquito C:\`<br>
This might give an error stating "no permissions for folder".<br>
<br>
Look through certain folder:<br>
`.\Mosquito "C:\Program Files"`<br>
Note that using double quotes allows for spaces.