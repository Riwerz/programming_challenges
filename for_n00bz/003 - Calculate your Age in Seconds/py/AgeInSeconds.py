from datetime import datetime


print("Enter your birthdate (dd.mm.yyyy): ")

try:
    birthdate = datetime.strptime(input(), "%d.%m.%Y")
    current_time = datetime.now()
    difference = current_time - birthdate
    print("Your age equals ", round(difference.total_seconds()), " seconds")

except ValueError:
    print('Invalid input')
