optionsDesc = ["", "", "", "", ""]
staffIDs = []
studentIDs = []
for i in range(20):
    staffIDs.append("")
for i in range(150):
    studentIDs.append("")

staffPref = [0, 0, 0, 0, 0]
studentPref = [0, 0, 0, 0, 0]
studentPrefOne = [0, 0, 0, 0, 0]
staffPrefOne = [0, 0, 0, 0, 0]


def task1():
    print("OL Computer Science")
    print("Pre Release Material (Variant 3) -- May/June 2021")
    print("Simulator by Zak; http://www.zakonweb.com")
    print("-" * 90)

    optionsDesc[0] = input("Enter the description for Option A: ")
    optionsDesc[1] = input("Enter the description for Option B: ")
    optionsDesc[2] = input("Enter the description for Option C: ")
    optionsDesc[3] = input("Enter the description for Option D: ")
    optionsDesc[4] = input("Enter the description for Option E: ")

    continueFlag = True
    while continueFlag:
        switchFlag = True
        while switchFlag:
            switch = input("Are you a student or a staff? (Student/Staff): ")

            if switch.upper() == "STUDENT":
                switchFlag = False
                studentIDStr = input("Enter your Student ID: ")

                enterFlag = True
                for e in range(150):
                    if studentIDs[e] == studentIDStr:
                        print("You have already entered your preferences!")
                        enterFlag = False

                if enterFlag:
                    print("")
                    print("Option A: " + optionsDesc[0])
                    print("Option B: " + optionsDesc[1])
                    print("Option C: " + optionsDesc[2])
                    print("Option D: " + optionsDesc[3])
                    print("Option E: " + optionsDesc[4])
                    print("")
                    print("Enter your preferences ('1': 'strongly agree', '5': 'strongly disagree')")

                    print("")
                    preference = int(input("Preference for Option A: "))
                    while preference < 1 or preference > 5:
                        print("Enter a correct value (1 - 5)!")
                        preference = int(input("Preference for Option A: "))
                        print("")
                    studentPref[0] = studentPref[0] + preference
                    if preference == 1:
                        studentPrefOne[0] = studentPrefOne[0] + 1

                    print("")
                    preference = int(input("Preference for Option B: "))
                    while preference < 1 or preference > 5:
                        print("Enter a correct value (1 - 5)!")
                        preference = int(input("Preference for Option B: "))
                        print("")
                    studentPref[1] = studentPref[1] + preference
                    if preference == 1:
                        studentPrefOne[1] = studentPrefOne[1] + 1

                    print("")
                    preference = int(input("Preference for Option C: "))
                    while preference < 1 or preference > 5:
                        print("Enter a correct value (1 - 5)!")
                        preference = int(input("Preference for Option C: "))
                        print("")
                    studentPref[2] = studentPref[2] + preference
                    if preference == 1:
                        studentPrefOne[2] = studentPrefOne[2] + 1

                    print("")
                    preference = int(input("Preference for Option D: "))
                    while preference < 1 or preference > 5:
                        print("Enter a correct value (1 - 5)!")
                        preference = int(input("Preference for Option D: "))
                        print("")
                    studentPref[3] = studentPref[3] + preference
                    if preference == 1:
                        studentPrefOne[3] = studentPrefOne[3] + 1

                    print("")
                    preference = int(input("Preference for Option E: "))
                    while preference < 1 or preference > 5:
                        print("Enter a correct value (1 - 5)!")
                        preference = int(input("Preference for Option E: "))
                        print("")
                    studentPref[4] = studentPref[4] + preference
                    if preference == 1:
                        studentPrefOne[4] = studentPrefOne[4] + 1

            elif switch.upper() == "STAFF":
                switchFlag = False
                staffIDStr = input("Enter your Staff ID: ")

                enterFlag = True
                for e in range(20):
                    if staffIDs[e] == staffIDStr:
                        print("You have already entered your preferences!")
                        enterFlag = False

                if enterFlag:
                    print("")
                    print("Option A: " + optionsDesc[0])
                    print("Option B: " + optionsDesc[1])
                    print("Option C: " + optionsDesc[2])
                    print("Option D: " + optionsDesc[3])
                    print("Option E: " + optionsDesc[4])
                    print("")
                    print("Enter your preferences ('1': 'strongly agree', '5': 'strongly disagree')")

                    print("")
                    preference = int(input("Preference for Option A: "))
                    while preference < 1 or preference > 5:
                        print("Enter a correct value (1 - 5)!")
                        preference = int(input("Preference for Option A: "))
                        print("")
                    staffPref[0] = staffPref[0] + preference
                    if preference == 1:
                        staffPrefOne[0] = staffPrefOne[0] + 1

                    print("")
                    preference = int(input("Preference for Option B: "))
                    while preference < 1 or preference > 5:
                        print("Enter a correct value (1 - 5)!")
                        preference = int(input("Preference for Option B: "))
                        print("")
                    staffPref[1] = staffPref[1] + preference
                    if preference == 1:
                        staffPrefOne[1] = staffPrefOne[1] + 1

                    print("")
                    preference = int(input("Preference for Option C: "))
                    while preference < 1 or preference > 5:
                        print("Enter a correct value (1 - 5)!")
                        preference = int(input("Preference for Option C: "))
                        print("")
                    staffPref[2] = staffPref[2] + preference
                    if preference == 1:
                        staffPrefOne[2] = staffPrefOne[2] + 1

                    print("")
                    preference = int(input("Preference for Option D: "))
                    while preference < 1 or preference > 5:
                        print("Enter a correct value (1 - 5)!")
                        preference = int(input("Preference for Option D: "))
                        print("")
                    staffPref[3] = staffPref[3] + preference
                    if preference == 1:
                        staffPrefOne[3] = staffPrefOne[3] + 1

                    print("")
                    preference = int(input("Preference for Option E: "))
                    while preference < 1 or preference > 5:
                        print("Enter a correct value (1 - 5)!")
                        preference = int(input("Preference for Option E: "))
                        print("")
                    staffPref[4] = staffPref[4] + preference
                    if preference == 1:
                        staffPrefOne[4] = staffPrefOne[4] + 1

            else:
                print("Error: Enter a valid response (Student/Staff)")

        continueFlagStr = input("Would you like to add another preference? (Y/N): ")
        if continueFlagStr == "Y":
            continueFlag = True
        elif continueFlagStr == "N":
            continueFlag = False
        else:
            print("Enter a correct value (Y/N)")


def task2():
    print("Option A: " + optionsDesc[0])
    print("Total staff preference: " + str(staffPref[0]))
    print("Total student preference: " + str(studentPref[0]))
    print("Total combined preference: " + str(staffPref[0] + studentPref[0]))
    print("")
    print("Option B: " + optionsDesc[1])
    print("Total staff preference: " + str(staffPref[1]))
    print("Total student preference: " + str(studentPref[1]))
    print("Total combined preference: " + str(staffPref[1] + studentPref[1]))
    print("")
    print("Option C: " + optionsDesc[2])
    print("Total staff preference: " + str(staffPref[2]))
    print("Total student preference: " + str(studentPref[2]))
    print("Total combined preference: " + str(staffPref[2] + studentPref[2]))
    print("")
    print("Option D: " + optionsDesc[3])
    print("Total staff preference: " + str(staffPref[3]))
    print("Total student preference: " + str(studentPref[3]))
    print("Total combined preference: " + str(staffPref[3] + studentPref[3]))
    print("")
    print("Option E: " + optionsDesc[4])
    print("Total staff preference: " + str(staffPref[4]))
    print("Total student preference: " + str(studentPref[4]))
    print("Total combined preference: " + str(staffPref[4] + studentPref[4]))
    print("")


def task3():
    print("Option A: " + optionsDesc[0])
    print("Total times preference '1' was given by staff: " + str(staffPrefOne[0]))
    print("Total times preference '1' was given by students: " + str(studentPrefOne[0]))
    print("Combined total preference of '1': " + str(staffPrefOne[0] + studentPrefOne[0]))
    print("")
    print("Option B: " + optionsDesc[1])
    print("Total times preference '1' was given by staff: " + str(staffPrefOne[1]))
    print("Total times preference '1' was given by students: " + str(studentPrefOne[1]))
    print("Combined total preference of '1': " + str(staffPrefOne[1] + studentPrefOne[1]))
    print("")
    print("Option C: " + optionsDesc[2])
    print("Total times preference '1' was given by staff: " + str(staffPrefOne[2]))
    print("Total times preference '1' was given by students: " + str(studentPrefOne[2]))
    print("Combined total preference of '1': " + str(staffPrefOne[2] + studentPrefOne[2]))
    print("")
    print("Option D: " + optionsDesc[3])
    print("Total times preference '1' was given by staff: " + str(staffPrefOne[3]))
    print("Total times preference '1' was given by students: " + str(studentPrefOne[3]))
    print("Combined total preference of '1': " + str(staffPrefOne[3] + studentPrefOne[3]))
    print("")
    print("Option E: " + optionsDesc[4])
    print("Total times preference '1' was given by staff: " + str(staffPrefOne[4]))
    print("Total times preference '1' was given by students: " + str(studentPrefOne[4]))
    print("Combined total preference of '1': " + str(staffPrefOne[4] + studentPrefOne[4]))
    print("")


task1()
