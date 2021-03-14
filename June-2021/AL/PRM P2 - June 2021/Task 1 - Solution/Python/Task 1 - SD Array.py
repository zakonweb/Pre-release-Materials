# TASK 1 – Arrays
# Introduction
# Candidates should be able to write programs to process array data both in pseudocode and in their
# chosen programming language. It is suggested that each task is planned using pseudocode before
# writing it in program code.Module Module1

import sys
UB = 2
stuRecSD = ["" for i in range(UB)]


# TASK 1.1
# A 1D array of STRING data type will be used to store the name of each
# student in a class together with their email address and date of birth as follows:
# <Student Name>'*'<Email address>'*'<Date of birth>
# An example string with this format would be:
# "Sam Arnold*SamArnold137@email.com*25Sep2005"
# Write program code to:
# 1. declare the array
# 2. prompt and input for student name, email address and date of birth
# 3. form the string as shown
# 4. write the string to the next array element
# 5. repeat from step 2 for all students in the class
# 6. output each element of the array in a suitable format, together with
#   explanatory text such as column headings

def Task11():
    MenuChoice = 0
    while MenuChoice != 3:
        print(
            "AS Computer Science 9608/22, Pre Release Material\n1. Input records and add to next array element\n2. Output array elements\n3. Quit")
        MenuChoice = int(input("\nEnter menu choice... "))

        if MenuChoice == 1:
            addElementSD()
        elif MenuChoice == 2:
            outputElementsSD()
        elif MenuChoice == 3:
            return
        else:
            print("Wrong menu choice. Please try again.")


def addElementSD():
    print("Input & add", UB, "students to an SD array")
    for i in range(UB):
        stuName = input(str(i + 1) + ". Input student name: ")
        stuEmail = input(str(i + 1) + ". Input student email: ")
        stuDOB = input(str(i + 1) + ". Input sutdent date of birth: ")

        concatStr = stuName + "*" + stuEmail + "*" + stuDOB
        stuRecSD[i] = concatStr


def outputElementsSD():
    print("Record", " "*2, "Student Name", " "*11, "Student Email", " "*11, "Student Date of Birth")
    print("-------", " "*2, "------------", " "*11, "-------------", " "*11, "---------------------")
    for i in range(UB):
        if stuRecSD[i] != "*****": #Check for Task 1.2
            concatStr = stuRecSD[i]
            starPos = concatStr.find("*")
            stuName = concatStr[:starPos]

            starPos1 = concatStr[starPos+1:].find("*")
            stuEmail = concatStr[starPos+1:starPos1 - starPos]

            stuDOB = concatStr[-(len(concatStr)-starPos1):0]

            print(i, " "*8, stuName, " "*(23-len(stuName)), stuEmail, " "*24, stuDOB)

    print("\nPress any key to continue...")
    input()


#TASK 1.2
#Consider what happens when a student leaves the class and their data item is deleted from the array.
#Decide on a way of identifying unused array elements and only output elements that contain student
#details. Modify your program to include this.

def Task12():
    MenuChoice = 0
    while MenuChoice != 3:
        print("AS Computer Science 9608/22, Pre Release Material\n1. Delete record\n2. Output array elements\n3. Quit")
        MenuChoice = int(input())
        if MenuChoice == 1:
            stuName = input("Input student name to delete: ")

            if delRecord(stuName):
                print("Record deleted successfully.")
            else:
                print("Record not found...")

            print("Press any key to continue...")
            input()
        elif MenuChoice == 2:
            outputElementsSD()
        elif MenuChoice == 3:
            break
        else:
            print("Wrong menu choice. Please try again.")


def delRecord(stuName):
    index = searchFullName(stuName)
    if index == 0:
        return False
    else:
        stuRecSD[index] = "*****"
        return True


#TASK 1.3
#Extend your program so that after assigning values to the array, the program will prompt the user to
#input a name, and then search the array to find that name and output the corresponding email address.


def Task13():
    stuName = input("\nInput student name to search for: ")

    index = searchFullName(stuName)
    if index == 0:
        print("Record not found...")
    else:
        concatStr = stuRecSD[index]
        starPos = concatStr.find("*")
        starPos1 = concatStr[starPos+1:].find("*")
        stuEmail = concatStr[starPos + 1:starPos1 - starPos]

        print("Email address of ", stuName, "is: ", stuEmail)

    print("Press any key to continue...")
    input()


#TASK 1.4
#Modify your program so that it will:
#prompt the user to input part, or the whole, of a name
#search the whole array to find the search term within the <StudentName> string
#for each array element in which the search term is found within the <StudentName> string, output
#the element in a suitable format.


def Task14():
    stuName = input("\nInput part, or the whole, of a name to search for: ")
    searchPartialName(stuName)


def searchFullName(val):
    i = 0
    isFound = False

    while i != UB or not isFound:
        i += 1
        if stuRecSD != "*****": #Check for Task 1.2
            concatStr = stuRecSD[i]
            starPos = concatStr.find("*")
            stuName = concatStr[:starPos-1]

            if val.upper() == stuName.upper(): isFound = True

    if isFound:
        return i
    else:
        return 0


def searchPartialName(val):
    print("Record ", " "*2, "Student Name", " "*11, "Student Email", " "*11, "Student Date of Birth")
    print("-------", " "*2, "------------", " "*11, "-------------", " "*11, "---------------------")
    for i in range(UB):
        if stuRecSD[i] != "*****": #Check for Task 1.2
            concatStr = stuRecSD[i]
            starPos = concatStr.find("*")
            stuName = concatStr[:starPos]

            starPos1 = concatStr[starPos + 1:].find("*")
            stuEmail = concatStr[starPos + 1:starPos1 - starPos]

            stuDOB = concatStr[-(len(concatStr)-starPos1):0]
            if stuName.upper().find(val.upper()) >= 0:
                print(i, " "*8, stuName, " "*(23-len(stuName)), stuEmail, " "*(24-len(stuEmail), stuDOB))

    print("\nPress any key to continue...")
    input()


MenuChoice = 0
while MenuChoice != 5:
    print("AS Computer Science 9608/22, Pre Release Material\nFor SD Array\n1. Task 1.1\n2. Task 1.2\n3. Task 1.3\n4. Task 1.4\n 5. Quit")
    MenuChoice = int(input("\nEnter menu choice... "))
    if MenuChoice == 1:
        Task11()
    elif MenuChoice == 2:
        Task12()
    elif MenuChoice == 3:
        Task13()
    elif MenuChoice == 4:
        Task14()
    elif MenuChoice == 5:
        sys.exit()
    else:
        print("Wrong menu choice. Please try again.")