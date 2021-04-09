# DECLARATIONS
candidateNames = ["", "", "", ""]
candidateVotes = [0, 0, 0, 0]

groupStudents = 0
voteAbstentions = 0
numCandidates = 0


def task1():
    # DECLARATIONS
    global groupStudents
    global numCandidates

    groupName = input("Enter the tutor group name: ")

    if groupStudents < 2 or groupStudents > 35:
        groupStudents = int(input("Enter the number of students in the tutor group [28-35]: "))
        while groupStudents < 2 or groupStudents > 35:
            groupStudents = int(input("Enter a valid number of students [28-35]: "))

    numCandidates = int(input("Enter the number of candidates [1-4]: "))
    while numCandidates < 1 or numCandidates > 4:
        numCandidates = int(input("Enter a valid number of candidates [1-4]: "))
    if numCandidates >= 1:
        candidateOne = input("Enter the name of the first candidate: ")
        candidateNames[0] = candidateOne
        if numCandidates >= 2:
            candidateTwo = input("Enter the name of the second candidate: ")
            candidateNames[1] = candidateTwo
            if numCandidates >= 3:
                candidateThree = input("Enter the name of the third candidate: ")
                candidateNames[2] = candidateThree
                if numCandidates == 4:
                    candidateFour = input("Enter the name of the fourth candidate: ")
                    candidateNames[3] = candidateFour

    task2()

    print("")
    print("")
    print("Tutor Group: " + groupName)
    print("")
    print("Votes for " + candidateNames[0] + ": " + str(candidateVotes[0]))
    if numCandidates >= 2:
        print("Votes for " + candidateNames[1] + ": " + str(candidateVotes[1]))
        if numCandidates >= 3:
            print("Votes for " + candidateNames[2] + ": " + str(candidateVotes[2]))
            if numCandidates >= 4:
                print("Votes for " + candidateNames[3] + ": " + str(candidateVotes[3]))

    maxVotes = -1000

    if candidateVotes[0] > maxVotes or candidateVotes[0] == maxVotes:
        print("Candidate " + candidateNames[0] + ", with " + str(candidateVotes[0]) + " vote(s) has the most votes!")
        maxVotes = candidateVotes[0]
    if candidateVotes[1] > maxVotes or candidateVotes[1] == maxVotes:
        print("Candidate " + candidateNames[1] + ", with " + str(candidateVotes[1]) + " vote(s) has the most votes!")
        maxVotes = candidateVotes[1]
    if candidateVotes[2] > maxVotes or candidateVotes[2] == maxVotes:
        print("Candidate " + candidateNames[2] + ", with " + str(candidateVotes[2]) + " vote(s) has the most votes!")
        maxVotes = candidateVotes[2]
    if candidateVotes[3] > maxVotes or candidateVotes[3] == maxVotes:
        print("Candidate " + candidateNames[3] + ", with " + str(candidateVotes[3]) + " vote(s) has the most votes!")
        maxVotes = candidateVotes[3]


def task2():
    global groupStudents
    global voteAbstentions
    voterID = []
    groupStudentsLoop = groupStudents
    while groupStudentsLoop >= 1:
        studentID = input("Enter your voter number: ")
        if studentID in voterID:
            print("You have already voted!")
        else:
            voterID.append(studentID)
            studentChoice = input("Enter the voting choice of the next student (Enter 'SKIP' for abstention): ")
            if studentChoice == candidateNames[0]:
                candidateVotes[0] = candidateVotes[0] + 1
                groupStudentsLoop = groupStudentsLoop - 1
            elif studentChoice == candidateNames[1]:
                candidateVotes[1] = candidateVotes[1] + 1
                groupStudentsLoop = groupStudentsLoop - 1
            elif studentChoice == candidateNames[2]:
                candidateVotes[2] = candidateVotes[2] + 1
                groupStudentsLoop = groupStudentsLoop - 1
            elif studentChoice == candidateNames[3]:
                candidateVotes[3] = candidateVotes[3] + 1
                groupStudentsLoop = groupStudentsLoop - 1
            elif studentChoice == "SKIP":
                voteAbstentions = voteAbstentions + 1
                groupStudentsLoop = groupStudentsLoop - 1
                continue
            else:
                print("Enter a correct choice.")


def task3():
    global groupStudents
    global voteAbstentions
    global numCandidates

    numVotes = groupStudents - voteAbstentions

    print("The total votes cast were: " + str(numVotes) + " votes.")
    print("The total number of abstentions were: " + str(voteAbstentions))

    percOne = (candidateVotes[0] / numVotes) * 100
    print("Candidate name: " + str(candidateNames[0]))
    print("Number of votes: " + str(candidateVotes[0]))
    print("Percentage votes: " + str(percOne) + "%")
    if numCandidates >= 2:
        percTwo = (candidateVotes[1] / numVotes) * 100
        print("Candidate name: " + str(candidateNames[1]))
        print("Number of votes: " + str(candidateVotes[1]))
        print("Percentage votes: " + str(percTwo) + "%")
        if numCandidates >= 3:
            percThree = (candidateVotes[2] / numVotes) * 100
            print("Candidate name: " + str(candidateNames[2]))
            print("Number of votes: " + str(candidateVotes[2]))
            print("Percentage votes: " + str(percThree) + "%")
            if numCandidates == 4:
                percFour = (candidateVotes[3] / numVotes) * 100
                print("Candidate name: " + str(candidateNames[3]))
                print("Number of votes: " + str(candidateVotes[3]))
                print("Percentage votes: " + str(percFour) + "%")

    if numCandidates >= 2:
        if percOne == percTwo:
            print("The elections are to be run again with candidates " + candidateNames[0] + " and " + candidateNames[1])
    if numCandidates >= 3:
        if percOne == percThree:
            print("The elections are to be run again with candidates " + candidateNames[0] + " and " + candidateNames[2])
        if percTwo == percThree:
            print("The elections are to be run again with candidates " + candidateNames[1] + " and " + candidateNames[2])
    if numCandidates == 4:
        if percOne == percFour:
            print("The elections are to be run again with candidates " + candidateNames[0] + " and " + candidateNames[3])
        if percTwo == percFour:
            print("The elections are to be run again with candidates " + candidateNames[1] + " and " + candidateNames[3])
        if percThree == percFour:
            print("The elections are to be run again with candidates " + candidateNames[2] + " and " + candidateNames[3])


task1()

