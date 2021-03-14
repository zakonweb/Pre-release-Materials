# TASK 2 – Files
# Introduction
# Candidates should be able to write programs to process text file data both in pseudocode and their
# chosen programming language. It is suggested that each task is planned using pseudocode before
# writing it in program code.

# TASK 2.1
# Define a structure for a text file that could be used to store information about each student as a string.
# Each line of the file will store data for one student.
# Store at least three pieces of data. For example, you could store each student’s ID together with his or
# her email address and date of birth as follows:
# <StudentID>'#'<EmailAddress>
# Define a fixed format for the Student ID, for example, two letters followed by four digits.
# Define a fixed format for the date of birth, for example, "DDMMYY"
# An example string with this format would be:
# "SA1234SamArnold137@email.com250905"
# Write program code to:
# 1. open a new text file
# 2. prompt for the ID, email address and date of birth (validate if required)
# 3. form the string as shown
# 4. write the string to the file
# 5. repeat from step 2 for all students in the class
# 6. close the file
#   Check the contents of the file using a text editor.
import sys


def Task21():
    MenuChoice = 0
    while MenuChoice != 3:
        print(
            "AS Computer Science 9608/22, Pre Release Material\n1. Input records and add to next record\n2. Output all records\n3. Quit")
        MenuChoice = int(input("\nEnter menu choice... "))
        if MenuChoice == 1:
            addRecord()
        elif MenuChoice == 2:
            outputRecords()
        elif MenuChoice == 3:
            return
        else:
            print("Wrong menu choice. Please try again.")


def addRecord():
    moreRec = True
    print("Input and add students to file")

    f = open("task2.txt", "w")
    while moreRec:

        while True:
            stuID = input("Input student ID: ")
            if validID(stuID):
                break

        while True:
            stuEmail = input("Input student email: ")
            if isEmailValid(stuEmail):
                break

        while True:
            stuDOB = input("Input student date of birth: ")
            if isDateValid(stuDOB):
                break

        concatStr = stuID + stuEmail + stuDOB
        f.write(concatStr + "\n")

        moreRec = bool(input("Enter next record (True/False): "))

    f.close()


# TASK 2.4
# Modify the program to allow the details of additional students to be appended to the file.

def appendRecord():
    moreRec = False
    print("Input * add students to file")

    f = open("task2.txt", "a")
    while moreRec:

        while True:
            stuID = input("Input student ID: ")
            if validID(stuID):
                break

        while True:
            stuEmail = input("Input student email: ")
            if isEmailValid(stuEmail):
                break

        while True:
            stuDOB = input("Input student date of birth: ")
            if isDateValid(stuDOB):
                break

        concatStr = stuID + stuEmail + stuDOB
        f.write(concatStr + "\n")

        moreRec = bool(input("Enter next record (True/False): "))

    f.close()


def outputRecords():
    print("Student ID", " " * 3, "Student DOB", " " * 3, "Student Email")
    print("----------", " " * 3, "------------", " " * 2, "-----------")
    f = open("task2.txt", "r")

    while True:
        concatStr = f.readline()
        if concatStr == "":
            break
        stuID = concatStr[:6]
        stuEmail = concatStr[6: len(concatStr) - 11]
        stuDOB = concatStr[-6:]

        print(stuID, " " * 7, stuDOB, " " * 8, stuEmail)

    f.close()

    print("\nPress any key to continue...")


# TASK 2.2
# Write a second program to search the file for a given Student ID and output the email address if the ID
# was found, or a suitable message if the ID was not found.

def Task22():
    stuID = input("\nInput student ID to search for: ")

    stuEmail = searchFullID(stuID)
    if stuEmail == "*****":
        print("Record not found...")
    else:
        print("Email address of ID", stuID, "is: ", stuEmail)

    print("Press any key to continue...")
    input()


# TASK 2.3
# Modify the search code to also perform a substring match on the Student ID. For example, search for
# all the Student IDs that begin with “AB”.

def Task23():
    stuID = input("\nInput part, or the whole, of an ID to search for: ")

    searchPartialID(stuID)


def searchFullID(val):
    isFound = False
    f = open("task2.txt", "r")
    while True:
        concatStr = f.readline()
        if concatStr == "" or isFound:
            break
        stuID = concatStr[:6]
        stuEmail = concatStr[7:len(concatStr) - 13]

        if val.upper() == stuID.upper():
            isFound = True

    f.close()

    if isFound:
        return stuEmail
    else:
        return "*****"


def searchPartialID(val):
    print("Student ID", " " * 3, "Student DOB", " " * 3, "Student Email")
    print("----------", " " * 3, "------------", " " * 2, "-----------")
    f = open("task2.txt", "r")
    while True:
        concatStr = f.readline()
        if concatStr == "":
            break
        stuID = concatStr[:6]
        stuEmail = concatStr[6: len(concatStr) - 11]
        stuDOB = concatStr[-6:]

        if stuID.upper().find(val.upper()) > 0:
            print(stuID, " " * 7, stuDOB, " " * 8, stuEmail)
    f.close()

    print("\nPress any key to continue...")
    input()


# TASK 2.5
# Consider rules that could be applied to ensure the data entered is acceptable.
# Modify your program to incorporate these.
def validID(val):
    isValid = True

    # validate string in Format AA9999. E.g. "AB1234"
    if len(val) == 6:
        if "A" <= val[:1] <= "Z":
            if "A" <= val[1:2] <= "Z":
                for count in range(2, 6):
                    CH = val[count:count + 1]
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


# TASK 2.5
# Consider rules that could be applied to ensure the data entered is acceptable.
# Modify your program to incorporate these.
def isEmailValid(strCheck):
    import re
    regex = '^[a-z0-9]+[\._]?[a-z0-9]+[@]\w+[.]\w{2,3}$'
    if (re.search(regex, strCheck)):
        return True
    else:
        return False


#TASK 2.5
#Consider rules that could be applied to ensure the data entered is acceptable.
#Modify your program to incorporate these.
def isDateValid(dateVal):
    isValid = True

    #dateValidate string in Format AA9999. E.g. "AB1234"
    if len(dateVal) == 6:
        for count in range(6):
            CH = dateVal[count:count + 1]
            if CH < "0" or CH > "9":
                isValid = False
                break

        if isValid:
            if int(dateVal[:2]) > 31: isValid = False
            if int(dateVal[2:4]) > 12: isValid = False
    else:
        isValid = False

    return isValid


MenuChoice = 0
while MenuChoice != 5:
    print("AS Computer Science 9608/22, Pre Release Material\nFor Single Line Record\n1. Task 2.1\n2. Task 2.2\n3. Task 2.3\n4. Task 2.4\n5. Output all records\n6. Quit")
    MenuChoice = int(input("\nEnter menu choice... "))
    if MenuChoice == 1:
        Task21()
    elif MenuChoice == 2:
        Task22()
    elif MenuChoice == 3:
        Task23()
    elif MenuChoice == 4:
        appendRecord()
    elif MenuChoice == 5:
        outputRecords()
    elif MenuChoice == 6:
        sys.exit()
    else:
        print("Wrong menu choice. Please try again.")