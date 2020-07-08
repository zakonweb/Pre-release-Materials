basePrice = 500
priceChangePerc = 0
engineSizeLtr = -1.0
valueInThousands = -1000.0
locationFlag = False
thousandKilometerDriven = -1000.0
driverAge = 0
yearsWithoutClaim = -10

clear()
print("OL Computer Science")
print("Pre Release Material (Variants 1) -- Oct/Nov 2020")
print("Simulator by Zak; http://www.zakonweb.com")
print("-" * 90)

while engineSizeLtr < 0:
    engineSizeLtr = float(input("Enter the engine size in litres of fuel: "))
    if 0 <= engineSizeLtr <= 0.5: priceChangePerc = priceChangePerc - 5
    elif 0.5 < engineSizeLtr <= 1.0: priceChangePerc = priceChangePerc + 0
    elif 1.0 < engineSizeLtr <= 2.5: priceChangePerc = priceChangePerc + 5
    elif engineSizeLtr > 2.5: priceChangePerc = priceChangePerc + 10
    else: print("Please enter a valid engine size.")

while valueInThousands < 0:
    valueInThousands = float(input("Enter the value of the car (in thousands): "))
    if 0 < valueInThousands < 0.5: priceChangePerc = priceChangePerc - 5
    elif 0.5 <= valueInThousands <= 2: priceChangePerc = priceChangePerc + 0
    elif 2 < valueInThousands <= 10: priceChangePerc = priceChangePerc + 5
    elif 10 < valueInThousands <= 20: priceChangePerc = priceChangePerc + 10
    elif valueInThousands > 20: priceChangePerc = priceChangePerc + 15
    else: print("Please enter a valid price.")

while not locationFlag:
    locationKept = input("Enter the location where the car is kept overnight (Garage/Drive/Street): ")
    if locationKept.upper() == "GARAGE":
        locationFlag = True
        priceChangePerc = priceChangePerc - 5
    elif locationKept.upper() == "DRIVE":
        locationFlag = True
        priceChangePerc = priceChangePerc + 0
    elif locationKept.upper() == "STREET":
        locationFlag = True
        priceChangePerc = priceChangePerc + 5
    else: print("Please enter a valid location (Garage/Drive/Street).")

while thousandKilometerDriven < 0:
    thousandKilometerDriven = float(input("Enter the kilometers driven per year (in thousands): "))
    if 0 <= thousandKilometerDriven < 5: priceChangePerc = priceChangePerc - 5
    elif 5 <= thousandKilometerDriven <= 20: priceChangePerc = priceChangePerc + 0
    elif thousandKilometerDriven > 20: priceChangePerc = priceChangePerc + 5
    else: print("Please enter a valid value for the thousands of kilometers driven.")

while driverAge < 18:
    driverAge = int(input("Enter the age of the driver: "))
    if 18 <= driverAge <= 20: priceChangePerc = priceChangePerc + 100
    elif 21 <= driverAge <= 25: priceChangePerc = priceChangePerc + 50
    elif 26 <= driverAge <= 30: priceChangePerc = priceChangePerc + 25
    elif 31 <= driverAge <= 70: priceChangePerc = priceChangePerc + 0
    elif 71 <= driverAge <= 80: priceChangePerc = priceChangePerc + 10
    elif driverAge > 80: priceChangePerc = priceChangePerc + 20
    else: print("Please enter a valid age.")

while yearsWithoutClaim < 0:
    yearsWithoutClaim = int(input("Enter the number of years without an insurance claim: "))
    if yearsWithoutClaim == 0: discountPerc = 0
    elif yearsWithoutClaim == 1: discountPerc = 10
    elif yearsWithoutClaim == 2: discountPerc = 20
    elif yearsWithoutClaim == 3: discountPerc = 30
    elif yearsWithoutClaim == 4: discountPerc = 40
    elif yearsWithoutClaim == 5: discountPerc = 50
    elif yearsWithoutClaim == 6: discountPerc = 60
    elif yearsWithoutClaim > 6: discountPerc = 70
    else: print("Please enter a valid argument.")

# ADDITIONAL CODE FOR TASK 3 BEGINS HERE

addDriverChoice = input("Would you like to add another driver? (Y/N): ")
if addDriverChoice.upper() == "Y":
    newDriverAge = 0
    while newDriverAge < 18:
        newDriverAge = int(input("Enter the age of the second driver: "))
        if 18 <= newDriverAge <= 20: priceChangePerc = priceChangePerc + 100
        elif 21 <= newDriverAge <= 25: priceChangePerc = priceChangePerc + 50
        elif 26 <= newDriverAge <= 30: priceChangePerc = priceChangePerc + 25
        elif 31 <= newDriverAge <= 70: priceChangePerc = priceChangePerc + 0
        elif 71 <= newDriverAge <= 80: priceChangePerc = priceChangePerc + 10
        elif newDriverAge > 80: priceChangePerc = priceChangePerc + 20
        else: print("Please enter a valid age.")

# ADDITIONAL CODE FOR TASK 3 ENDS HERE

newPrice = basePrice + ((priceChangePerc / 100) * basePrice)

newPrice = newPrice - ((discountPerc/100) * newPrice)

print("The total percentage change in the base price of insurance is: {}%".format(priceChangePerc))

print("The percentage discount due to years without claim is: {}%".format(discountPerc))

# ADDITIONAL CODE FOR TASK 2 BEGINS HERE

newCustDiscountPerc = 0

if 26 <= driverAge <= 70:
    if yearsWithoutClaim >= 2: newCustDiscountPerc = 10

print("The amount of money saved by applying the 'new customer discount' is: ${}".format(newPrice * (newCustDiscountPerc / 100)))

# ADDITIONAL CODE FOR TASK 2 ENDS HERE

print("The price to insure your car is: ${}".format(newPrice))