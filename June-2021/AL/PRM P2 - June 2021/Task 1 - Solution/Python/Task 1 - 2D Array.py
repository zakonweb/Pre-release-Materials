# TASK 1 – Arrays
# Introduction
# Candidates should be able to write programs to process array data both in pseudocode and in their
# chosen programming language. It is suggested that each task is planned using pseudocode before
# writing it in program code.Module Module1


#TASK 1.5
#Convert your design of SD array to use a 2D array and add additional pieces of information for each student.
#For example:
#Array element    Information     Example data
#MyArray[1,1]     Student Name    "Sam Arnold"
#MyArray[1,2]     Email Address   ""SamArnold137@email.com"
#MyArray[1,3]     Date of Birth   "25 Sep 2005"
#MyArray[1,4]     Student ID      "C3452-B"
#MyArray[1,5]     Tutor ID        "CHL"
import sys
UB = 2
stuRec2D = [["" for i in range(5)] for j in range(UB)]

#TASK 1.1 modified for Task 1.5
#A 2D array of STRING data type will be used to store the data of each
#student in a class as follows:

#Array element    Information     Example data
#MyArray[1,1]     Student Name    "Sam Arnold"
#MyArray[1,2]     Email Address   ""SamArnold137@email.com"
#MyArray[1,3]     Date of Birth   "25 Sep 2005"
#MyArray[1,4]     Student ID      "C3452-B"
#MyArray[1,5]     Tutor ID        "CHL"

#Write program code to:
#1. declare the array
#2. prompt and input data
#3. as shown above
#4. write the data to the next array element
#5. repeat from step 2 for all students in the class
#6. output each element of the array in a suitable format, together with
#explanatory text such as column headings

def Task11():
    MenuChoice = 0
    while MenuChoice != 3:
        print(
            "AS Computer Science 9608/22, Pre Release Material\n1. Input records and add to next array element\n2. Output array elements\n3. Quit")
        MenuChoice = int(input("\nEnter menu choice... "))

        if MenuChoice == 1:
            addElement2D()
        elif MenuChoice == 2:
            outputElements2D()
        elif MenuChoice == 3:
            return
        else:
            print("Wrong menu choice. Please try again.")


def addElement2D():
    print("Input & add", UB, "students to a 2D array")
    for i in range(UB):
        stuName = input(str(i) + ". Input student name: ")
        stuEmail = input(str(i) + ". Input student email: ")
        DOB = input(str(i) + ". Input student date of birth: ")
        stuID = input(str(i) + ". Input student ID: in Format A9999-A E.g. \"C3452-B\": ")
        while not validID(stuID):
            stuID = input(str(i) + ". Input student ID: in Format A9999-A E.g. \"C3452-B\": ")
        tutorID = input(str(i) + ". Input tutor ID: ")

        stuRec2D[i][0] = stuName
        stuRec2D[i][1] = stuEmail
        stuRec2D[i][2] = DOB
        stuRec2D[i][3] = stuID
        stuRec2D[i][4] = tutorID


def outputElements2D():
    print("Record", " "*3, "Student Name", " "*11, "Student Email", " "*10, "Student DOB", " "*12, "StudentID", " "*12, "Tutor ID")
    print("-------", " "*2, "------------", " "*11, "-------------", " "*10, "-----------", " "*12, "----------", " "*12, "----------")

    for i in range(UB):
        if stuRec2D[i][0] != "*****": #Check for Task 1.2
            print(i, " "*8, stuRec2D[i][0], " "*(23-len(stuRec2D[i][0])), stuRec2D[i][1], " "*(23-len(stuRec2D[i][1])), stuRec2D[i][2], " "*(23-len(stuRec2D[i][2])), stuRec2D[i][3], " "*(23-len(stuRec2D[i][3])), stuRec2D[i][4])

    print("\nPress any key to continue...")
    input()


#TASK 1.2 modified for Task 1.5
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
            outputElements2D()
        elif MenuChoice == 3:
            return
        else:
            print("Wrong menu choice. Please try again.")


def delRecord(stuName):
    index = searchFullName(stuName)
    if index == 0:
        return False
    else:
        stuRec2D[index][0] = "*****"
        return True


#TASK 1.3 modified for Task 1.5
#Extend your program so that after assigning values to the array, the program will prompt the user to
#input a name, and then search the array to find that name and output the corresponding email address.


def Task13():
    stuName = input("\nInput student name to search for: ")

    index = searchFullName(stuName)
    if index == 0:
        print("Record not found...")
    else:
        print("Email address of", stuName, "is:", stuRec2D[index][1])

    print("Press any key to continue...")
    input()


#TASK 1.4 modified for 1.5
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
        if val.upper() == stuRec2D[i][0].upper():
            isFound = True

    if isFound:
        return i
    else:
        return 0


def searchPartialName(val):
    print("Record", " "*2, "Student Name", " "*11, "Student Email", " "*10, "Student DOB", " "*12, "Student ID", " "*12, "Tutor ID")
    print("-------", " "*2, "------------", " "*11, "-------------", " "*10, "-----------", " "*12, "----------", " "*12, "----------")

    for i in range(UB):
        if stuRec2D[i][0] != "*****": #Check for Task 1.2
            if stuRec2D[i][0].upper().find(val.upper()) >= 0:
                print(i, " "*8, stuRec2D[i][0], " "*(23-len(stuRec2D[i][0])), stuRec2D[i][1], " "*(23-len(stuRec2D[i][1])), stuRec2D[i][2], " "*(23-len(stuRec2D[i][2])), stuRec2D[i][3], " "*(23-len(stuRec2D[i][3])), stuRec2D[i][4])

    print("\nPress any key to continue...")
    input()


def validID(Val):
    #validate string in Format A9999-A. E.g. "C3452-B"

    if len(Val) == 7 and Val[5:6] == "-":
        if "A" <= Val[:1] < "Z":
            if "A" <= Val[len(Val) - 1:] <= "Z":
                for count in range(1,5):
                    CH = Val[count:count+1]
                    if CH < "0" or CH > "9":
                        isValid = False
                        break
            else:
                isValid = False
        else:
            isValid = False
    else:
        isValid = False

    return isValid


MenuChoice = 0
while MenuChoice != 5:
    print("AS Computer Science 9608/22, Pre Release Material\nTask 1.5 & 1.6 done over Tasks 1.1 to 1.4 for 2D Array\n1. Task 1.1\n2. Task 1.2\n3. Task 1.3\n4. Task 1.4\n 5. Quit")
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